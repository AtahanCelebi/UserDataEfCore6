using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserDataEfCoreNet6.Data
{
    public class Email
    {
        public int Id { get; set; }
        public string? EmailAddress { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}

