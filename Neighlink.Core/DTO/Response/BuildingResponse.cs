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
    public class BuildingResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("number_homes")]
        public int NumHomes { get; set; }
        [JsonPropertyName("status")]
        public bool? Status { get; set; }
        [JsonPropertyName("creation_date")]
        public string CreationDate { get; set; }
        [JsonPropertyName("condominium")]
        public CondominiumResponse Condominium { get; set; }


        public class Builder
        {
            private BuildingResponse dto;
            private List<BuildingResponse> collection;

            public Builder()
            {
                this.dto = new BuildingResponse();
                this.collection = new List<BuildingResponse>();
            }
            public Builder(BuildingResponse dto)
            {
                this.dto = dto;
                this.collection = new List<BuildingResponse>();
            }
            public Builder(List<BuildingResponse> collection)
            {
                this.dto = new BuildingResponse();
                this.collection = collection;
            }

            public BuildingResponse Build() => dto;
            public List<BuildingResponse> BuildAll() => collection;

            public static Builder From(Buildings entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new BuildingResponse();
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.NumHomes = entity.NumberOfHomes;
                dto.Status = entity.Status;
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                dto.Condominium = CondominiumResponse.Builder.From(entity.Condominium).Build();
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<Buildings> entities)
            {
                var collection = new List<BuildingResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }
    }
}
