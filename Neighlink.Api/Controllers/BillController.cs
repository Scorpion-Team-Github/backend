using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Entity.BillModel;
using Neighlink.Service;
using Neighlink.Service.implementation;
using System;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class BillController : BaseController
    {
        private IBillService _billService;

        public BillController()
        {
            _billService = new BillService( context );
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddBillRequestModel model)
        {
            try
            {
                var bill = new Bill()
                {
                    CreatedAt = today,
                    Status = model.Status,
                    UpdatedAt = today,
                    Name = model.Name,
                    Description = model.Description,
                    Amount = model.Amount,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PaymentCategoryId = model.PaymentCategoryId,
                    BuildingId = model.BuildingId,
                };
                _billService.Add( bill );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Pago agregado";
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }

        [HttpPut( "{id}" )]
        public ActionResult Put(int id, [FromBody] UpdateBillRequestModel model)
        {
            try
            {

                var bill = _billService.Get( id );
                bill.Status = model.Status;
                bill.UpdatedAt = today;
                bill.Name = model.Name;
                bill.Description = model.Description;
                bill.Amount = model.Amount;
                bill.StartDate = model.StartDate;
                bill.EndDate = model.EndDate;
                bill.PaymentCategoryId = model.PaymentCategoryId;
                bill.BuildingId = model.BuildingId;
                _billService.Update( bill );

                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Pago actualizado";
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }

        [HttpDelete( "{id}" )]
        public ActionResult Delete(int id)
        {
            try
            {
                _billService.Delete( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Pago eliminado";
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }

        [HttpGet( "by-paymentcategory/{PaymentCategoryId}" )]
        public ActionResult GetBillsByPaymentCategory(int PaymentCategoryId)
        {
            try
            {
                var bills = _billService.GetBillsByPaymentCategory( PaymentCategoryId );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "";
                response.Result = bills;
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }

        [HttpGet( "by-building/{BuildingId}" )]
        public ActionResult GetBillByBuilding(int BuildingId)
        {
            try
            {
                var bills = _billService.GetBillsByBuilding( BuildingId );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "";
                response.Result = bills;
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }

        [HttpGet( "by-condominium/{CondominiumId}" )]
        public ActionResult GetBillsByCondominium(int CondominiumId)
        {
            try
            {
                var bills = _billService.GetBillsByCondominium( CondominiumId );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "";
                response.Result = bills;
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }

        [HttpGet( "{id}" )]
        public ActionResult Get(int id)
        {
            try
            {
                var bill = _billService.Get( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "";
                response.Result = bill;
                return Ok( response );
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Status = "BAD REQUEST";
                response.Message = e.Message;
                return BadRequest( response );
            }
        }
    }
}