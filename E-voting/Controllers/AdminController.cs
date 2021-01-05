using E_voting.Models;
using E_voting.Models.DataContext;
using E_voting.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class AdminController : Controller
    {
        EvotingDBContext db = new EvotingDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.VoterCount = db.Voter.Count();
            ViewBag.ResultCount = db.Result.Count();
            ViewBag.PositionCount = db.Position.Count();
            ViewBag.CandidateCount = db.Candidate.Count();
            //ViewBag.VoterCount=db.Voter.Where(x=>x.VoterId).cou
            var sorgu = db.Voter.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Email == admin.Email).SingleOrDefault();
            if ((login.Email == admin.Email) && (login.Password == Crypto.Hash(admin.Password, "MD5")))
            {
                Session["adminid"] = login.AdminId;
                Session["email"] = login.Email;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Wrong password or name";
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["email"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult Admins()
        {
            return View(db.Admin.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin,string password,string email)
        {
            if(ModelState.IsValid)
            {
                admin.Password = Crypto.Hash(password,"MD5");
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Admins");
            }
            return View(admin);
        }
        public ActionResult Edit(int id)
        {
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(int id,Admin admin,string password, string email)
        {            
            if(ModelState.IsValid)
            {
                var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
                a.Password = Crypto.Hash(password, "MD5");
                a.Email = admin.Email;
                db.SaveChanges();
                return RedirectToAction("Admins");
            }
            return View(admin);
        }
        public ActionResult Delete(int id)
        {
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            if(a!=null)
            {
                db.Admin.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Admins");
            }
            return View();
        }
    }
}