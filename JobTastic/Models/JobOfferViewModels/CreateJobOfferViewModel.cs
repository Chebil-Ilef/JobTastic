using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobTastic.Helpers.CustomValidators;

namespace JobTastic.Models.JobOfferViewModels
{
    public class CreateJobOfferViewModel
    {

        [Required]
        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string JobCategoryId { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string JobTypeId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public IEnumerable<JobCategory>? JobCategories { get; set; }

        public IEnumerable<JobType>? JobTypes { get; set; }
    }
}
