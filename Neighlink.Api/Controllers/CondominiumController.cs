using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Api.Contracts;
using Neighlink.Entity;
using Neighlink.Entity.CondominiumModel;
using Neighlink.Repository.Utilities;
using Neighlink.Service;
using Neighlink.Service.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CondominiumController : BaseController
    {
        private ICondominiumService _condominiumService;

        public CondominiumController()
        {
            _condominiumService = new CondominiumService( context );
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddCondominiumRequestModel model)
        {
            try
            {
                var condominium = new Condominium()
                {
                    CreatedAt = today,
                    Status = model.Status,
                    UpdatedAt = today,
                    Name = model.Name,
                    Address = model.Address,
                    PhotoUrl = model.PhotoUrl,
                    SecretCode = model.SecretCode,
                };
                _condominiumService.Add( condominium );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Condominio agregado";
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
                var condominium = _condominiumService.Get( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = condominium;
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

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var condominiums = _condominiumService.GetAll();
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = condominiums;
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
        public ActionResult Put(int id, [FromBody] AddCondominiumRequestModel model)
        {
            try
            {
                var condominium = _condominiumService.Get( id );
                condominium.Status = model.Status;
                condominium.UpdatedAt = today;
                condominium.Name = model.Name;
                condominium.Address = model.Address;
                condominium.PhotoUrl = model.PhotoUrl;
                condominium.SecretCode = model.SecretCode;
                _condominiumService.Update( condominium );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Condominio actualizado";
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
                _condominiumService.Delete( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Condominio borrado";
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
