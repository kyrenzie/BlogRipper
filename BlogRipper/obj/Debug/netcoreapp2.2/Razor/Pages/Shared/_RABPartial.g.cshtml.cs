#pragma checksum "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a9ccaf25890836e493f4749e483d7508e487a9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BlogRipper.Pages.Shared.Pages_Shared__RABPartial), @"mvc.1.0.view", @"/Pages/Shared/_RABPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/_RABPartial.cshtml", typeof(BlogRipper.Pages.Shared.Pages_Shared__RABPartial))]
namespace BlogRipper.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\_ViewImports.cshtml"
using BlogRipper;

#line default
#line hidden
#line 3 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\_ViewImports.cshtml"
using BlogRipper.Data;

#line default
#line hidden
#line 1 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a9ccaf25890836e493f4749e483d7508e487a9b", @"/Pages/Shared/_RABPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03db9e73ba0e68dbad2b5d0339add4160c1443d6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__RABPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 542, true);
            WriteLiteral(@"

<div id=""content"">
        <div id=""content-inner"">
            <div id=""alpha"">
                <div id=""alpha-inner"">
                    <div id=""entry-2650"" class=""entry-asset asset hentry"">
                         <div>&nbsp;</div> 
                        
                           <div class=""asset-header"" style="" padding: 10px;"">
                        <h1 id=""page-title"" class=""asset-name entry-title"" style="" margin: 10px 0 5px 0;"">
                            <!-- {mmddyy}_{brand}.shtml -->
                            <p>");
            EndContext();
            BeginContext(585, 31, false);
#line 14 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
                          Write(Model.Date.ToString("MM-dd-yy"));

#line default
#line hidden
            EndContext();
            BeginContext(616, 36, true);
            WriteLiteral("</p>\n                             <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 652, "\"", 673, 1);
#line 15 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
WriteAttributeValue("", 659, Model.PlanUrl, 659, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(674, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(676, 22, false);
#line 15 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
                                                 Write(Html.Raw(@Model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(698, 312, true);
            WriteLiteral(@"</a>
                        </h1>
                        <div class=""asset-meta""></div>
                        <div class=""asset-content entry-content"">
                            <div class=""asset-body"">
                            <!-- images/{mmddyy}_{brand}_promo.png -->
                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1010, "\"", 1032, 1);
#line 21 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
WriteAttributeValue("", 1016, Model.PlanImage, 1016, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1033, 349, true);
            WriteLiteral(@" align=""right"" width=""288"">
                                    <br>The Offers:
                                    <br>
                                    <br>
                                    <ul style=""padding-left:20px;"">
                                        <li style=""list-style-type:disc;"">
                                            ");
            EndContext();
            BeginContext(1383, 16, false);
#line 27 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
                                       Write(Model.Paragraph1);

#line default
#line hidden
            EndContext();
            BeginContext(1399, 201, true);
            WriteLiteral("\n                                        </li>\n                                        <br>\n                                    </ul>\n                                   \n                            <p>");
            EndContext();
            BeginContext(1601, 16, false);
#line 32 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
                          Write(Model.Paragraph2);

#line default
#line hidden
            EndContext();
            BeginContext(1617, 91, true);
            WriteLiteral("</p>\n\t\t\t\t\t\t\t\t\t<br>\n                            <br>\n\t\t\t\t\t\t\t\n                            <p>");
            EndContext();
            BeginContext(1709, 27, false);
#line 36 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
                          Write(Html.Raw(@Model.Paragraph3));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 173, true);
            WriteLiteral("</p>\n                                <br>\n                                <br>\n                                <span class=\"noprint\">\n                                    <p>");
            EndContext();
            BeginContext(1910, 27, false);
#line 40 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
                                  Write(Html.Raw(@Model.Paragraph4));

#line default
#line hidden
            EndContext();
            BeginContext(1937, 434, true);
            WriteLiteral(@"</p>
                                    <br>This information is provided by Co>Op Connect to assist you in selling more advertising, both to new and existing clients. Use it to take a complete advertising solution to your local retailers.
                                    <br>
                                    <br>
                                    <!-- {mmddyy}_{brand}_print.shtml -->
                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2371, "\"", 2393, 1);
#line 45 "C:\Users\kyler\Desktop\BlogRipper\BlogRipper\Pages\Shared\_RABPartial.cshtml"
WriteAttributeValue("", 2378, Model.PrintUrl, 2378, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2394, 275, true);
            WriteLiteral(@"><img alt=""Print this Promo"" src=""/blog/images/print_blog.png""></a>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
