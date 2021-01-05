using E_voting.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class VoteCastingInfoController : Controller
    {
        private EvotingDBContext db = new EvotingDBContext();
        // GET: VoteCastingInfo
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.VoteCastingInfo.Include("Voter").ToList().OrderByDescending(x=>x.VoteCastingId));
        }
    }
}