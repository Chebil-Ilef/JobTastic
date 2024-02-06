using JobTastic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTastic.Models.ResumeModels
{
    public class UserResume
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // Foreign key to ApplicationUser
        public string ResumeFilePath { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }
    }

}
