using JobTastic.Areas.Identity.Data;

namespace JobTastic.Models
{
    public class JobApply
    {
            public String JobApplyId { get; set; }
            public String ApplierId { get; set; }
            public String JobOfferId { get; set; }
            public ApplicationUser Applier { get; set; }
            public JobOffer JobOffer { get; set; }
            public DateTime sent { get; set; }
            public DateTime? respond { get; set; }
            public Boolean handled { get; set; }
            public String result { get; set; }
    }
}
