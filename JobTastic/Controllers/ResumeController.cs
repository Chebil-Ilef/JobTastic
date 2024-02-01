using JobTastic.Areas.Identity.Data;
using JobTastic.Data;
using JobTastic.Models.ResumeModels;
using JobTastic.Services;
using JobTastic.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace JobTastic.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthDbContext _dbContext;
        private readonly IAuthService _authService;
        public ResumeController(AuthDbContext dbContext, ILogger<HomeController> logger, IAuthService authService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadCV()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadCV(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var user = await _authService.GetSignedUser(User);
                if (file != null && file.Length > 0)
                {
                    // Retrieve the existing CV if available
                    var existingCV = _dbContext.UserResumes
                        .FirstOrDefault(r => r.UserId == user.Id);

                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", fileName);
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    if (existingCV != null)
                    {
                        // Delete the previous CV file
                        DeleteCVFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingCV.ResumeFilePath.TrimStart('/')));

                        // Update existing CV
                        existingCV.ResumeFilePath = "/Uploads/" + fileName; // Update with new file path or binary data
                    }
                    else
                    {
                        // Create a new UserResume entity
                        var userResume = new UserResume
                        {
                            ResumeFilePath = "/Uploads/" + fileName, // or store binary data
                            UserId = user.Id
                        };

                        // Save the UserResume entity to the database
                        _dbContext.UserResumes.Add(userResume);
                    }
                    await _dbContext.SaveChangesAsync();
                }

                // Additional processing for other form fields
                // Redirect to a success page or display a success message
                return RedirectToAction("ViewCVContent",user);
            }

            // If model state is not valid, return to the form with errors
            return View();
        }


        public ActionResult ViewCVContent(ApplicationUser user)
        {
            // Retrieve user's CV record from the database (replace with your logic)
            var existingCV = _dbContext.UserResumes
                        .FirstOrDefault(r => r.UserId == user.Id);
            if (existingCV != null && !string.IsNullOrEmpty(existingCV.ResumeFilePath))
            {
                // Pass the file path to the view
                ViewBag.CVFilePath = existingCV.ResumeFilePath;

                return View();
            }

            // Redirect or handle the case where CV or file path doesn't exist
            return RedirectToAction("ViewCV");
        }

        public ActionResult ViewCV()
        {
            return View();
        }
        private void DeleteCVFile(string filePath)
        {
            try
            {
         

                FileInfo file = new FileInfo(filePath);

                if (file.Exists)
                {
                    file.Delete();
                    Console.WriteLine("File deleted successfully.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                // Log or print the exception details
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
    }
}
