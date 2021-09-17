using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Api.Contracts;
using Neighlink.Entity;
using Neighlink.Repository.Utilities;
using Neighlink.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IBuildingService buildingService;

        public UserController(IUserService userService, IBuildingService buildingService)
        {
            this.userService = userService;
            this.buildingService = buildingService;
        }

        [AllowAnonymous]
        [HttpPost( "login" )]
        public IActionResult Authenticate([FromBody] LoginRequest loginRequest)
        {
            User user = userService.Authenticate( loginRequest.Email, loginRequest.Password );

            if (user == null)
                return BadRequest( new { message = "Username or password is incorrect" } );

            if (!userService.UserBelongsToCondominium( user, loginRequest.CondominiumId ))
                return Ok( "El usuario no pertenece a este condominio" );

            return Ok( user );
        }

        [HttpPost( "signup" )]
        public ActionResult Signup([FromBody] RegisterUserRequest request)
        {
            byte[] salt = CustomLoginProviderUtils.GenerateSalt();

            User user = new User()
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Salt = salt,
                SaltedAndHashedPassword = CustomLoginProviderUtils.Hash( request.Password, salt ),
                Role = request.Role,
                CondominiumId = request.CondominiumId
            };

            bool saveUser = false;

            if (request.Role == Entity.Entity.Role.Administrator)
            {
                saveUser = userService.RegisterAdmin( user, request.CondominiumId );
            }

            if (request.BuildingId > 0)
            {
                saveUser = userService.RegisterOwner( user, request.BuildingId );
            }

            return Ok( saveUser );
        }

        [HttpPost]
        public ActionResult SaveUser([FromBody] RegisterUserRequest request)
        {
            byte[] salt = CustomLoginProviderUtils.GenerateSalt();

            User user = new User()
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Salt = salt,
                SaltedAndHashedPassword = CustomLoginProviderUtils.Hash( request.Password, salt ),
                Role = request.Role,
                CondominiumId = request.CondominiumId
            };

            bool saveUser = false;

            if (request.Role == Entity.Entity.Role.Administrator)
            {
                saveUser = userService.RegisterAdmin( user, request.CondominiumId );
            }

            if (request.Role == Entity.Entity.Role.Owner)
            {
                user.HouseNumber = request.HouseNumber;
                saveUser = userService.RegisterOwner( user, request.BuildingId );
            }

            return Ok( saveUser );
        }

        [HttpGet( "by-condominium/{condominiumId}" )]
        public ActionResult<IEnumerable<User>> GetUsers(int condominiumId)
        {
            return Ok( userService.GetUsersByCondominium( condominiumId ) );
        }

        [HttpGet( "{id}" )]
        public ActionResult<User> Get(int id)
        {
            return Ok( userService.Get( id ) );
        }

        [HttpPut]
        public ActionResult Put([FromBody] User user)
        {
            userService.Update( user );
            return Ok( true );
        }

        [HttpDelete( "{id}" )]
        public ActionResult Delete(int id)
        {
            userService.Delete( id );
            return Ok( true );
        }
    }
}
