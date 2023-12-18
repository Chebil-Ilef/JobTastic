using JobTastic.Areas.Identity.Data;
using JobTastic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
       
    }
    // DbSet properties for your application entities
    public  DbSet<JobCategory> JobCategories { get; set; }
    public  DbSet<JobType> JobTypes { get; set; }
    public  DbSet<JobOffer> JobOffers { get; set; }
}
