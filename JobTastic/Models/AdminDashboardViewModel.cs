
using System.ComponentModel.DataAnnotations.Schema;
using static JobTastic.Controllers.HomeController;

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

        [NotMapped]
        public ChartData ChartData { get; set; }

        [NotMapped]
        public BarData BarData { get; set; }
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

    public class ChartData
    {
        public ChartData()
        {
            Labels = new List<string>();
            Values = new List<int>();
        }

        public List<string> Labels { get; set; }
        public List<int> Values { get; set; }
    }

    public class BarData
    {
        public BarData()
        {
            Labs = new List<string>();
            Data = new List<int>();
        }

        public List<string> Labs { get; set; }
        public List<int> Data { get; set; }
    }
}

