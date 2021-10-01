using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Neighlink.Core.DTO.Request
{
    public class DoorRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("department_id")]
        public int DepartmentId { get; set; }

        [JsonPropertyName("secret_code")]
        public string SecretCode { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}
