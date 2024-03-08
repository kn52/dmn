using MagicVillaServiceJ;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MagicVilla_Uitility;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MagicVilla_Web.HttpExtensions;

namespace MagicVilla_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly MagicVillaServiceJClient _sevices;
        private readonly HttpManager httpManager;

        public UserController(MagicVillaServiceJClient sevices, HttpManager httpManager)
        {
            _sevices = sevices;
            this.httpManager = httpManager;
        }

        public async Task<IActionResult> Index()
        {
            List<RegistrationRequestDTO> users = new List<RegistrationRequestDTO>();
            try
            {
                var response = await _sevices.GetAllUsersAsync().ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    users = response.Result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Index", users);
        }
        public async Task<IActionResult> ViewLogin(LoginRequestDTO loginRequestDTO)
        {
            return View("Login", loginRequestDTO);
        }
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var response = await _sevices.LoginAsync(loginRequestDTO).ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    var _resp = response.Result;
                    var UserDetails = _resp;
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, _resp.User.Id.ToString()),
                        new Claim(ClaimTypes.Role, _resp.User.Role.Name)
                    };
                    //foreach (var item in result.ResponseData?.Roles.Claims)
                    //{
                    //    claims.Add(new Claim(item.ClaimType, item.ClaimValue));
                    //}

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimprincipal = new ClaimsPrincipal(claimsIdentity);

                    HttpContext.Session.SetString(Constants.JWT, response.Result.Token);
                    HttpContext.Session.SetString(Constants.USER, JsonSerializer.Serialize(response.Result.User));
                    await HttpContext.Session.CommitAsync().ConfigureAwait(false);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120),
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                         claimprincipal,
                        authProperties).ConfigureAwait(true);

                    Response.Cookies.Append(
                        CookieRequestCultureProvider.DefaultCookieName,
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("ENG")),
                        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
                    );
                    return Redirect("/Villa/Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Login", loginRequestDTO);
        }
        public async Task<IActionResult> ViewRegister(RegistrationRequestDTO registrationRequestDTO)
        {
            return View("Register", registrationRequestDTO);
        }
        public async Task<IActionResult> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            try
            {
                var response = await _sevices.RegisterAsync(registrationRequestDTO).ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    TempData["success"] = "User updated successfully.";
                }
                else
                {
                    TempData["error"] = "Error encountered.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Register", registrationRequestDTO);
        }
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                foreach (var cookie in siteCookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }
            //kill session
            HttpContext.Session.Clear();
            // kills the login cookie 
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
            return Redirect("/Role/Login");
        }
    }
}
