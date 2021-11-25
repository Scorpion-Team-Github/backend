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
    [Route(ConstantHelper.API_PREFIX + "/news")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class NewsController : BaseController
    {
        private NeighlinkContext _context;

        public NewsController(NeighlinkContext context)
        {
            this._context = context;
        }

        private IQueryable<CondominiumNews> PrepareQuery() => _context.CondominiumNews
         .OrderBy(x => x.Id)
         .AsQueryable();

        [HttpGet]
        [ProducesResponseType(typeof(DefaultResponse<CollectionResponse<NewsResponse>>), StatusCodes.Status200OK)]
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
                    query = query.Where(x => x.Title.Contains(model.Name));

                var dtos = ServiceHelper.PaginarColeccion(HttpContext.Request, model.Page, model.Limit, query,
                  pagedEntities => NewsResponse.Builder.From(pagedEntities).BuildAll());

                return OkResult("", dtos);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DefaultResponse<NewsResponse>), StatusCodes.Status200OK)]
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
                var dto = NewsResponse.Builder.From(query).Build();
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
        public IActionResult Put(int id, [FromBody] NewsRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);
                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                var news = PrepareQuery().SingleOrDefault(x => x.Id == id);
                if (news is null)
                    return NotFoundResult("noticia no encontrado");

                transaction = _context.Database.BeginTransaction();

                news.Title = model.Title;
                news.Description = model.Description;
                news.UpdatedOn = DateTime.Now;
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == id);
                var dto = NewsResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(DefaultResponse<NewsResponse>), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] NewsRequest model)
        {
            try
            {
                var transaction = default(IDbContextTransaction);

                var userId = GetId(Request);
                var admin = _context.Administrators.SingleOrDefault(x => x.UserId == userId);
                if (admin is null)
                    return UnauthorizedResult("unathorized");

                transaction = _context.Database.BeginTransaction();

                var news = new CondominiumNews
                {
                    Title = model.Title,
                    Description = model.Description,
                    Status = true,
                    CreatedOn = DateTime.Now,
                };

                _context.CondominiumNews.Add(news);
                _context.SaveChanges();

                transaction.Commit();

                var query = PrepareQuery().SingleOrDefault(x => x.Id == news.Id);
                var dto = NewsResponse.Builder.From(query).Build();
                return OkResult("", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }
    }
}
