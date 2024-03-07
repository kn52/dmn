using MagicVillaServiceJ;
using Microsoft.AspNetCore.Mvc;
using MagicVillaServiceJ;

namespace MagicVilla_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly MagicVillaServiceJClient _sevices;

        public UserController(MagicVillaServiceJClient sevices)
        {
            _sevices = sevices;
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
                    TempData["success"] = "Villa updated successfully.";
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
    }
}
