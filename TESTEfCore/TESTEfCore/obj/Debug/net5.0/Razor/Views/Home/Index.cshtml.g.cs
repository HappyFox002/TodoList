#pragma checksum "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a6149b6d91128b8b82965e9f755af87df4470c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a6149b6d91128b8b82965e9f755af87df4470c0", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TESTEfCore.Models.Task>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Start Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
 if(Model.Count > 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"taskList\">\r\n        <div class=\"header\">Ваши задачи</div>\r\n");
#nullable restore
#line 9 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
         foreach(var task in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"task\">");
#nullable restore
#line 10 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
                         Write(task.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 11 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <div class=""taskDetailed"">
        <div class=""taskName"">Задача</div>
        <div class=""currentTask"">Текущие задачи</div>
        <div class=""overdueTask"">Просроченные задачи</div>
        <div class=""completedTask"">Выполненые задачи</div>
    </div>
");
#nullable restore
#line 19 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
} else {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"noTasks\">У Вас не имеется задач :)</div>\r\n");
#nullable restore
#line 21 "D:\Code\github\TodoList\TESTEfCore\TESTEfCore\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TESTEfCore.Models.Task>> Html { get; private set; }
    }
}
#pragma warning restore 1591
