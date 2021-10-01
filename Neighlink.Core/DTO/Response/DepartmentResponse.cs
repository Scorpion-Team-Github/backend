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
    public class DepartmentResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("secret_code")]
        public string SecretCode { get; set; }
        [JsonPropertyName("creation_date")]
        public string CreationDate { get; set; }
        [JsonPropertyName("building")]
        public BuildingResponse Building { get; set; }


        public class Builder
        {
            private DepartmentResponse dto;
            private List<DepartmentResponse> collection;

            public Builder()
            {
                this.dto = new DepartmentResponse();
                this.collection = new List<DepartmentResponse>();
            }
            public Builder(DepartmentResponse dto)
            {
                this.dto = dto;
                this.collection = new List<DepartmentResponse>();
            }
            public Builder(List<DepartmentResponse> collection)
            {
                this.dto = new DepartmentResponse();
                this.collection = collection;
            }

            public DepartmentResponse Build() => dto;
            public List<DepartmentResponse> BuildAll() => collection;

            public static Builder From(Departments entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new DepartmentResponse();
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.SecretCode = entity.SecretCode;
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                dto.Building = BuildingResponse.Builder.From(entity.Building).Build();
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<Departments> entities)
            {
                var collection = new List<DepartmentResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }

    }
}
