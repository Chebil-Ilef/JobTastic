
namespace JobTastic.Models
{
    public class AdminDashboardViewModel
    {
        public int TodaysOffers { get; set; }
        public int TotalOffers { get; set; }
        public int NumberOfRecruiters { get; set; }
        public int NumberOfJobSearchers { get; set; }
        public List<Offer> Offers { get; set; }
        public List<UserInfo> UsersList { get; set; }

    }

    public class Offer
    {
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Location { get; set; }
        public int VisitsCount { get; set; }

    }

    public class UserInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string SelectedRole { get; set; }
    }

}
