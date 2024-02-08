using JobTastic.Models;
using JobTastic.Services;
using Microsoft.EntityFrameworkCore;
using JobTastic.Data;
using JobTastic.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using JobTastic.Repositories.IRepositories;
using JobTastic.Repositories;
using JobTastic.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using BulletinBoard.Infrastructure.AutoMapper;
using Autofac.Core;
using JobTastic.Controllers;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'sendMailContextConnection' not found.");

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Manual AutoMapper configuration
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<DefaultProfile>();
});

var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IJobOfferRepository, JobOfferRepository>();
builder.Services.AddScoped<IJobTypeRepository, JobTypeRepository>();
builder.Services.AddScoped<IJobApplyRepository, JobApplyRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJobCategoryService, JobCategoryService>();
builder.Services.AddScoped<IJobOfferService, JobOfferService>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJobApplyService, JobApplyService>();




// Configuration added here
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

/*seeding*/
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    // Ensure roles exist or create them
    var roles = new[] { "Admin", "Recruiter", "JobSearcher" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Ensure admin user exists or create it
    string email = "jobtasticc@gmail.com";
    string password = "Jobtastic123+";
    
    var adminUser = await userManager.FindByEmailAsync(email);

    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            Email = email,
            UserName = email,
            FirstName = "Admin",
            LastName = "Jobstatic",
            EmailConfirmed = true,
            SelectedRole = "Admin"
        };

        await userManager.CreateAsync(adminUser, password);
    }

    // Assign the admin user to the "Admin" role
    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}


app.Run();
