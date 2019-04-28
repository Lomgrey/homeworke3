using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModulSchool_HomeWork.Models
{
    public class User
    {
       public Guid Id { get; set; }
       
       [JsonProperty(PropertyName = "email")]
       public string Email { get; set; }
       
       [JsonProperty(PropertyName = "nickname")]
       public string Nickname { get; set; }
       
       [JsonProperty(PropertyName = "phone")]
       public string Phone { get; set; }
    }
}