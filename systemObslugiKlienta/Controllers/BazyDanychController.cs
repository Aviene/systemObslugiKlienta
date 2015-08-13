using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using systemObslugiKlienta.Models;

namespace systemObslugiKlienta.Controllers
{
    public class BazyDanychController : Controller
    {
        private SystemObslugiKlientaContext db = new SystemObslugiKlientaContext();

        // GET: BazyDanych
        public ActionResult Index()
        {
            var bazyDanych = db.BazyDanych.Include(b => b.Uzytkownik);
            return View(bazyDanych.ToList());
        }

        // GET: BazyDanych/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BazaDanych bazaDanych = db.BazyDanych.Find(id);
            if (bazaDanych == null)
            {
                return HttpNotFound();
            }
            return View(bazaDanych);
        }

        // GET: BazyDanych/Create
        public ActionResult Create()
        {
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: BazyDanych/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPliku,NazwaPliku,TypZawartosci,Zawartosc,TypPliku,DataDodania,UzytkownikId")] BazaDanych bazaDanych)
        {
            if (ModelState.IsValid)
            {
                db.BazyDanych.Add(bazaDanych);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", bazaDanych.UzytkownikId);
            
            
            return View(bazaDanych);
        }

        // GET: BazyDanych/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BazaDanych bazaDanych = db.BazyDanych.Find(id);
            if (bazaDanych == null)
            {
                return HttpNotFound();
            }
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", bazaDanych.UzytkownikId);
            return View(bazaDanych);
        }

        // POST: BazyDanych/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPliku,NazwaPliku,TypZawartosci,Zawartosc,TypPliku,DataDodania,UzytkownikId")] BazaDanych bazaDanych)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bazaDanych).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", bazaDanych.UzytkownikId);
            return View(bazaDanych);
        }

        // GET: BazyDanych/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BazaDanych bazaDanych = db.BazyDanych.Find(id);
            if (bazaDanych == null)
            {
                return HttpNotFound();
            }
            return View(bazaDanych);
        }

        // POST: BazyDanych/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BazaDanych bazaDanych = db.BazyDanych.Find(id);
            db.BazyDanych.Remove(bazaDanych);
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
