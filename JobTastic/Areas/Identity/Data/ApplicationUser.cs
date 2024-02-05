using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JobTastic.Models.ResumeModels;
using Microsoft.AspNetCore.Identity;

namespace JobTastic.Areas.Identity.Data;


public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName {  get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    public string SelectedRole { get; set; }

    public virtual UserResume Resume { get; set; }
}

