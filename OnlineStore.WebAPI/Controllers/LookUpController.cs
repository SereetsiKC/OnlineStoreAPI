using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.WebAPI.Services;

namespace OnlineStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpController : ControllerBase
    {
        public readonly IStoreService _service;

        public LookUpController(IStoreService service)
        {
            _service = service;
        }

        [Route("GetAllBrands"), HttpGet]
        public async Task<IActionResult> GetAllBrands() => Ok(await _service.GetAllBrands());

        [Route("GetAllCategories"), HttpGet]
        public async Task<IActionResult> GetAllCategories() => Ok(await _service.GetAllCategories());

        [Route("GetAllBrandsProducts"), HttpGet]
        public async Task<IActionResult> GetAllBrandsProducts() => Ok(await _service.GetAllBrandsProducts());

        [Route("GetAllCategoryBrands"), HttpGet]
        public async Task<IActionResult> GetAllCategoryBrands() => Ok(await _service.GetAllCategoryBrands());
    }
}