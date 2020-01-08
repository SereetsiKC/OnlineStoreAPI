using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.DataObjects;
using OnlineStore.WebAPI.Services;
using Hangfire;
using Hangfire.Server;

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
        public async Task<IActionResult> GetQuickViewProduct() => Ok(await _service.GetQuickViewProduct());

        [Route("GetAllProducts"), HttpGet]
        public async Task<IActionResult> GetAllProducts() => Ok(await _service.GetAllProducts());

        [Route("SaveProduct"), HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] tblProducts tblProducts)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult(BadRequest(ModelState));
            BackgroundJob.Enqueue(() => _service.SaveProduct(tblProducts));
            //BackgroundJob.Schedule(() => _service.SaveProduct(tblProducts), DateTime.Now.AddMinutes(30));
            //RecurringJob.AddOrUpdate("parent_id", () => _service.SaveProduct(tblProducts), Cron.Minutely());

            return Ok();
        }

        private void ParentFunc(PerformContext context)
        {
            // do all prerequisites before running child job(s),
            // then enqueue one or more continuations:
            //BackgroundJob.ContinueWith(context.BackgroundJob.Id, () => );
        }
    }
}