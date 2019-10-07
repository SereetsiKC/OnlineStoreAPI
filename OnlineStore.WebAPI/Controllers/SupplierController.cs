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
    public class SupplierController : ControllerBase
    {
        public readonly IStoreService _service;

        public SupplierController(IStoreService service)
        {
            _service = service;
        }

        [Route("GetAllSuppliers"), HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            return Ok(await _service.GetAllSuppliers());
        }

        [Route("SaveSupplier"), HttpPost]
        public async Task<IActionResult> SaveSupplier([FromBody] tblSupplier tblSupplier)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult(BadRequest(ModelState));

            return Ok(await _service.SaveSupplier(tblSupplier));
        }
    }
}