using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neighlink.Core.DTO.Request;
using Neighlink.Core.DTO.Response;
using Neighlink.Data.Core.Neighlink;
using Neighlink.Data.Core.Neighlink.Entities;
using Neighlink.Helper;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Mime;

namespace Neighlink.API.Controllers
{
    [ApiController]
    [Route(ConstantHelper.API_PREFIX + "/auth")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    //[ProducesResponseType( typeof( DefaultResponse<object> ), StatusCodes.Status400BadRequest )]
    //[ProducesResponseType( typeof( DefaultResponse<object> ), StatusCodes.Status401Unauthorized )]
    //[ProducesResponseType( typeof( DefaultResponse<object> ), StatusCodes.Status403Forbidden )]
    //[ProducesResponseType( typeof( DefaultResponse<object> ), StatusCodes.Status500InternalServerError )]
    public class AuthController : BaseController
    {
        private NeighlinkContext _context;

        public AuthController(NeighlinkContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(DefaultResponse<UserResponse>), StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            try
            {
                var user = _context.Residents.Include(x => x.User)
                    .SingleOrDefault(x => x.Username == model.User);

                var admin = _context.Administrators.Include(x => x.User)
                   .SingleOrDefault(x => x.Username == model.User);

                if (user is null && admin is null)
                    return UnauthorizedResult("usuario y/o contraseña invalido.");

                var encryptPass = SecurityHelper.EncryptText(model.Password);
                if (admin is null)
                {
                    if (user.Password != encryptPass)
                        return UnauthorizedResult("usuario o contraseña invalido.");
                }
                else
                {
                    if (admin.Password != encryptPass)
                        return UnauthorizedResult("usuario o contraseña invalido.");
                }

                //if (!string.IsNullOrEmpty(model.FCMToken))
                //{
                //    user.Fcmtoken = model.FCMToken;
                //    storeContext.SaveChanges();
                //}

                var dto = UserResponse.Builder.From(user.User).Build();
                dto.Token = TokenHelper.GenerateJwtToken(dto.Id.ToString());
                dto.Role = admin is null ? ConstantHelper.Role.RESIDENT : ConstantHelper.Role.ADMIN;
                return OkResult("Success", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

        [HttpPost]
        [Route("sign-up")]
        [ProducesResponseType(typeof(DefaultResponse<UserResponse>), StatusCodes.Status200OK)]
        public IActionResult Register([FromBody] RegisterRequest model)
        {
            try
            {
                var user = _context.Users
                    .SingleOrDefault(x => x.Email == model.Email);
                if (user != null)
                    return UnauthorizedResult("El correo ya se encuentra registrado en el sistema.");

                user = _context.Users
                    .SingleOrDefault(x => x.PhoneNumber == model.Phone);
                if (user != null)
                    return UnauthorizedResult("El telefono ya se encuentra registrado en el sistema.");

                var newUser = new Users
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    Gender = model.Gender,
                    PhoneNumber = model.Phone,
                    Birthdate = DateTime.ParseExact(model.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = true
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                var admin = new Administrators
                {
                    UserId = newUser.Id,
                    Username = model.User,
                    Password = SecurityHelper.EncryptText(model.Password),
                    CreatedOn = DateTime.Now,
                    Status = true
                };

                _context.Administrators.Add(admin);
                _context.SaveChanges();

                var dto = UserResponse.Builder.From(newUser).Build();
                dto.Role = ConstantHelper.Role.ADMIN;
                return OkResult("Success", dto);
            }
            catch (Exception e)
            {
                return BadRequestResult(e.Message);
            }
        }

    }
}
