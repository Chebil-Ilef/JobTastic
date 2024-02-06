using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobTastic.Models;
using JobTastic.Data;
using JobTastic.ViewModels;

namespace JobTastic.Controllers
{
    public class ManageUsersController : Controller
    {
        private readonly AuthDbContext _dbContext;

        public ManageUsersController(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: ManageUsers
        public IActionResult Index()
        {
            var users = _dbContext.Users.ToList();
            var viewModel = new ManageUsersViewModel
            {
                UsersList = GetUsersList()
            };
            return View(viewModel);
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
    }
}
