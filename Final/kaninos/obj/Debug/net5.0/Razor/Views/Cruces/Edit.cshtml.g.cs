#pragma checksum "C:\Users\live\Downloads\Test\Proyecto\Final\kaninos\Views\Cruces\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21a9038cef9901e23c82c310833f27729869ea68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cruces_Edit), @"mvc.1.0.view", @"/Views/Cruces/Edit.cshtml")]
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
#line 1 "C:\Users\live\Downloads\Test\Proyecto\Final\kaninos\Views\_ViewImports.cshtml"
using kaninos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\live\Downloads\Test\Proyecto\Final\kaninos\Views\_ViewImports.cshtml"
using kaninos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21a9038cef9901e23c82c310833f27729869ea68", @"/Views/Cruces/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"945ab7ba43b2120ecf0503b7078b01a3bfdb01a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Cruces_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\live\Downloads\Test\Proyecto\Final\kaninos\Views\Cruces\Edit.cshtml"
  
    ViewBag.Title = "Editar";
    Layout ="~/Views/Template/_CrucesLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col mx-3"">
                    <div class=""row"">
                        <div class=""col mx-3 bg-dark text-white-50"">
                            <h3 class=""text-center fw-bold py-5 bg-dark text-white"">Cruces</h3>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21a9038cef9901e23c82c310833f27729869ea684071", async() => {
                WriteLiteral(@"
                                <div class=""mb-4"">
                                    <label for=""nombre"" class=""form-label"">Nombre Del Cruce</label>
                                    <input type=""text"" class=""form-control"" name=""nombre"" id=""nombre"" maxlength=""50"">
                                </div>
                                <div class=""row mb-4"">
                                    <div class=""col-6"">
                                        <input class=""form-control me-2"" type=""search"" placeholder=""Macho"" aria-label=""Search"">
                                    </div>
                                    <div class=""col-6"">
                                        <input class=""form-control me-2"" type=""search"" placeholder=""Hembra"" aria-label=""Search"">
                                    </div>
                                </div>
                                <div class=""mb-4"">
                                    <label for=""fecha_emp"" class=""form-label"">Fecha de Emparejamiento");
                WriteLiteral(@"</label>
                                    <input type=""date"" class=""form-control"" name=""fecha_emp"" id=""fecha_emp"">
                                </div>
                                <div class=""mb-4"">
                                    <label for=""fecha_nac"" class=""form-label"">Fecha Nacimiento</label>
                                    <input type=""date"" class=""form-control"" name=""fecha_nac"" id=""fecha_nac"">
                                </div>
                                <div class=""row mb-4"">
                                    <div class=""col-3"">
                                        <label for=""ejemplares_nac"" class=""form-label"">Ejemplares Nacidos</label>
                                        <input type=""number"" class=""form-control"" name=""ejemplares_nac"" id=""ejemplares_nac"" min=""1"" max=""20"" value=""1"">
                                    </div>
                                    <div class=""col-3"">
                                        <label for=""cantidad_machos"" class=""");
                WriteLiteral(@"form-label"">Cantidad de Machos</label>
                                        <input type=""number"" class=""form-control"" name=""cantidad_machos"" id=""cantidad_machos"" min=""0"" max=""20"" value=""0"">
                                    </div>
                                    <div class=""col-3"">
                                        <label for=""cantidad_hembras"" class=""form-label"">Cantidad de Hembras</label>
                                        <input type=""number"" class=""form-control"" name=""cantidad_hembras"" id=""cantidad_hembras"" min=""0"" max=""20"" value=""0"">
                                    </div>
                                    <div class=""col-3"">
                                        <label for=""num_bajas"" class=""form-label"">Numero de Bajas</label>
                                        <input type=""number"" class=""form-control"" name=""num_bajas"" id=""num_bajas"" min=""0"" max=""20"" value=""0"">
                                    </div>
                                </div>
                  ");
                WriteLiteral("              <div class=\"mb-4\">\r\n                                    <input class=\"form-control me-2\" type=\"search\" placeholder=\"Criador\" aria-label=\"Search\">\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>");
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
