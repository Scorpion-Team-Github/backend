using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Neighlink.Entity.BillModel
{
    public class AddBillRequestModel
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
        [JsonProperty( "amount" )]
        public float Amount { get; set; } 
        [Required]
        [JsonProperty( "start_date" )]
        public DateTime StartDate { get; set; }
        [Required]
        [JsonProperty( "end_date" )]
        public DateTime EndDate { get; set; }
        [Required]
        [JsonProperty( "payment_category_id" )]
        public int PaymentCategoryId { get; set; }
        [Required]
        [JsonProperty( "building_id" )]
        public int BuildingId { get; set; }
        [Required]
        [JsonProperty( "condominium_id" )]
        public int CondominiumId { get; set; }
    }
}
