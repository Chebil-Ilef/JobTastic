using AutoMapper;
using JobTastic.Models;
using JobTastic.Models.JobOfferViewModels;
using JobTastic.Services;
using JobTastic.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobTastic.Controllers
{
    public class JobApplyController : Controller
    {
        private readonly IJobApplyService _jobApplyService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IJobOfferService _jobOfferService;
        public JobApplyController(
            IJobApplyService jobApplyService,
            IAuthService authService,
            IMapper mapper,
            IJobOfferService jobOfferService)
        {
            _jobApplyService = jobApplyService;
            _authService = authService;
            _jobOfferService = jobOfferService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _authService.GetSignedUser(User);
            IEnumerable<JobApply> jobApplies;
            if (user != null)
            {
                if (User.IsInRole("JobSearcher"))
                {
                    jobApplies = await _jobApplyService.GetAllByApplier(user.Id);
                }
                else
                {
                    jobApplies = await _jobApplyService.GetAllByRecruiter(user.Id);
                }
                return View(jobApplies);
            }
            else return View("Home/Index");
            
        }

        public async Task<IActionResult> Apply(string id) {
            var user = await _authService.GetSignedUser(User);
            var allowed = await _jobApplyService.GetApplication(user.Id, id);
            if (allowed.Count() != 0)
            {
                TempData["Message"] = "You already sent an application for this job offer";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var jobApply = new JobApply();
                jobApply.JobApplyId = GenerateRandomUniqueIdString();
                jobApply.ApplierId = user.Id;
                jobApply.JobOfferId = id;
                jobApply.respond = null;
                jobApply.Applier = await _authService.GetSignedUser(User);
                //var jobOfferEntity = await _jobOfferService.GetOfferById(id);
                //var jobOfferViewModel = _mapper.Map<JobOffer>(jobOfferEntity);
                //jobApply.JobOffer = jobOfferViewModel;
                jobApply.handled = false;
                jobApply.result = "Not Responded yet";
                var result = await _jobApplyService.Add(jobApply);
                if (result)
                {
                    TempData["Message"] = "Application sent";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Try again";
                    return RedirectToAction("Details", "JobOffer", new { id = id });
                }
            }
           
        }
        public static string GenerateRandomUniqueIdString()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
