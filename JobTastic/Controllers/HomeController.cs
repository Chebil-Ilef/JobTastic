using JobTastic.Data;
using JobTastic.Migrations;
using JobTastic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                UsersList = GetUsersList()

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
                .Take(7) // Adjust based on the number of top offers you want to display
                .Select(j => new Offer
                {
                    JobTitle = j.Title,
                    Salary = j.Salary, // Adjust this based on your actual property name
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
