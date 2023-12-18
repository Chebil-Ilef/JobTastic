using JobTastic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace JobTastic.Models
{
    public class JobOffer
    {
        public string jobOfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobType JobType { get; set; }
        public string JobTypeId { get; set; }

        public JobCategory jobcategory { get; set; }
        public string JobCategoryId { get; set; }

        public ApplicationUser author { get; set; }
        public string authorId { get; set; }

        public DateTime Submitted { get; set; }
        public DateTime LastEdit { get; set; }
        public int Visits { get; set; }


    }
}
