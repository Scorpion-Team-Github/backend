using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Neighlink.Core.DTO.Request
{
    public class BuildingRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("condominium_id")]
        public int CondominiumId { get; set; }

        [JsonPropertyName("num_homes")]
        public int NumHomes { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}
