using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Entity.BuildingModel;
using Neighlink.Service;
using Neighlink.Service.implementation;
using System;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class BuildingController : BaseController
    {
        private IBuildingService _buildingService;

        public BuildingController()
        {
            _buildingService = new BuildingService( context );
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddCondominiumRequestModel model)
        {
            try
            {
                var building = new Building()
                {
                    CreatedAt = today,
                    Status = model.Status,
                    UpdatedAt = today,
                    Name = model.Name,
                    Description = model.Description,
                    NumberOfHomes = model.HomesNumber,
                    CondominiumId = model.CondominiumId
                };
                _buildingService.Add( building );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Edificio agregado";
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
        public ActionResult GetBuildings(int condominiumId)
        {
            try
            {
                var buildings = _buildingService.GetBuildingsByCondominium( condominiumId );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = buildings;
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
                var buildings = _buildingService.Get( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = buildings;
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
                var buildings = _buildingService.GetAll();
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = buildings;
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
        public ActionResult Put(int id, [FromBody] UpdateBuildingRequestModel model)
        {
            try
            {
                var building = _buildingService.Get( model.Id );
                building.Status = model.Status;
                building.UpdatedAt = today;
                building.Name = model.Name;
                building.Description = model.Description;
                building.NumberOfHomes = model.HomesNumber;
                building.CondominiumId = model.CondominiumId;
                _buildingService.Add( building );
                _buildingService.Update( building );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Message = "Edificio actualizado";
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
                _buildingService.Delete( id );
                response.StatusCode = StatusCodes.Status200OK;
                response.Status = "OK";
                response.Result = "Edificio borrado";
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