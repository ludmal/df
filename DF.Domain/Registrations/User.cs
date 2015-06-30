using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DF.Domain.Registrations
{
    [Table("User")]
    public class User
    {
        public string Email { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}