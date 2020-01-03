#pragma checksum "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7359cd85b4f5c78b6ccc0ca5a165f2ea1a2efe11"
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
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BasicLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container mx-auto");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "flex justify-center px-6 my-12");
            __builder.AddMarkupContent(5, "\r\n        \r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "w-full xl:w-3/4 lg:w-11/12 flex");
            __builder.AddMarkupContent(8, "\r\n\r\n            \r\n            ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "w-full lg:w-7/12 bg-white p-5 rounded-l-lg");
            __builder.AddMarkupContent(11, "\r\n                ");
            __builder.AddMarkupContent(12, "<h3 class=\"pt-4 text-2xl text-center\">Create an Account!</h3>\r\n                ");
            __builder.OpenElement(13, "form");
            __builder.AddAttribute(14, "class", "px-8 pt-6 pb-8 mb-4 bg-white rounded");
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "mb-4 md:flex md:justify-between");
            __builder.AddMarkupContent(18, "\r\n                        ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "mb-4 md:mr-2 md:mb-0");
            __builder.AddMarkupContent(21, "\r\n                            ");
            __builder.AddMarkupContent(22, "<label class=\"block mb-2 text-sm font-bold text-gray-700\" for=\"firstName\">\r\n                                First Name\r\n                            </label>\r\n                            ");
            __builder.OpenElement(23, "input");
            __builder.AddAttribute(24, "class", "w-full px-3 py-2 text-sm leading-tight text-gray-700 border rounded shadow appearance-none focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(25, "id", "firstName");
            __builder.AddAttribute(26, "type", "text");
            __builder.AddAttribute(27, "placeholder", "First Name");
            __builder.AddAttribute(28, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 20 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                          firstName

#line default
#line hidden
            ));
            __builder.AddAttribute(29, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => firstName = __value, firstName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                        ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "md:ml-2");
            __builder.AddMarkupContent(34, "\r\n                            ");
            __builder.AddMarkupContent(35, "<label class=\"block mb-2 text-sm font-bold text-gray-700\" for=\"lastName\">\r\n                                Last Name\r\n                            </label>\r\n                            ");
            __builder.OpenElement(36, "input");
            __builder.AddAttribute(37, "class", "w-full px-3 py-2 text-sm leading-tight text-gray-700 border rounded shadow appearance-none focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(38, "id", "lastName");
            __builder.AddAttribute(39, "type", "text");
            __builder.AddAttribute(40, "placeholder", "Last Name");
            __builder.AddAttribute(41, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 29 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                          lastName

#line default
#line hidden
            ));
            __builder.AddAttribute(42, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => lastName = __value, lastName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                    ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "mb-4");
            __builder.AddMarkupContent(48, "\r\n                        ");
            __builder.AddMarkupContent(49, "<label class=\"block mb-2 text-sm font-bold text-gray-700\" for=\"email\">\r\n                            Email\r\n                        </label>\r\n                        ");
            __builder.OpenElement(50, "input");
            __builder.AddAttribute(51, "class", "w-full px-3 py-2 mb-3 text-sm leading-tight text-gray-700 border rounded shadow appearance-none focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(52, "id", "email");
            __builder.AddAttribute(53, "type", "email");
            __builder.AddAttribute(54, "placeholder", "Email");
            __builder.AddAttribute(55, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 39 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                      email

#line default
#line hidden
            ));
            __builder.AddAttribute(56, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => email = __value, email));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                    ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "mb-4");
            __builder.AddMarkupContent(61, "\r\n                        ");
            __builder.AddMarkupContent(62, "<label class=\"block mb-2 text-sm font-bold text-gray-700\" for=\"email\">\r\n                            Username\r\n                        </label>\r\n                        ");
            __builder.OpenElement(63, "input");
            __builder.AddAttribute(64, "class", "w-full px-3 py-2 mb-3 text-sm leading-tight text-gray-700 border rounded shadow appearance-none focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(65, "id", "username");
            __builder.AddAttribute(66, "type", "text");
            __builder.AddAttribute(67, "placeholder", "Username");
            __builder.AddAttribute(68, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 48 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                      userName

#line default
#line hidden
            ));
            __builder.AddAttribute(69, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => userName = __value, userName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n                    ");
            __builder.OpenElement(72, "div");
            __builder.AddAttribute(73, "class", "mb-4 md:flex md:justify-between");
            __builder.AddMarkupContent(74, "\r\n                        ");
            __builder.OpenElement(75, "div");
            __builder.AddAttribute(76, "class", "mb-4 md:mr-2 md:mb-0");
            __builder.AddMarkupContent(77, "\r\n                            ");
            __builder.AddMarkupContent(78, "<label class=\"block mb-2 text-sm font-bold text-gray-700\" for=\"password\"><br>\r\n                                Password\r\n                            </label>\r\n                            ");
            __builder.OpenElement(79, "input");
            __builder.AddAttribute(80, "class", "w-full px-3 py-2 mb-3 text-sm leading-tight text-gray-700 border border-red-500 rounded shadow appearance-none focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(81, "id", "password");
            __builder.AddAttribute(82, "type", "password");
            __builder.AddAttribute(83, "placeholder", "******************");
            __builder.AddAttribute(84, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 58 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                          password

#line default
#line hidden
            ));
            __builder.AddAttribute(85, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => password = __value, password));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                            ");
            __builder.AddMarkupContent(87, "<p class=\"text-xs italic text-red-500\">Please choose a password.</p>\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n                        ");
            __builder.OpenElement(89, "div");
            __builder.AddAttribute(90, "class", "md:ml-2");
            __builder.AddMarkupContent(91, "\r\n                            ");
            __builder.AddMarkupContent(92, "<label class=\"block mb-2 text-sm font-bold text-gray-700\" for=\"c_password\">\r\n                                Confirm Password\r\n                            </label>\r\n                            ");
            __builder.OpenElement(93, "input");
            __builder.AddAttribute(94, "class", "w-full px-3 py-2 mb-3 text-sm leading-tight text-gray-700 border rounded shadow appearance-none focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(95, "id", "c_password");
            __builder.AddAttribute(96, "type", "password");
            __builder.AddAttribute(97, "placeholder", "******************");
            __builder.AddAttribute(98, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 68 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                          password2

#line default
#line hidden
            ));
            __builder.AddAttribute(99, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => password2 = __value, password2));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n                        ");
            __builder.OpenElement(102, "div");
            __builder.AddAttribute(103, "class", "mb-4");
            __builder.AddMarkupContent(104, "\r\n");
#line 74 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                             if (password != password2)
                            {

#line default
#line hidden
            __builder.AddContent(105, "                                ");
            __builder.AddMarkupContent(106, "<span class=\"small form-text text-danger\">Passwords didn\'t match</span>\r\n");
#line 77 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                            }

#line default
#line hidden
            __builder.AddContent(107, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(108, "\r\n                       \r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(109, "\r\n                    ");
            __builder.OpenElement(110, "div");
            __builder.AddAttribute(111, "class", "mb-6 text-center");
            __builder.AddMarkupContent(112, "\r\n                        ");
            __builder.OpenElement(113, "button");
            __builder.AddAttribute(114, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 82 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
                                           AddAccount

#line default
#line hidden
            ));
            __builder.AddAttribute(115, "class", "w-full px-4 py-2 font-bold text-white bg-blue-500 rounded-full hover:bg-blue-700 focus:outline-none focus:shadow-outline");
            __builder.AddAttribute(116, "type", "button");
            __builder.AddMarkupContent(117, "\r\n                            Register\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(118, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(119, "\r\n                    <hr class=\"mb-6 border-t\">\r\n                    ");
            __builder.AddMarkupContent(120, @"<div class=""text-center"">
                        <a class=""inline-block text-sm text-blue-500 align-baseline hover:text-blue-800"" href=""./forgot-password-page.html"">
                            Forgot Password?
                        </a>
                    </div>
                    ");
            __builder.AddMarkupContent(121, @"<div class=""text-center"">
                        <a class=""inline-block text-sm text-blue-500 align-baseline hover:text-blue-800"" href=""./login-page.html"">
                            Already have an account? Login!
                        </a>
                    </div>
                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(122, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(123, "\r\n            \r\n            <div class=\"w-full h-auto bg-gray-400 hidden lg:block lg:w-5/12 bg-cover rounded-r-lg\" style=\"background-image: url(\'https://i.pinimg.com/564x/f8/1a/0b/f81a0b965c142eea47e6f6eefdffb339.jpg\')\"></div>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(124, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(125, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 109 "F:\.Net\Project\.Net-Project\Frontend\FrontEnd\Pages\Register.razor"
        
    private string apiUrl = "https://localhost:7000/api/users/";
    string firstName;
    string lastName;
    string userName;
    string email;
    string password;
    string password2;
    private async void AddAccount()
    {
        if (password != password2)
            return;
        var account = new CreateAccount {
            FirstName= firstName,
            LastName = lastName,
            UserName = userName,
            Email = email,
            Password = password

        };
    
        await Http.PostJsonAsync(apiUrl, account);

        NavigationManager.NavigateTo("/login");
    }

    public class CreateAccount
    {
        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public string UserName { get;  set; }

        public string Email { get;  set; }

        public string Password { get;  set; }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
