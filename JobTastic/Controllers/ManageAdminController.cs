using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobTastic.Models;
using JobTastic.Data;
using JobTastic.ViewModels;

namespace JobTastic.Controllers
{
    public class ManageAdminController : Controller
    {
        private readonly AuthDbContext _dbContext;

        public ManageAdminController(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: ManageUsers
        public IActionResult Index()
        {
            var admins = _dbContext.Users.ToList();
            var viewModel = new ManageAdminViewModel
            {
                AdminsList = GetAdminsList()
            };
            return View(viewModel);
        }

        private List<UserInfo> GetAdminsList()
        {
            var adminsList = _dbContext.Users
                .Where(u => u.SelectedRole == "Admin")
                .Select(u => new UserInfo
                {
                    Name = u.FirstName,
                    Email = u.Email,
                    SelectedRole = u.SelectedRole
                })
                .ToList();

            return adminsList;
        }

    }
}
