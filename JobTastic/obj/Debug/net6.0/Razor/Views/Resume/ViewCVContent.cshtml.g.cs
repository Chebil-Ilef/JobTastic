#pragma checksum "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84f69752608c766843c5b1f50d567cee30f5c275"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resume_ViewCVContent), @"mvc.1.0.view", @"/Views/Resume/ViewCVContent.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\_ViewImports.cshtml"
using JobTastic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\_ViewImports.cshtml"
using JobTastic.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
using JobTastic.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84f69752608c766843c5b1f50d567cee30f5c275", @"/Views/Resume/ViewCVContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b076011ed5ebc227dc2a6c7b2afceaa5f4d2f59e", @"/Views/_ViewImports.cshtml")]
    public class Views_Resume_ViewCVContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
  
    ViewBag.Title = "CV Content";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>CV Content</h2>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.CVPath))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <br />\r\n    <br />\r\n    <iframe");
            BeginWriteAttribute("src", " src=\"", 469, "\"", 503, 1);
#nullable restore
#line 21 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
WriteAttributeValue("", 475, Url.Content(ViewBag.CVPath), 475, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100%; height: 600px;\"></iframe>\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 594, "\"", 680, 1);
#nullable restore
#line 25 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
WriteAttributeValue("", 601, Url.Action("DownloadCV", "Resume", new { userId=UserManager.GetUserId(User) }), 601, 79, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Download</a>\r\n");
#nullable restore
#line 26 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No CV content available.</p>\r\n");
#nullable restore
#line 31 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\Resume\ViewCVContent.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Add other HTML elements or styling based on your design requirements -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
