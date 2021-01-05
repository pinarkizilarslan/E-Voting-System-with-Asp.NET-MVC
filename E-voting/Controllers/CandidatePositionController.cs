using E_voting.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class CandidatePositionController : Controller
    {
        private EvotingDBContext db = new EvotingDBContext();
        // GET: CandidatePosition
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.CandidatePosition.Include("Candidate").ToList().OrderByDescending(x => x.CandidatePositionId));
            //return View(db.CandidatePosition.ToList());
        }
    }
}