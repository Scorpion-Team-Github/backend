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
    public class CondominiumResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("creation_date")]
        public string CreationDate { get; set; }
        [JsonPropertyName("admin")]
        public UserResponse Admin { get; set; }
        [JsonPropertyName("status")]
        public bool? Status { get; set; }


        public class Builder
        {
            private CondominiumResponse dto;
            private List<CondominiumResponse> collection;

            public Builder()
            {
                this.dto = new CondominiumResponse();
                this.collection = new List<CondominiumResponse>();
            }
            public Builder(CondominiumResponse dto)
            {
                this.dto = dto;
                this.collection = new List<CondominiumResponse>();
            }
            public Builder(List<CondominiumResponse> collection)
            {
                this.dto = new CondominiumResponse();
                this.collection = collection;
            }

            public CondominiumResponse Build() => dto;
            public List<CondominiumResponse> BuildAll() => collection;

            public static Builder From(Condominiums entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new CondominiumResponse();
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.Address = entity.Address;
                dto.Description = entity.Description;
                if (entity.Administrator != null)
                    dto.Admin = UserResponse.Builder.From(entity.Administrator.User).Build();
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                dto.Status = entity.Status;
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<Condominiums> entities)
            {
                var collection = new List<CondominiumResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }
    }
}
