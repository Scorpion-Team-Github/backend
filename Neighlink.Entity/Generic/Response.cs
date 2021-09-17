using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Entity.Generic
{
    public class Response
    {
        [JsonProperty( "statusCode" )]
        public int StatusCode { get; set; }

        [JsonProperty( "status" )]
        public string Status { get; set; } = string.Empty;

        [JsonProperty( "message" )]
        public string Message { get; set; } = string.Empty;

        [JsonProperty( "result" )]
        public object Result { get; set; }
    }
}
