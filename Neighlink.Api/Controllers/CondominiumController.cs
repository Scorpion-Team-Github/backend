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
    [Route(ConstantHelper.API_PREFIX + "/condominiums")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class CondominiumController : BaseController
    {
        private NeighlinkContext _context;

        public CondominiumController(NeighlinkContext context)
        {
            this._context = context;
        }

        private IQueryable<Condominiums> PrepareQuery() => _context.Condominiums
         .Include(x => x.Administrator)
            .ThenInclude(x => x.User)
         .OrderBy(x => x.Id)
         .AsQueryable();

        [HttpGet]
        [ProducesResponseType(typeof(DefaultResponse<CollectionResponse<CondominiumResponse>>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] CondominiumGetRequest model)
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
                  pagedEntities => CondominiumResponse.Builder.From(pagedEntities).BuildAll());

                return OkResult("", dtos);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<CondominiumResponse>), StatusCodes.Status200OK)]
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
                var dto = CondominiumResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<CondominiumResponse>), StatusCodes.Status200OK)]
        public IActionResult Put(int id, [FromBody] CondominiumRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);
                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                var condominium = PrepareQuery().SingleOrDefault(x => x.Id == id);
                if (condominium is null)
                    return NotFoundResult("condominio no encontrado");

                transaction = _context.Database.BeginTransaction();

                condominium.Name = model.Name;
                condominium.Description = model.Description;
                condominium.Address = model.Address;
                condominium.UpdatedOn = DateTime.Now;
                condominium.Status = model.Status;
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == id);
                var dto = CondominiumResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(DefaultResponse<CondominiumResponse>), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] CondominiumRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);

                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                transaction = _context.Database.BeginTransaction();


                var condominium = new Condominiums
                {
                    Name = model.Name.Trim(),
                    Description = model.Description.Trim(),
                    Address = model.Address.Trim(),
                    AdministratorId = admin.Id,
                    Status = model.Status,
                    NumberOfHomes = 0,
                    CreatedOn = DateTime.Now,
                };

                _context.Condominiums.Add(condominium);
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == condominium.Id);
                var dto = CondominiumResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }
    }
}
