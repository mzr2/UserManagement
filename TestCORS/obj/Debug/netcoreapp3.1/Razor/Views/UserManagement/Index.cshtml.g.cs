#pragma checksum "C:\Users\HidGa\Documents\GitHub\Project UserManagement\UserManagement\TestCORS\Views\UserManagement\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a243a1b422aa7ac14f708482a2602e7fad072ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserManagement_Index), @"mvc.1.0.view", @"/Views/UserManagement/Index.cshtml")]
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
#line 1 "C:\Users\HidGa\Documents\GitHub\Project UserManagement\UserManagement\TestCORS\Views\_ViewImports.cshtml"
using TestCORS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HidGa\Documents\GitHub\Project UserManagement\UserManagement\TestCORS\Views\_ViewImports.cshtml"
using TestCORS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a243a1b422aa7ac14f708482a2602e7fad072ea", @"/Views/UserManagement/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da5bcf14f23bd2fd428a69f62425524062cdcb42", @"/Views/_ViewImports.cshtml")]
    public class Views_UserManagement_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<h1>User Data</h1>

<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">
                Nama
            </th>
            <th scope=""col"">
                Action
            </th>
        </tr>
    </thead>
    <tbody id=""listuser"">
    </tbody>
</table>

<!-- Modal -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"" style=""text-transform:uppercase""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ...
            </div>
            <div class=""modal-footer"">
                <button type=""butt");
            WriteLiteral(@"on"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-primary"">Save changes</button>
            </div>
        </div>
    </div>
</div>

<table id=""example"" class=""display"" style=""width:100%"">
    <thead>
        <tr>
            <th></th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>NIK</th>
            <th>Phone</th>
            <th>Birthdate</th>
            <th>Salary</th>
            <th>Email</th>
            <th>Degree</th>
            <th>GPA</th>
            <th>University</th>
            <th></th>
        </tr>
    </thead>
    <tfoot>
        <tr>
            <th></th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>NIK</th>
            <th>Phone</th>
            <th>Birthdate</th>
            <th>Salary</th>
            <th>Email</th>
            <th>Degree</th>
            <th>GPA</th>
            <th>University</th>
            <");
            WriteLiteral(@"th></th>
        </tr>
    </tfoot>
</table>

<table id=""mytable"" class=""display"" style=""width:100%"">
    <thead>
        <tr>
            <th></th>
            <th>Name</th>
            <th>Url</th>
        </tr>
    </thead>
    <tfoot>
        <tr>
            <th></th>
            <th>Name</th>
            <th>URL</th>
        </tr>
    </tfoot>
</table>");
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
