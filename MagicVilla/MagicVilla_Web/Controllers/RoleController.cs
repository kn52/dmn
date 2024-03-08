using MagicVilla_Uitility;
using MagicVilla_Web.HttpExtensions;
using MagicVillaServiceJ;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly MagicVillaServiceJClient service;
        private readonly HttpManager httpManager;

        public RoleController(MagicVillaServiceJClient service, HttpManager httpManager)
        {
            this.service = service;
            this.httpManager = httpManager;
        }

        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString(Constants.JWT) == null)
            {
                return Redirect("/User/ViewLogin");
            }
            List<UserRoleDTO> roles = new();
            try
            {
                var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
                service.AddToken(token);
                var response = await service.GetAllRolesAsync().ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    roles = response.Result.ToList();
                }
                else
                {
                    TempData["error"] = "Error encountered.";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Index", roles);
        }

        public async Task<ActionResult> ViewCreate(UserRoleDTO userRoleDTO)
        {
            return View("Create", userRoleDTO);
        }

        public async Task<ActionResult> Create(UserRoleDTO userRoleDTO)
        {
            try
            {
                var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
                service.AddToken(token);
                var response = await service.CreateRoleAsync(userRoleDTO).ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    TempData["success"] = "Role created successfully.";
                    return Redirect("/Role/Index");
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
            return View("Create", userRoleDTO);
        }

        public async Task<ActionResult> ViewUpdate(UserRoleDTO userRoleDTO)
        {
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            service.AddToken(token);
            var response = await service.GetRoleByIdAsync(userRoleDTO.Id).ConfigureAwait(false);
            if (response != null && response.Result != null)
            {
                userRoleDTO.Id = response.Result.Id;
                userRoleDTO.Name = response.Result.Name;
                userRoleDTO.CreatedBy = response.Result.CreatedBy;
            }
            return View("Update", userRoleDTO);
        }
        public async Task<ActionResult> Update(UserRoleDTO userRoleDTO)
        {
            try
            {

                var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
                service.AddToken(token);
                var response = await service.UpdateRoleAsync(userRoleDTO).ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    TempData["success"] = "Role updated successfully.";
                    return Redirect("/Role/Index");
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

            return View("Update", userRoleDTO);
        }

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
                service.AddToken(token);
                var response = await service.DeleteRoleAsync(id).ConfigureAwait(false);
                if (response != null && response.Result != null)
                {
                    TempData["success"] = "Role deleted successfully.";
                    return RedirectToAction("/Role/Index");
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

            return View();
        }
    }
}
