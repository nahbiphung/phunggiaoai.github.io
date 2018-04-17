﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLTV.DAL;
using WebQLTV.Models;

namespace WebQLTV.Controllers
{
    public class TacGiasController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: TacGias
        public ActionResult Index()
        {
            return View(db.TacGia.ToList());
        }

        // GET: TacGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGia.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // GET: TacGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TacGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTacGia,TenTacGia")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                db.TacGia.Add(tacGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tacGia);
        }

        // GET: TacGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGia.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // POST: TacGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTacGia,TenTacGia")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tacGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tacGia);
        }

        // GET: TacGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGia.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // POST: TacGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TacGia tacGia = db.TacGia.Find(id);
            db.TacGia.Remove(tacGia);
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
