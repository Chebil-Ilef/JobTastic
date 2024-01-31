using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobTastic.Helpers;
using JobTastic.Models;
using JobTastic.Models.JobCategoryViewModels;
using Microsoft.AspNetCore.Authorization;
using JobTastic.Services.IServices;
using JobTastic.Models.JobTypeViewModels;
using AutoMapper;

namespace JobTastic.Controllers
{
    [Authorize(Roles = RoleHelper.Admin)]
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IMapper _mapper;

        public JobCategoryController(IJobCategoryService jobCategoryService, IMapper mapper)
        {
            _jobCategoryService = jobCategoryService;
            _mapper = mapper;
        }

        // GET: JobCategory
        public async Task<IActionResult> Index()
        {
            var jobCategories = await _jobCategoryService.GetAllCategories();
            var vm = _mapper.Map<IEnumerable<JobCategoryViewModel>>(jobCategories);
            return View(vm);
        }

        // GET: JobCategory/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var category = await _jobCategoryService.GetCategoryById(id);
            if (category == null)
            {
                return View("NotFound");
            }
            
            var vm = _mapper.Map<DetailsJobCategoryViewModel>(category);
            return View(vm);
        }

        // GET: JobCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateJobCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var m = _mapper.Map<JobCategory>(model);
            m.JobCategoryId = GenerateRandomUniqueIdString();
            var result = await _jobCategoryService.Add(m);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }

        // GET: JobCategory/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var category = await _jobCategoryService.GetCategoryById(id);
            if (category == null)
            {
                return View("NotFound");
            }

            var vm = _mapper.Map<EditJobCategoryViewModel>(category);
            return View(vm);
        }

        // POST: JobCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditJobCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _mapper.Map<JobCategory>(model);
            var result = await _jobCategoryService.Edit(category);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }

        // GET: JobCategory/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _jobCategoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<DeleteJobCategoryViewModel>(category);
            return View(vm);
        }

        // POST: JobType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteJobCategoryViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<JobCategory>(model);
            await _jobCategoryService.Delete(category);

            return RedirectToAction(nameof(Index));    

        }

        // Function to generate a random unique ID as a string (without hyphens)
        public static string GenerateRandomUniqueIdString()
        {
            return Guid.NewGuid().ToString("N");
        }
    }

}
