#pragma checksum "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f23c09dcb05fac337374ca8a34a068cb0310d35"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FrontEnd.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using FrontEnd;

#line default
#line hidden
#line 7 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using FrontEnd.Shared;

#line default
#line hidden
#line 8 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using System.Text.Json;

#line default
#line hidden
#line 9 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#line 10 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#line 11 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using AspNetMonsters.Blazor.Geolocation;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BasicLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 11 "C:\Users\mike\Desktop\net\.Net-Project\Frontend\FrontEnd\Pages\Index.razor"
      
    private string apiUrl = "https://localhost:7000/api/users/";
    private async void checkUserStatus()
    {
        await Http.GetJsonAsync<string>($"{apiUrl}authentificate");
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
