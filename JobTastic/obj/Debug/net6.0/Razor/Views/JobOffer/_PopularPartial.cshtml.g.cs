#pragma checksum "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\JobOffer\_PopularPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff429c5c9c73d7ad34f717af8b766f2dddd0116"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JobOffer__PopularPartial), @"mvc.1.0.view", @"/Views/JobOffer/_PopularPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff429c5c9c73d7ad34f717af8b766f2dddd0116", @"/Views/JobOffer/_PopularPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b076011ed5ebc227dc2a6c7b2afceaa5f4d2f59e", @"/Views/_ViewImports.cshtml")]
    public class Views_JobOffer__PopularPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JobTastic.Models.JobOfferViewModels.PopularJobOfferViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<tr>\n    <td>\n        <p");
            BeginWriteAttribute("asp-hidden-email", " asp-hidden-email=\"", 92, "\"", 130, 1);
#nullable restore
#line 4 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\JobOffer\_PopularPartial.cshtml"
WriteAttributeValue("", 111, Model.Author.Email, 111, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\n    </td>\n    <td>\n        <p");
            BeginWriteAttribute("asp-display-for", " asp-display-for=\"", 166, "\"", 196, 1);
#nullable restore
#line 7 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\JobOffer\_PopularPartial.cshtml"
WriteAttributeValue("", 184, Model.Title, 184, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\n    </td>\n    <td>\n        <p");
            BeginWriteAttribute("asp-display-for", " asp-display-for=\"", 232, "\"", 273, 1);
#nullable restore
#line 10 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\JobOffer\_PopularPartial.cshtml"
WriteAttributeValue("", 250, Model.JobCategory.Name, 250, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\n    </td>\n    <td>\n        <p");
            BeginWriteAttribute("asp-display-for", " asp-display-for=\"", 309, "\"", 346, 1);
#nullable restore
#line 13 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\JobOffer\_PopularPartial.cshtml"
WriteAttributeValue("", 327, Model.JobType.Name, 327, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\n    </td>\n    <td>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fff429c5c9c73d7ad34f717af8b766f2dddd01165660", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\olfam\OneDrive\Documents\GitHub\JobTastic\JobTastic\Views\JobOffer\_PopularPartial.cshtml"
                                  WriteLiteral(Model.JobOfferId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </td>\n</tr>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JobTastic.Models.JobOfferViewModels.PopularJobOfferViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
