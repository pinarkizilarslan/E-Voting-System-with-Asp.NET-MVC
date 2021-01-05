using E_voting.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_voting.Models.DataContext
{
    public class EvotingDBContext:DbContext
    {
        public EvotingDBContext():base("EvotingDB")
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CandidatePosition> CandidatePosition { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<VoteCastingInfo> VoteCastingInfo { get; set; }
        public DbSet<Voter> Voter { get; set; }
        public DbSet<Result> Result { get; set; }
    }
}