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
            var donations = db.Donations.Include(d => d.Charity);
            return View(donations.ToList());
        }

        // GET: Donations Parial Index

        public PartialViewResult PartialIndex(int id)
        {
            ViewBag.ID = id;
            var donations = from d in db.Donations select d;
            donations = donations.Include(d => d.Charity);
            donations = donations.Where(d => d.Charity.ID.Equals(id));
            donations = donations.OrderByDescending(d => d.Date);
            return PartialView(donations.ToList());
        }

        // GET: Donations/Create
        public PartialViewResult Create(bool isModal, int? id)
        {
            ViewBag.ID = id;
            ViewBag.CharityID = new SelectList(db.Charities.OrderBy(c => c.Name), "ID", "Name");
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName");
            return PartialView();

        }

        // POST: Donations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Amount,Note,Method,CharityID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Details", "Charities", new { id = donation.CharityID });
            }

            ViewBag.CharityID = new SelectList(db.Charities.OrderBy(c => c.Name), "ID", "Name", donation.CharityID);
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
            ViewBag.CharityID = new SelectList(db.Charities.OrderBy(c => c.Name), "ID", "Name", donation.CharityID);
            return View(donation);
        }

        // POST: Donations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Amount,Note,Method,CharityID,Charity")] Donation donation)
        {            
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("details","charities", new { id = donation.CharityID });
            }
            ViewBag.CharityID = new SelectList(db.Charities.OrderBy(c => c.Name), "ID", "Name", donation.CharityID);
            return View(donation);
        }

        // GET: AJAX Edit modal
        public ActionResult OpenEditModal(string id)
        {
            Donation donation = db.Donations.Find(int.Parse(id));
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharityID = new SelectList(db.Charities.OrderBy(c => c.Name), "ID", "Name", donation.CharityID);
            return PartialView("EditModal", donation);
        }

        // GET: AJAX Delete modal
        public ActionResult OpenDeleteModal(string id)
        {
            int Id = int.Parse(id);
            var donation = from d in db.Donations select d;
            donation = donation.Include(d => d.Charity);
            donation = donation.Where(d => d.ID.Equals(Id));
            var donationList = donation.ToList();           
            if (donation == null)
            {
                return HttpNotFound();
            }            
            return PartialView("DeleteModal", donationList.ElementAt(0));
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
            db.SaveChanges();            
            return RedirectToAction("Details","Charities",new { id = donation.CharityID });
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
