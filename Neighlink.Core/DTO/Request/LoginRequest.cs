using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Neighlink.Core.DTO.Request
{
    public class LoginRequest
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("fcm_token")]
        public string FCMToken { get; set; }
    }
}
