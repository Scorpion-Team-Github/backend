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

        //[HttpPost]
        //[Route("login")]
        //[ProducesResponseType(typeof(DefaultResponse<UserResponse>), StatusCodes.Status200OK)]
        //public IActionResult Login([FromBody] LoginRequest model)
        //{
        //    try
        //    {
        //        var user = storeContext.User
        //            .SingleOrDefault(x => x.Code == model.User);
        //        if (user is null)
        //            return UnauthorizedResult("Correo o contraseña invalido.");
        //        var encryptPass = SecurityHelper.EncryptText(model.Password);
        //        if (user.Password != encryptPass)
        //            return UnauthorizedResult("Correo o contraseña invalido.");

        //        if (!string.IsNullOrEmpty(model.FCMToken))
        //        {
        //            user.Fcmtoken = model.FCMToken;
        //            storeContext.SaveChanges();
        //        }

        //        var dto = UserResponse.Builder.From(user).Build();
        //        dto.Token = TokenHelper.GenerateJwtToken(dto.Id.ToString());
        //        return OkResult("Success", dto);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequestResult(e.Message);
        //    }
        //}

    }
}
