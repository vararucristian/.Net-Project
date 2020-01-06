#pragma checksum "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fc246d4a1f59b7c5f86be4dea7de8509c64880b"
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
#line 1 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using FrontEnd;

#line default
#line hidden
#line 7 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using FrontEnd.Shared;

#line default
#line hidden
#line 8 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using System.Text.Json;

#line default
#line hidden
#line 9 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#line 10 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\_Imports.razor"
using System.Net.Http.Headers;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BasicLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 70 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Login.razor"
        
    private string apiUrl = "https://localhost:7000/api/users/";
    string userName;
    string password;

    private async void LoginUser()
    {

        var response = await Http.GetJsonAsync<LoginResponse>(apiUrl+$"{userName}/{password}/");
        if(response.succes)
        {
            await LocalStorage.SetItemAsync("token", response.Token);
            await LocalStorage.SetItemAsync("id", response.user.Id);
            if (!Http.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await LocalStorage.GetItemAsync<string>("token");
                Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            await Http.GetAsync($"{apiUrl}authentificate");
            //NavigationManager.NavigateTo("/");
        }

        //NavigationManager.NavigateTo("/");
    }
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public object ImagePath { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public bool succes { get; set; }
        public User user { get; set; }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService LocalStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
