#pragma checksum "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee56c0603388cafa3618a1553a83b90ba84e8c3f"
// <auto-generated/>
#pragma warning disable 1591
namespace FrontEnd.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using FrontEnd;

#line default
#line hidden
#line 7 "C:\Users\mike\Desktop\.Net-Project\Front\FrontEnd\_Imports.razor"
using FrontEnd.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BasicLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Hello, world!</h1>\r\n\r\nWelcome to your new app.\r\n\r\n");
            __builder.OpenComponent<FrontEnd.Shared.SurveyPrompt>(1);
            __builder.AddAttribute(2, "Title", "How is Blazor working for you?");
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
