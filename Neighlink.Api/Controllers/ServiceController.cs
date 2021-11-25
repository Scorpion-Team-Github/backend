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
    [Route(ConstantHelper.API_PREFIX + "/services")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class ServiceController : BaseController
    {
        private NeighlinkContext _context;

        public ServiceController(NeighlinkContext context)
        {
            this._context = context;
        }

        private IQueryable<DepartmentBills> PrepareQuery() => _context.DepartmentBills
            .Include(x => x.PaymentCategory)
            .OrderBy(x => x.Id)
            .AsQueryable();

        [HttpGet]
        [ProducesResponseType(typeof(DefaultResponse<CollectionResponse<BillResponse>>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] NewsGetRequest model)
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
                  pagedEntities => BillResponse.Builder.From(pagedEntities).BuildAll());

                return OkResult("", dtos);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<BillResponse>), StatusCodes.Status200OK)]
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
                var dto = BillResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<BillResponse>), StatusCodes.Status200OK)]
        public IActionResult Put(int id, [FromBody] ServiceRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);
                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                var service = PrepareQuery().SingleOrDefault(x => x.Id == id);
                if (service is null)
                    return NotFoundResult("servicio no encontrado");

                transaction = _context.Database.BeginTransaction();

                service.Name = model.Name;
                service.Description = model.Description;
                service.StartDate = DateTime.ParseExact(model.StartDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                service.EndDate = DateTime.ParseExact(model.EndDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                service.UpdatedOn = DateTime.Now;
                service.Amount = model.Amount;
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == id);
                var dto = BillResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(DefaultResponse<BillResponse>), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] ServiceRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);

                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                transaction = _context.Database.BeginTransaction();

                var service = new DepartmentBills
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = DateTime.ParseExact(model.StartDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(model.EndDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Amount = model.Amount,
                    DepartmentId = model.Department,
                    PaymentCategoryId = model.Category,
                    Status = true,
                    CreatedOn = DateTime.Now,
                };

                _context.DepartmentBills.Add(service);
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == service.Id);
                var dto = BillResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }
    }
}
