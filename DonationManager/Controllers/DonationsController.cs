using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DonationManager.Data;
using DonationManager.Models;

namespace DonationManager.Controllers
{
    public class DonationsController : Controller
    {
        private DonationManagerContext db = new DonationManagerContext();

        // GET: Donations
        public ActionResult Index()
        {
            var donations = db.Donations.Include(d => d.Charity).Include(d => d.Person);
            return View(donations.ToList());
        }

        // GET: Donations Parial Index
        
        public PartialViewResult PartialIndex(int id)
        {
            var donations = from d in db.Donations select d;  
            donations = donations.Include(d => d.Charity).Include(d => d.Person);
            donations = donations.Where(d => d.Charity.ID.Equals(id));
            donations = donations.OrderByDescending(d => d.Date);               
            return PartialView(donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.CharityID = new SelectList(db.Charities, "ID", "Name");
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName");
            return View();

        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Amount,Note,Method,CharityID,PersonID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharityID = new SelectList(db.Charities, "ID", "Name", donation.CharityID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", donation.PersonID);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharityID = new SelectList(db.Charities, "ID", "Name", donation.CharityID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", donation.PersonID);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Amount,Note,Method,CharityID,PersonID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharityID = new SelectList(db.Charities, "ID", "Name", donation.CharityID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", donation.PersonID);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
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
