using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserDataEfCoreNet6.Data
{
    public class Phone
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(UserId))]
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}

