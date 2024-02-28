using MagicVillaAPI.Logger;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly ILogging _logging;
        private readonly VillaNumberService _villaNumberService;

        public VillaNumberController(ILogging logging, VillaNumberService villaNumberService)
        {
            _logging = logging;
            _villaNumberService = villaNumberService;
        }
    }
}
