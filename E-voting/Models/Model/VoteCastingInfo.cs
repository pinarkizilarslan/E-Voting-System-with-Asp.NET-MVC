using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("VoteCastingInfo")]
    public class VoteCastingInfo
    {
        [Key]
        public int VoteCastingId { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public int? CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int? VoterId { get; set; }
        public Voter Voter { get; set; }
    }
}