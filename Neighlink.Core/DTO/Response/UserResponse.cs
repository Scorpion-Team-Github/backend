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
    public class UserResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("creation_date")]
        public string CreationDate { get; set; }
        [JsonPropertyName("role")]
        public string Role{ get; set; }

        public class Builder
        {
            private UserResponse dto;
            private List<UserResponse> collection;

            public Builder()
            {
                this.dto = new UserResponse();
                this.collection = new List<UserResponse>();
            }
            public Builder(UserResponse dto)
            {
                this.dto = dto;
                this.collection = new List<UserResponse>();
            }
            public Builder(List<UserResponse> collection)
            {
                this.dto = new UserResponse();
                this.collection = collection;
            }

            public UserResponse Build() => dto;
            public List<UserResponse> BuildAll() => collection;

            public static Builder From(Users entity, string tipoConstructor = ConstantHelper.CONSTRUCTOR_DTO_SINGLE)
            {
                var dto = new UserResponse();
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.LastName = entity.LastName;
                dto.Email = entity.Email;
                dto.Gender = entity.Gender;
                dto.Phone = entity.PhoneNumber;
                dto.CreationDate = entity.CreatedOn?.ToString("dd/MM/yyyy HH:mm") ?? "";
                return new Builder(dto);
            }

            public static Builder From(IEnumerable<Users> entities)
            {
                var collection = new List<UserResponse>();

                foreach (var entity in entities)
                    collection.Add(From(entity, ConstantHelper.CONSTRUCTOR_DTO_LIST).Build());

                return new Builder(collection);
            }
        }
    }
}
