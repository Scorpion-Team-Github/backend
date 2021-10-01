using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Neighlink.Core.DTO.Request;
using Neighlink.Core.DTO.Response;
using Neighlink.Core.Helpers;
using Neighlink.Data.Core.Neighlink;
using Neighlink.Data.Core.Neighlink.Entities;
using Neighlink.Helper;
using System;
using System.Linq;
using System.Net.Mime;

namespace Neighlink.API.Controllers
{
    [ApiController]
    [Route(ConstantHelper.API_PREFIX + "/buildings")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BuildingController : BaseController
    {
        private NeighlinkContext _context;

        public BuildingController(NeighlinkContext context)
        {
            this._context = context;
        }

        private IQueryable<Buildings> PrepareQuery() => _context.Buildings
         .Include(x => x.Condominium)
         .OrderBy(x => x.Id)
         .AsQueryable();

        [HttpGet]
        [ProducesResponseType(typeof(DefaultResponse<CollectionResponse<BuildingResponse>>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] BuildingGetRequest model)
        {
            try
            {
                var userId = GetId(Request);
                var user = _context.Users.SingleOrDefault(x => x.Id == userId);
                if (user is null)
                    return UnauthorizedResult("unathorized");

                var query = PrepareQuery();

                if (!string.IsNullOrEmpty(model.Name))
                    query = query.Where(x => x.Name.Contains(model.Name));

                var dtos = ServiceHelper.PaginarColeccion(HttpContext.Request, model.Page, model.Limit, query,
                  pagedEntities => BuildingResponse.Builder.From(pagedEntities).BuildAll());

                return OkResult("", dtos);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<BuildingResponse>), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            try
            {
                var userId = GetId(Request);
                var user = _context.Users.SingleOrDefault(x => x.Id == userId);
                if (user is null)
                    return UnauthorizedResult("unathorized");

                var query = PrepareQuery().SingleOrDefault(x => x.Id == id);
                if (query is null)
                    return NotFoundResult("Producto no encontrado.");
                var dto = BuildingResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<BuildingResponse>), StatusCodes.Status200OK)]
        public IActionResult Put(int id, [FromForm] BuildingRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);
                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                var building = PrepareQuery().SingleOrDefault(x => x.Id == id);
                if (building is null)
                    return NotFoundResult("edificio no encontrado");

                transaction = _context.Database.BeginTransaction();

                building.Name = model.Name;
                building.CondominiumId = model.CondominiumId;
                building.NumberOfHomes = model.NumHomes;
                building.UpdatedOn = DateTime.Now;
                building.Status = model.Status;
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == id);
                var dto = BuildingResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(DefaultResponse<BuildingResponse>), StatusCodes.Status200OK)]
        public IActionResult Post([FromForm] BuildingRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);

                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                transaction = _context.Database.BeginTransaction();


                var building = new Buildings
                {
                    Name = model.Name.Trim(),
                    CondominiumId = model.CondominiumId,
                    NumberOfHomes = model.NumHomes,
                    Status = model.Status,
                    CreatedOn = DateTime.Now,
                };

                _context.Buildings.Add(building);
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == building.Id);
                var dto = BuildingResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }
    }
}
