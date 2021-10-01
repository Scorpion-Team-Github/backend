using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neighlink.Core.DTO.Request
{
    public class DoorGetRequest : BaseGetRequest
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }
        [FromQuery(Name = "secret_code")]
        public string SecretCode { get; set; }
    }
}
