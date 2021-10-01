using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Core.DTO.Request;
using Neighlink.Core.DTO.Response;
using Neighlink.Data.Core.Neighlink;
using Neighlink.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

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
        private NeighlinkContext storeContext;

        public AuthController(NeighlinkContext goingToContext)
        {
            this.storeContext = goingToContext;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(DefaultResponse<UserResponse>), StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            try
            {
                var user = storeContext.Residents
                    .SingleOrDefault(x => x.Username == model.User);

                var admin = storeContext.Administrators
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
                var user = storeContext.Users
                    .SingleOrDefault(x => x.Email == model.Email);
                if (user != null)
                    return UnauthorizedResult("El correo ya se encuentra registrado en el sistema.");

                user = storeContext.Users
                    .SingleOrDefault(x => x.PhoneNumber == model.Phone);
                if (user != null)
                    return UnauthorizedResult("El telefono ya se encuentra registrado en el sistema.");

                var admin = storeContext.Administrators
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

    }
}
