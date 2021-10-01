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
    [Route(ConstantHelper.API_PREFIX + "/departments")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class DepartmentController : BaseController
    {
        private NeighlinkContext _context;

        public DepartmentController(NeighlinkContext context)
        {
            this._context = context;
        }

        private IQueryable<Departments> PrepareQuery() => _context.Departments
         .Include(x => x.DepartmentBills)
         .Include(x => x.ResidentDepartments)
         .Include(x => x.Building)
              .ThenInclude(x => x.Condominium)
         .OrderBy(x => x.Id)
         .AsQueryable();

        [HttpGet]
        [ProducesResponseType(typeof(DefaultResponse<CollectionResponse<DepartmentResponse>>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] DepartmentGetRequest model)
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
                  pagedEntities => DepartmentResponse.Builder.From(pagedEntities).BuildAll());

                return OkResult("", dtos);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<DepartmentResponse>), StatusCodes.Status200OK)]
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
                var dto = DepartmentResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<DepartmentResponse>), StatusCodes.Status200OK)]
        public IActionResult Put(int id, [FromForm] DepartmentRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);
                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                var department = PrepareQuery().SingleOrDefault(x => x.Id == id);
                if (department is null)
                    return NotFoundResult("departamento no encontrado");

                transaction = _context.Database.BeginTransaction();

                department.Name = model.Name;
                department.BuildingId = model.BuildingId;
                department.SecretCode = model.SecretCode;
                department.Status = model.Status;
                department.UpdatedOn = DateTime.Now;
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == id);
                var dto = DepartmentResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(DefaultResponse<DepartmentResponse>), StatusCodes.Status200OK)]
        public IActionResult Post([FromForm] DepartmentRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);

                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                transaction = _context.Database.BeginTransaction();


                var deparment = new Departments
                {
                    Name = model.Name.Trim(),
                    BuildingId = model.BuildingId,
                    SecretCode = model.SecretCode,
                    Status = model.Status,
                    CreatedOn = DateTime.Now,
                };

                _context.Departments.Add(deparment);
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == deparment.Id);
                var dto = DepartmentResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }
    }
}
