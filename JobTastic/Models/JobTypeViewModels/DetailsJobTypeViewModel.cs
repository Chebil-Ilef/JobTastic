using System.ComponentModel.DataAnnotations;
using JobTastic.Helpers.CustomValidators;

namespace JobTastic.Models.JobTypeViewModels
{
    public class DetailsJobTypeViewModel
    {
        public string JobTypeId { get; set; }
        
        public string Name { get; set; }
    }
}
