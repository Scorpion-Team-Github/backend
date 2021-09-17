using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Neighlink.Entity.CondominiumModel
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
        [JsonProperty( "address" )]
        public string Address { get; set; } = string.Empty;
        [Required]
        [JsonProperty( "photo_url" )]
        public string PhotoUrl { get; set; } = string.Empty;
        [Required]
        [JsonProperty( "secret_code" )]
        public string SecretCode { get; set; }
    }
}
