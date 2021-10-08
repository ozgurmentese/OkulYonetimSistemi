using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgretmenlerController : ControllerBase
    {
        private readonly IOgretmenService _ogretmenService;

        public OgretmenlerController(IOgretmenService ogretmenService)
        {
            _ogretmenService = ogretmenService;
        }

        [HttpGet("ogretmenogrencisayisi")]
        public IActionResult OgretmenOgrenciSayisi()
        {
            var result = _ogretmenService.OgretmenOgrenciSayisi();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
