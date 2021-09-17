using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController:ControllerBase
    {
        private IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        //[HttpPost]
        //public ActionResult Post([FromBody] Payment payment)
        //{
        //    return Ok(paymentService.Save(payment));
        //}

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<Payment>> GetPaymentsByCondominium(int condominiumId)
        {
            return Ok(paymentService.GetPaymentsByCondominium(condominiumId));
        }

        [HttpGet("byId/{id}")]
        public ActionResult<Payment> Get(int id)
        {
            return Ok(paymentService.Get(id));
        }

        //[HttpPut]
        //public ActionResult Put([FromBody] Payment payment)
        //{
        //    return Ok(paymentService.Update(payment));
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    return Ok(paymentService.Delete(id));
        //}

        [HttpGet("by-bill/{billId}")]
        public ActionResult<IEnumerable<Payment>> GetPaymentsByBill(int billId)
        {
            return Ok(paymentService.GetPaymentsByBill(billId));
        }
                        
        [HttpGet("by-user/{userId}")]
        public ActionResult<IEnumerable<Payment>> GetPaymentsByUser(int userId)
        {
            return Ok(paymentService.GetPaymentsByUser(userId));
        }
    }
}