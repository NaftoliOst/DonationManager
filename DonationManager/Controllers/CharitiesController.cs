﻿using System;
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
    public class CharitiesController : Controller
    {
        private DonationManagerContext db = new DonationManagerContext();

        // GET: Charities
        public ActionResult Index()
        {
            return View(db.Charities.ToList());
        }

        // GET: Charities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return HttpNotFound();
            }
            return View(charity);
        }

        // GET: Charities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Charities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,OfficialName,PreferredMethod,Details,Type,Notes")] Charity charity)
        {
            if (ModelState.IsValid)
            {
                db.Charities.Add(charity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(charity);
        }

        // GET: Charities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return HttpNotFound();
            }
            return View(charity);
        }

        // POST: Charities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,OfficialName,PreferredMethod,Details,Type,Notes")] Charity charity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charity);
        }

        // GET: Charities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return HttpNotFound();
            }
            return View(charity);
        }

        // POST: Charities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Charity charity = db.Charities.Find(id);
            db.Charities.Remove(charity);
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