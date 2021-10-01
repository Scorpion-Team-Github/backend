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
    public class DoorResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("secret_code")]
        public string SecretCode { get; set; }
        [JsonPropertyName("creation_date")]
        public string CreationDate { get; set; }
        [JsonPropertyName("department")]
        public DepartmentResponse Department { get; set; }


        public class Builder
        {
            private DoorResponse dto;
            private List<DoorResponse> collection;

            public Builder()
            {
                this.dto = new DoorResponse();
                this.collection = new List<DoorResponse>();
            }
            public Builder(DoorResponse dto)
            {
                this.dto = dto;
                this.collection = new List<DoorResponse>();
            }
            public Builder(List<DoorResponse> collection)
            {
                this.dto = new DoorResponse();
                this.collection = collection;
            }

            public DoorResponse Build() => dto;
            public List<DoorResponse> BuildAll() => collection;

            public static Builder From(DepartmentDoors entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new DoorResponse();
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.SecretCode = entity.SecretCode;
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                if (entity.Department != null)
                    dto.Department = DepartmentResponse.Builder.From(entity.Department).Build();
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<DepartmentDoors> entities)
            {
                var collection = new List<DoorResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }
    }
}
