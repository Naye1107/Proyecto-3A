#pragma checksum "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cd5ff9bd38bfee0ddcbad0b0db76c3ea167098f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cruces_Delete), @"mvc.1.0.view", @"/Views/Cruces/Delete.cshtml")]
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
#line 1 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\_ViewImports.cshtml"
using kaninos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\_ViewImports.cshtml"
using kaninos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cd5ff9bd38bfee0ddcbad0b0db76c3ea167098f", @"/Views/Cruces/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"945ab7ba43b2120ecf0503b7078b01a3bfdb01a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Cruces_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<kaninos.Models.CruceDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary ml-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Criadores", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
  
    ViewBag.Title = "Detalles";
    Layout ="~/Views/Template/_CrucesLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col mx-3 bg-dark text-white\">\r\n                    <h3 class=\"text-center fw-bold pt-5\">");
#nullable restore
#line 8 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                                                    Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                    <h2 class=""text-center fw-bold py-2""></h2>
                    <div class=""row"">
                        <div class=""col-4"">
                            <div class=""container-fluid"">
                                <p>Nombre Del Cruse:</p>
                                <p>Macho:</p>
                                <p>Hembra:</p>
                                <p>Fecha De Emparejamiento:</p>
                                <p>Fecha De Nacimiento:</p>
                                <P>Ejemplares Nacidos:</P>
                                <p>Cantidad Machos:</p>
                                <p>Cantidad Hembras:</p>
                                <p>Numero De Bajas:</p>  
                                <p>Criador:</p>                         
                            </div>
                        </div>
                        <div class=""col"">
                            <div class=""container-fluid"">
                                <p>");
#nullable restore
#line 27 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 28 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.padre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 29 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.madre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 30 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.fecha_emp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 31 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.fecha_nac);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <P>");
#nullable restore
#line 32 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.ejemplares_nac);

#line default
#line hidden
#nullable disable
            WriteLiteral("</P>\r\n                                <p>");
#nullable restore
#line 33 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.cantidad_machos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 34 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.cantidad_hembras);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 35 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.num_bajas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>  \r\n                                <p>");
#nullable restore
#line 36 "D:\proyectos\HTML\Html Proyecto Integrador\Final\kaninos\Views\Cruces\Delete.cshtml"
                              Write(Model.criador);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                    </div>
                    <div class=""text-right"">
                        <input class=""btn btn-danger ml-2 mr-2"" type=""submit"" value=""Eliminar"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cd5ff9bd38bfee0ddcbad0b0db76c3ea167098f8915", async() => {
                WriteLiteral("Volver");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<kaninos.Models.CruceDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
