#pragma checksum "D:\NoticeBoard\NoticeBoard\Views\Notices\ErrorPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a2846f1d62002f4d7c8e73f75fefa4348eadba9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notices_ErrorPage), @"mvc.1.0.view", @"/Views/Notices/ErrorPage.cshtml")]
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
#line 1 "D:\NoticeBoard\NoticeBoard\Views\_ViewImports.cshtml"
using NoticeBoard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\NoticeBoard\NoticeBoard\Views\_ViewImports.cshtml"
using NoticeBoard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a2846f1d62002f4d7c8e73f75fefa4348eadba9", @"/Views/Notices/ErrorPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a5098c7ceb4e80aca1e524669508661f076e344", @"/Views/_ViewImports.cshtml")]
    public class Views_Notices_ErrorPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\NoticeBoard\NoticeBoard\Views\Notices\ErrorPage.cshtml"
  
    ViewData["Title"] = "Empty query";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1>There is no notices with this catagories.</h1>\r\n    <button type=\"button\" class=\"btn btn-outline-info button-read\"");
            BeginWriteAttribute("onclick", " onclick=\"", 204, "\"", 267, 3);
            WriteAttributeValue("", 214, "location.href=\'", 214, 15, true);
#nullable restore
#line 9 "D:\NoticeBoard\NoticeBoard\Views\Notices\ErrorPage.cshtml"
WriteAttributeValue("", 229, Url.Action("Index", "Notices", null), 229, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 266, "\'", 266, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Go to main page</button>\r\n</div>\r\n");
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
