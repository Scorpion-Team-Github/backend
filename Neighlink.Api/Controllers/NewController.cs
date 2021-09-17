using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Entity.NewsModel;
using Neighlink.Service;
using Neighlink.Service.implementation;
using System;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class NewController : BaseController
    {
        private INewService _newService;
        public NewController()
        {
            _newService = new NewService( context );
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddNewsRequestModel model)
        {
            try
            {
                var news = new News()
                {
                    CreatedAt = today,
                    Status = model.Status,
                    UpdatedAt = today,
                    Title = model.Title,
                    Date = model.Date,
                    CondominiumId = model.CondominiumId,
                    Description = model.Description,
                };
                _newService.Add( news );
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
                var news = _newService.Get( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = news;
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
                var condominiums = _newService.GetAll();
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
        public ActionResult Put(int id, [FromBody] AddNewsRequestModel model)
        {
            try
            {
                var news = _newService.Get( id );
                news.CreatedAt = today;
                news.Status = model.Status;
                news.UpdatedAt = today;
                news.Title = model.Title;
                news.Date = model.Date;
                news.CondominiumId = model.CondominiumId;
                news.Description = model.Description;
                _newService.Update( news );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Noticia actualizado";
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
                _newService.Delete( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = "Noticia borrado";
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

        [HttpGet( "by-condominium/{condominiumId}" )]
        public ActionResult GetNews(int condominiumId)
        {
            try
            {
                var news = _newService.GetNewsByCondominium( condominiumId );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = news;
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