using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCategoryController : ControllerBase
    {
        
    private IPaymentCategoryService paymentCategoryService;
    public PaymentCategoryController(IPaymentCategoryService paymentCategoryService)
    {
        this.paymentCategoryService = paymentCategoryService;
    }

        //[HttpGet]
        //public ActionResult Get()
        //{
        //    return Ok(
        //        paymentCategoryService.GetAll()
        //    );
        //}

        //[HttpPost]
        //public ActionResult Post([FromBody] PaymentCategory paymentCategory)
        //{
        //    return Ok(
        //        paymentCategoryService.Save(paymentCategory)
        //    );
        //}

        //[HttpPut]
        //public ActionResult Put([FromBody] PaymentCategory paymentCategory)
        //{
        //    return Ok(
        //        paymentCategoryService.Update(paymentCategory)
        //    );
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    return Ok(
        //        paymentCategoryService.Delete(id)
        //    );
        //}

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<User>> GetBuildings(int condominiumId)
        {
            return Ok(paymentCategoryService.GetBuildingsByCondominium(condominiumId));
        }
    }
}