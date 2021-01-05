using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]
        public string Name { get; set; }

        public int TC { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        [Required, StringLength(100, ErrorMessage = "Can be up to 100 characters.")]
        public string Password { get; set; }
    }
}