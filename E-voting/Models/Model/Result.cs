using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int VoteCastingId { get; set; }

        public string CandidateId { get; set; }

        public string VoterId { get; set; }
    }
}