using Neighlink.Data.Core.Neighlink.Entities;
using Neighlink.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Neighlink.Core.DTO.Response
{
    public class BillResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }
        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }
        [JsonPropertyName("department")]
        public DepartmentResponse Department { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("created_date")]
        public string CreationDate { get; set; }
        [JsonPropertyName("status")]
        public bool? Status { get; set; }


        public class Builder
        {
            private BillResponse dto;
            private List<BillResponse> collection;

            public Builder()
            {
                this.dto = new BillResponse();
                this.collection = new List<BillResponse>();
            }
            public Builder(BillResponse dto)
            {
                this.dto = dto;
                this.collection = new List<BillResponse>();
            }
            public Builder(List<BillResponse> collection)
            {
                this.dto = new BillResponse();
                this.collection = collection;
            }

            public BillResponse Build() => dto;
            public List<BillResponse> BuildAll() => collection;

            public static Builder From(DepartmentBills entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new BillResponse();
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.Description = entity.Description;
                dto.Status = entity.Status;
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                dto.StartDate = entity.StartDate?.ToString("dd/MM/yyyy HH:mm") ?? "";
                dto.EndDate = entity.EndDate?.ToString("dd/MM/yyyy HH:mm") ?? "";
                dto.Category = entity.PaymentCategory.Name;
                if (entity.Department != null)
                    dto.Department = DepartmentResponse.Builder.From(entity.Department).Build();
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<DepartmentBills> entities)
            {
                var collection = new List<BillResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }
    }
}
