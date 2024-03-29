﻿using AutoMapper;
using JobTastic.Data;
using JobTastic.Models;
using JobTastic.Models.JobOfferViewModels;
using JobTastic.Services;
using JobTastic.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;

namespace JobTastic.Controllers
{
    public class JobApplyController : Controller
    {
        private readonly IJobApplyService _jobApplyService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IJobOfferService _jobOfferService;
        private readonly AuthDbContext _db;
        public JobApplyController(
            IJobApplyService jobApplyService,
            IAuthService authService,
            AuthDbContext db,
            IMapper mapper,
            IJobOfferService jobOfferService)
        {
            _jobApplyService = jobApplyService;
            _authService = authService;
            _jobOfferService = jobOfferService;
            _mapper = mapper;
            _db = db;
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

        public async Task<IActionResult> Apply(string id)
        {
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
        public RedirectToActionResult ViewApplierCv(string applierId)
        {
            if (applierId == null)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("ViewCVContent", "Resume", new { UserId = applierId });
        }
        public async Task<IActionResult> Accept(string JobApplyId)
        {
            if (JobApplyId == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                var jobApply = await _jobApplyService.GetById(JobApplyId);
                jobApply.result = "accepted";
                jobApply.respond = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }
        public async Task<IActionResult> Refuse(string JobApplyId)
        {
            if (JobApplyId == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                var jobApply = await _jobApplyService.GetById(JobApplyId);
                jobApply.result = "refused";
                jobApply.respond = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }
        public IActionResult Delete(string JobApplyId)
        {
            /*if (JobApplyId == null)
            {
               
                return RedirectToAction("index");
            }
            else {
                var jobApply = _jobApplyService.Delete(JobApplyId);
                TempData["Delete"] = "success delete";

                // Redirect to the appropriate view or action
                return RedirectToAction("Index"); // Change "Index" to the action you want to redirect to
            }*/
            var jobApply = _db.JobApplies.Find(JobApplyId);

            if (jobApply == null)
            {
                TempData["Delete"] = "error delete application id not founs";
            }
            else
            {

                _db.JobApplies.Remove(jobApply);
                _db.SaveChanges();
                TempData["Delete"] = "success delete";
            }

            // Redirect to the appropriate view or action
            return RedirectToAction("Index"); // Change "Index" to the action you want to redirect to

        }

    }
}