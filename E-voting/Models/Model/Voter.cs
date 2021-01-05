using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Voter")]
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }

        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]
        public string Name { get; set; }

        public int TC { get; set; }

        public string MobileNo { get; set; }
        
        //[DisplayName("deneme açıklama")]
        public string Email { get; set; }

        [Required, StringLength(100, ErrorMessage = "Can be up to 100 characters.")]
        public string Password { get; set; }

        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]
        public string City { get; set; }

        public ICollection<VoteCastingInfo> VoteCastingInfos { get; set; }

        public string Authority { get; set; }
    }
}