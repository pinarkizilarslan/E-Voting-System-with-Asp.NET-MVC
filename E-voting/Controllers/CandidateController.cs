using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_voting.Models.DataContext;
using E_voting.Models.Model;

namespace E_voting.Controllers
{
    public class CandidateController : Controller
    {
        private EvotingDBContext db = new EvotingDBContext();

        // GET: Candidate
        public ActionResult Index()
        {
            return View(db.Candidate.ToList());
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidate/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "CandidateId,Name,TC,City,MobileNo,Email,PhotoPath")] Candidate candidate,HttpPostedFileBase PhotoPath)
        {
            if (ModelState.IsValid)
            {
                if (PhotoPath != null)
                {
                    WebImage img = new WebImage(PhotoPath.InputStream);
                    FileInfo imginfo = new FileInfo(PhotoPath.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(50, 50);
                    img.Save("~/Uploads/Candidate/" + logoname);

                    candidate.PhotoPath = "/Uploads/Candidate/" + logoname;
                }
                db.Candidate.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidate/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "CandidateId,Name,TC,City,MobileNo,Email,PhotoPath")] Candidate candidate, HttpPostedFileBase PhotoPath)
        {
            if (ModelState.IsValid)
            {
                var k = db.Candidate.Where(x => x.CandidateId == candidate.CandidateId).SingleOrDefault();

                if (PhotoPath != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.PhotoPath)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.PhotoPath));
                    }
                    WebImage img = new WebImage(PhotoPath.InputStream);
                    FileInfo imginfo = new FileInfo(PhotoPath.FileName);

                    string logoname = PhotoPath.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Candidate/" + logoname);

                    k.PhotoPath = "/Uploads/Candidate/" + logoname;
                }

                k.Name = candidate.Name;
                k.MobileNo = candidate.MobileNo;
                k.TC = candidate.TC;
                k.City = candidate.City;
                k.Email = candidate.Email;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidate.Find(id);
            db.Candidate.Remove(candidate);
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
