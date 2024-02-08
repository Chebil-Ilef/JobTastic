using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobTastic.Models;
using JobTastic.Data;
using JobTastic.ViewModels;
using JobTastic.Areas.Identity.Data;

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

        // GET: ManageUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                // Add the user to the database
                var user = new ApplicationUser
                {
                    FirstName = userInfo.Name,
                    Email = userInfo.Email,
                    SelectedRole = userInfo.SelectedRole
                    // Populate other properties as needed
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        // GET: ManageUsers/Edit/5
        public IActionResult Edit(string id)
        {
           

            return View();
        }

        // POST: ManageUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, UserInfo userInfo)
        {
            

            if (ModelState.IsValid)
            {
                var user = _dbContext.Users.Find(id);
                if (user == null)
                {
                    return NotFound();
                }

                // Update user properties
                user.FirstName = userInfo.Name;
                user.Email = userInfo.Email;
                user.SelectedRole = userInfo.SelectedRole;

                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

    }
}
