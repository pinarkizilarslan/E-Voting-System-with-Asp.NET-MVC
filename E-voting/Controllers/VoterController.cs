using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_voting.Models.DataContext;
using E_voting.Models.Model;

namespace E_voting.Controllers
{
    public class VoterController : Controller
    {
        private EvotingDBContext db = new EvotingDBContext();

        // GET: Voter
        public ActionResult Index()
        {
            return View(db.Voter.ToList());
        }

        // GET: Voter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voter.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // GET: Voter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string password,[Bind(Include = "VoterId,Name,TC,MobileNo,Email,Password,City")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                voter.Password = Crypto.Hash(password, "MD5");
                db.Voter.Add(voter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voter);
        }

        // GET: Voter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voter.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }


        // POST: Voter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string password,[Bind(Include = "VoterId,Name,TC,MobileNo,Email,Password,City")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                voter.Password = Crypto.Hash(password, "MD5");
                db.Entry(voter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voter);
        }

        // GET: Voter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voter.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voter voter = db.Voter.Find(id);
            db.Voter.Remove(voter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
