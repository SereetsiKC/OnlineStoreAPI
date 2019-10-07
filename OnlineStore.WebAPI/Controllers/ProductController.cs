using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.DataObjects;
using OnlineStore.WebAPI.Services;

namespace OnlineStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IStoreService _service;

        public ProductController(IStoreService service)
        {
            _service = service;
        }


        [Route("GetQuickViewProduct"), HttpGet]
        public async Task<IActionResult> GetQuickViewProduct()
        {
            return Ok(await _service.GetQuickViewProduct());
        }

        [Route("GetAllProducts"), HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _service.GetAllProducts());
        }

        [Route("SaveProduct"), HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] tblProducts tblProducts)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult(BadRequest(ModelState));

            return Ok(await _service.SaveProduct(tblProducts));
        }
    }
}