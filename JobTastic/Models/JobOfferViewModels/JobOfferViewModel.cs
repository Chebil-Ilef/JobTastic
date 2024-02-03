﻿using JobTastic.Areas.Identity.Data;
using JobTastic.Models;
using System.ComponentModel.DataAnnotations;

namespace JobTastic.Models.JobOfferViewModels
{
    public class JobOfferViewModel
    {
        public string JobOfferId { get; set; }

        [Display(Name = "Author")]
        public ApplicationUser Author { get; set; }

        [Display(Name = "Category")]
        public JobCategory JobCategory { get; set; }

        [Display(Name = "Type")]
        public JobType JobType { get; set; }

        public DateTime Submitted { get; set; }

        public DateTime LastEdit { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        public Decimal Salary { get; set; }

        public int Visits { get; set; }

        public bool CanEdit { get; set; }
    }
}
