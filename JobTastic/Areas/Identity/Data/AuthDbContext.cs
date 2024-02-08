using JobTastic.Areas.Identity.Data;
using JobTastic.Models;
using JobTastic.Models.ResumeModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace JobTastic.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AdminDashboardViewModel>().HasNoKey();
       



    }
    // DbSet properties for your application entities
    public  DbSet<JobCategory> JobCategories { get; set; }
    public  DbSet<JobType> JobTypes { get; set; }
    public  DbSet<JobOffer> JobOffers { get; set; }
    public  DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<AdminDashboardViewModel> AdminDashboardViewModel { get; set; }
    public DbSet<UserResume> UserResumes { get; set; }
    public DbSet<JobApply> JobApplies { get; set; }
}
