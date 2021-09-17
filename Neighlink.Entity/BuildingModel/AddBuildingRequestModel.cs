using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Neighlink.Entity.BuildingModel
{
    public class AddCondominiumRequestModel
    {
        [Required]
        [JsonProperty( "status" )]
        public bool Status { get; set; }
        [Required]
        [JsonProperty( "name" )]
        public string Name { get; set; } = string.Empty;
        [Required]
        [JsonProperty( "description" )]
        public string Description { get; set; } = string.Empty;
        [Required]
        [JsonProperty( "homes_number" )]
        public int HomesNumber { get; set; }
        [Required]
        [JsonProperty( "condominium_id" )]
        public int CondominiumId { get; set; }

    }
}
