using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Candidate")]
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        
        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]
        public string Name { get; set; }

        public string TC { get; set; }

        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]
        public string City { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        [Required, StringLength(250, ErrorMessage = "Can be up to 250 characters.")]
        [DisplayName("Photo")]
        public string PhotoPath { get; set; }

        public ICollection<VoteCastingInfo> VoteCastingInfos { get; set; }

        public ICollection<CandidatePosition> CandidatePosition { get; set; }
    }
}