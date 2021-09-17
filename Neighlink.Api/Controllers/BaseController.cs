using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity.Generic;
using Neighlink.Repository.Context;

namespace Neighlink.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ApplicationDbContext context = new ApplicationDbContext();
        protected DateTime today = DateTime.Now.Date;
        protected Response response = new Response();
    }
}
