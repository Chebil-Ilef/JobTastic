using JobTastic.Data;
using JobTastic.Migrations;
using JobTastic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Linq;
using System.Diagnostics;

namespace JobTastic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthDbContext _dbContext;
        public HomeController(AuthDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var viewModel = new AdminDashboardViewModel
            {
                TodaysOffers = _dbContext.JobOffers.Count(j => EF.Functions.DateDiffDay(j.Submitted, DateTime.UtcNow) == 0),
                TotalOffers = _dbContext.JobOffers.Count(),
                NumberOfRecruiters = _dbContext.Users.Count(u => u.SelectedRole == "Recruiter"),
                NumberOfJobSearchers = _dbContext.Users.Count(u => u.SelectedRole == "JobSearcher"),
                Offers = GetTopOffers(),
                UsersList = GetUsersList(),
                ChartData = GetChartData(),
                BarData =GetBarData()



            };

            // Log or debug statements to check data
            _logger.LogInformation($"Job Offers Count: {viewModel.TodaysOffers}");
            _logger.LogInformation($"Recruiters Count: {viewModel.NumberOfRecruiters}");
            _logger.LogInformation($"Job Searchers Count: {viewModel.NumberOfJobSearchers}");

            return View(viewModel);
        }

        private List<Offer> GetTopOffers()
        {
            // Fetch data from the database
            var topOffers = _dbContext.JobOffers
                .OrderByDescending(j => j.Visits)
                .Take(7) 
                .Select(j => new Offer
                {
                    JobTitle = j.Title,
                    Salary = j.Salary, 
                    DateSubmitted = j.Submitted,
                    VisitsCount = j.Visits,
                    Location = j.Location
                })
                .ToList();

            return topOffers;
        }

        private List<UserInfo> GetUsersList()
        {
            // Fetch user data from the database
            var usersList = _dbContext.Users
                .Select(u => new UserInfo
                {
                    Name = u.FirstName,
                    Email = u.Email,
                    SelectedRole = u.SelectedRole
                })
                .ToList();

            return usersList;
        }


 

        public ChartData GetChartData()
        {
            Dictionary<string, string> categoryIds = new Dictionary<string, string>
    {
        { "IT", "1" }, 
        { "Accounting", "2" }, 
        { "Arts", "3" }, 
        { "Education", "4" },
        { "Law", "5" }, 
        { "Others", "6" } 
    };

            ChartData ChartData = new ChartData();

            foreach (var category in categoryIds)
            {
                int categoryCount = _dbContext.JobOffers.Count(j => j.JobCategoryId == category.Value);
                ChartData.Labels.Add(category.Key);
                ChartData.Values.Add(categoryCount);
            }

        
            return ChartData;
        }

        public BarData GetBarData()
        {
            Dictionary<string, string> typesIds = new Dictionary<string, string>
    {
        { "part time", "1" },
        { "full time", "2" },
        { "remote", "3" }
        
    };

            BarData BarData = new BarData();

            foreach (var type in typesIds)
            {
                int typeCount = _dbContext.JobOffers.Count(j => j.JobTypeId == type.Value);
                BarData.Labs.Add(type.Key);
                BarData.Data.Add(typeCount);
            }


            return BarData;
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
 