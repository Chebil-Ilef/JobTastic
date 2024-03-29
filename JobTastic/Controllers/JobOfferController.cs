﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BulletinBoard.Infrastructure.AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JobTastic.Models;
using JobTastic.Models.JobOfferViewModels;
using JobTastic.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using JobTastic.Models.JobTypeViewModels;
using JobTastic.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace JobTastic.Controllers
{
    [Authorize]
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IAuthService _authService;
        private readonly IJobTypeService _jobTypeService;
        private readonly IJobApplyService _jobApplyService;
        private readonly IMapper _mapper;

        public JobOfferController(
            IJobOfferService jobOfferService,
            IJobCategoryService jobCategoryService,
            IJobTypeService jobTypeService,
            IAuthService authService,
            IJobApplyService jobApplyService,
            IMapper mapper)
        {
            _jobOfferService = jobOfferService;
            _jobCategoryService = jobCategoryService;
            _jobTypeService = jobTypeService;
            _authService = authService;
            _jobApplyService = jobApplyService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult Error(int? statusCode)
        {
            var vm = new ErrorViewModel
            {
                Response = statusCode?.ToString() ?? "-",
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(vm);
        }

        // GET: JobOffer
        [AllowAnonymous]
        public async Task<IActionResult> Index(string jobType, string jobCategorie, string sortOrder)
        {     //retrieving job offers 
            var jobOffers = await _jobOfferService.GetAllOffers();
            //retrieving non pending  job offers
            var nonPendingJobOffers = jobOffers.Where(offer => !offer.IsPending).ToList();
           
           
            // Filter job offers based on selected job type, if specified
            if (!string.IsNullOrEmpty(jobType))
            {
                nonPendingJobOffers = nonPendingJobOffers.Where(j => j.JobType.Name == jobType).ToList();
            }

            // Filter job offers based on selected job category, if specified
            if (!string.IsNullOrEmpty(jobCategorie))
            {
                nonPendingJobOffers = nonPendingJobOffers.Where(j => j.jobcategory.Name == jobCategorie).ToList();
            }

            var vms = _mapper.Map<IList<JobOfferViewModel>>(nonPendingJobOffers);

            //counting job offers 
            ViewData["JobOfferCount"] = vms.Count;
            // Retrieve job types and categories
            var jobTypes = await _jobTypeService.GetAllTypes();
            var jobCategories = await _jobCategoryService.GetAllCategories();

            // Create SelectList for job types and job categories
            ViewBag.JobTypes = new SelectList(jobTypes, "Name", "Name");
            ViewBag.JobCategories = new SelectList(jobCategories, "Name", "Name");
            //sorting logic (by salary and submission date)
            ViewBag.Sorting = new List<string> { "salary_desc", "salary_asc", "date_asc", "date_desc" };

            switch (sortOrder)
            {
                case "salary_desc":
                    vms = vms.OrderByDescending(o => o.Salary).ToList();
                    break;
                case "date_desc":
                    vms = vms.OrderByDescending(o => o.Submitted).ToList();
                    break;
                case "date":
                    vms = vms.OrderBy(o => o.Submitted).ToList();
                    break;
                default:
                    vms = vms.OrderBy(o => o.Salary).ToList();
                    break;
            }


            var user = await _authService.GetSignedUser(User);
            if (user != null) {
                foreach (var offer in vms)
                {
                    offer.CanEdit = await _jobOfferService.CanUserEditOffer(user.Id, offer.JobOfferId);
                }
            }

            return View(vms);
        }
        [Authorize(Roles = RoleHelper.Admin)]
        public async Task<IActionResult> AdminIndex()
        {
            var jobOffers = await _jobOfferService.GetAllOffers();
            var nonPendingJobOffers = jobOffers.Where(offer => !offer.IsPending).ToList();
            var vms = _mapper.Map<IList<JobOfferViewModel>>(nonPendingJobOffers);
            ViewData["JobOfferCount"] = vms.Count;

            foreach (var offer in vms)
            {
                offer.CanEdit = true;
            }

            return View(vms);
        }
        [Authorize(Roles = RoleHelper.Admin)]
        public async Task<IActionResult> AdminPendingJobs()
        {
            var jobOffers = await _jobOfferService.GetAllOffers();
            var PendingJobOffers = jobOffers.Where(offer => offer.IsPending).ToList();
            var vms = _mapper.Map<IList<JobOfferViewModel>>(PendingJobOffers);
            ViewData["JobOfferCount"] = vms.Count;

            foreach (var offer in vms)
            {
                offer.CanEdit = true;
            }

            return View(vms);
        }
        /***********************************************************************************/

        [HttpPost("/JobOffer/AcceptJobOffer/{id}")]
        public async Task<IActionResult> AcceptJobOffer(string id)
        {
            // Fetch the job offer from the service
            var jobOffer = await _jobOfferService.GetOfferById(id);

            // Check if the job offer exists
            if (jobOffer == null)
            {
                return NotFound();
            }

            // Update the IsPending attribute to false
            jobOffer.IsPending = false;

            // Save the changes
            var result = await _jobOfferService.Edit(jobOffer);
            if (result)
                return RedirectToAction(nameof(AdminPendingJobs));
            else
                return NotFound();
        }

        [HttpPost("/JobOffer/DeclineAndDeleteJobOffer/{id}")]
        public async Task<IActionResult> DeclineAndDeleteJobOffer(string id)
        {
            // Fetch the job offer from the service
            var jobOffer = await _jobOfferService.GetOfferById(id);

            // Check if the job offer exists
            if (jobOffer == null)
            {
                return NotFound();
            }

            // Delete the job offer
            var result = await _jobOfferService.Delete(jobOffer);

            if (result)
                return RedirectToAction(nameof(AdminPendingJobs));
            else
                return NotFound();
        }

        /***********************************************************************/

        [Route("JobOffer/Search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string jobType, string jobCategory)
        {
            // Retrieve all job offers
            var jobOffers = await _jobOfferService.GetAllOffers();

            // Retrieve non-pending job offers
            var nonPendingJobOffers = jobOffers.Where(offer => !offer.IsPending).ToList();

            // Map to view models
            var vms = _mapper.Map<IList<JobOfferViewModel>>(nonPendingJobOffers);

            // Count job offers
            ViewData["JobOfferCount"] = vms.Count;



            // Filtering logic based on job type and job category
            if (!string.IsNullOrEmpty(jobType))
            {
                jobType = jobType.Trim(); // Trim whitespace
                vms = vms.Where(o => string.Equals(o.JobType.Name, jobType, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(jobCategory))
            {
                jobCategory = jobCategory.Trim(); // Trim whitespace
                vms = vms.Where(o => string.Equals(o.JobCategory.Name, jobCategory, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Return the filtered job offers
            return View("Index", vms);
        }


        // GET: JobOffer/Popular
        [AllowAnonymous]
        public async Task<IActionResult> Popular()
        {
            var popularJobOffers = await _jobOfferService.GetMostPopularOffers();
            var vms = _mapper.Map<IEnumerable<PopularJobOfferViewModel>>(popularJobOffers);
            return View(vms);
        }

        // GET: JobOffer/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var jobOffer = await _jobOfferService.GetOfferById(id);

            if (jobOffer == null)
            {
                return View("NotFound");
            }

            await _jobOfferService.IncreaseOfferViews(jobOffer);

            var vm = _mapper.Map<DetailsJobOfferViewModel>(jobOffer);
            if (!await _authService.IsSignedIn(HttpContext.User))
            {
                return View(vm);
            }
            var user = await _authService.GetSignedUser(User);
            vm.CanEdit = await _jobOfferService.CanUserEditOffer(user.Id, vm.JobOfferId);
            return View(vm);
        }

        [Authorize(Roles = RoleHelper.Recruiter)]
        // GET: JobOffer/Create
        public async Task<IActionResult> Create()
        {
            var user = await _authService.GetSignedUser(User);
            var viewModel = new CreateJobOfferViewModel
            {
                AuthorId = user.Id,
                JobCategories = await _jobCategoryService.GetAllCategories(),
                JobTypes = await _jobTypeService.GetAllTypes(),

            };

            return View(viewModel);
        }

        // POST: JobOffer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateJobOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.JobCategories = await _jobCategoryService.GetAllCategories();
                model.JobTypes = await _jobTypeService.GetAllTypes();
                return View(model);
            }

            var jobOffer = _mapper.Map<JobOffer>(model);
            jobOffer.jobOfferId = GenerateRandomUniqueIdString();
            jobOffer.IsPending = true;
            var result = await _jobOfferService.Add(jobOffer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }

        [Authorize(Roles = RoleHelper.Recruiter)]
        // GET: JobOffer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            var offer = await _jobOfferService.GetOfferById(id);
            if (offer == null)
            {
                return View("NotFound");
            }

            var user = await _authService.GetSignedUser(User);
            if (!await _jobOfferService.CanUserEditOffer(user.Id, offer.jobOfferId))
            {
                return View("AccessDenied");
            }

            var vm = _mapper.Map<EditJobOfferViewModel>(offer);
            vm.JobCategories = await _jobCategoryService.GetAllCategories();
            vm.JobTypes = await _jobTypeService.GetAllTypes();
            return View(vm);
        }

        // POST: JobOffer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditJobOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.JobCategories = await _jobCategoryService.GetAllCategories();
                model.JobTypes = await _jobTypeService.GetAllTypes();
                return View(model);
            }

            var offer = _mapper.Map<JobOffer>(model);
            var result = await _jobOfferService.Edit(offer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }

        //[Authorize(Roles = RoleHelper.Admin)] 
        //[Authorize(Roles = RoleHelper.Recruiter)]
        // GET: JobOffer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _jobOfferService.GetOfferById(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<DeleteJobOfferViewModel>(jobOffer);
            return View(viewModel);
        }

        // POST: JobOffer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteJobOfferViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            var offer = _mapper.Map<JobOffer>(model);
            await _jobOfferService.Delete(offer);

            return RedirectToAction(nameof(Index));
           
        }
        public static string GenerateRandomUniqueIdString()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
