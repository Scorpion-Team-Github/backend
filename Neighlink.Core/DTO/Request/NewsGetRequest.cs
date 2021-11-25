using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neighlink.Core.DTO.Request
{
    public class NewsGetRequest : BaseGetRequest
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }
    }
}
