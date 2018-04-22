﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    public class ThamSoesController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: ThamSoes
        public ActionResult Index()
        {
            return View(db.ThamSoes.ToList());
        }

        // GET: ThamSoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamSo thamSo = db.ThamSoes.Find(id);
            if (thamSo == null)
            {
                return HttpNotFound();
            }
            return View(thamSo);
        }

        // GET: ThamSoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThamSoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThamSo,TenThamSo,GhiChu")] ThamSo thamSo)
        {
            if (ModelState.IsValid)
            {
                db.ThamSoes.Add(thamSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thamSo);
        }

        // GET: ThamSoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamSo thamSo = db.ThamSoes.Find(id);
            if (thamSo == null)
            {
                return HttpNotFound();
            }
            return View(thamSo);
        }

        // POST: ThamSoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThamSo,TenThamSo,GhiChu")] ThamSo thamSo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thamSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thamSo);
        }

        // GET: ThamSoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamSo thamSo = db.ThamSoes.Find(id);
            if (thamSo == null)
            {
                return HttpNotFound();
            }
            return View(thamSo);
        }

        // POST: ThamSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThamSo thamSo = db.ThamSoes.Find(id);
            db.ThamSoes.Remove(thamSo);
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
