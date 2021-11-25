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
    public class NewsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("status")]
        public bool? Status { get; set; }
        [JsonPropertyName("creation_date")]
        public string CreationDate { get; set; }

        public class Builder
        {
            private NewsResponse dto;
            private List<NewsResponse> collection;

            public Builder()
            {
                this.dto = new NewsResponse();
                this.collection = new List<NewsResponse>();
            }
            public Builder(NewsResponse dto)
            {
                this.dto = dto;
                this.collection = new List<NewsResponse>();
            }
            public Builder(List<NewsResponse> collection)
            {
                this.dto = new NewsResponse();
                this.collection = collection;
            }

            public NewsResponse Build() => dto;
            public List<NewsResponse> BuildAll() => collection;

            public static Builder From(CondominiumNews entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new NewsResponse();
                dto.Id = entity.Id;
                dto.Title = entity.Title;
                dto.Description = entity.Description;
                dto.Status = entity.Status;
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<CondominiumNews> entities)
            {
                var collection = new List<NewsResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }
    }
}
