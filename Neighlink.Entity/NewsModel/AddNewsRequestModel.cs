using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Neighlink.Entity.NewsModel
{
    public class AddNewsRequestModel
    {
        [Required]
        [JsonProperty( "status" )]
        public bool Status { get; set; }
        [Required]
        [JsonProperty( "title" )]
        public string Title { get; set; } = string.Empty;
        [Required]
        [JsonProperty( "description" )]
        public string Description { get; set; } = string.Empty;
        [Required]
        [JsonProperty( "date" )]
        public DateTime Date { get; set; } 
        [Required]
        [JsonProperty( "condominium_id" )]
        public int CondominiumId { get; set; } 
    }
}
