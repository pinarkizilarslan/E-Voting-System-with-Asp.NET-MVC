using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required, StringLength(100, ErrorMessage = "Can be up to 100 characters.")]
        public string PositionName { get; set; }

        public ICollection<VoteCastingInfo> VoteCastingInfos { get; set; }

        public ICollection<CandidatePosition> CandidatePosition { get; set; }
    }
}