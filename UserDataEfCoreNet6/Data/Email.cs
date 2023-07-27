using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDataEfCoreNet6.Data
{
    public class Email
    {
        public int Id { get; set; }
        public string? EmailAddress { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}

