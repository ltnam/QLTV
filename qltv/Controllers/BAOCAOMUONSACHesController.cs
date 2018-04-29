using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qltv.Models;

namespace qltv.Controllers
{
    public class BAOCAOMUONSACHesController : Controller
    {
        private QLTVEntities1 db = new QLTVEntities1();

        // GET: BAOCAOMUONSACHes
        public ActionResult Index()
        {
            var bAOCAOMUONSACHes = db.BAOCAOMUONSACHes.Include(b => b.LOAI_SACH);
            return View(bAOCAOMUONSACHes.ToList());
        }

        // GET: BAOCAOMUONSACHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOMUONSACH bAOCAOMUONSACH = db.BAOCAOMUONSACHes.Find(id);
            if (bAOCAOMUONSACH == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOMUONSACH);
        }

        // GET: BAOCAOMUONSACHes/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach");
            return View();
        }

        // POST: BAOCAOMUONSACHes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaoCaoMuon,MaLoaiSach,SoLuotMuon,TiLe")] BAOCAOMUONSACH bAOCAOMUONSACH)
        {
            if (ModelState.IsValid)
            {
                db.BAOCAOMUONSACHes.Add(bAOCAOMUONSACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach", bAOCAOMUONSACH.MaLoaiSach);
            return View(bAOCAOMUONSACH);
        }

        // GET: BAOCAOMUONSACHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOMUONSACH bAOCAOMUONSACH = db.BAOCAOMUONSACHes.Find(id);
            if (bAOCAOMUONSACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach", bAOCAOMUONSACH.MaLoaiSach);
            return View(bAOCAOMUONSACH);
        }

        // POST: BAOCAOMUONSACHes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaoCaoMuon,MaLoaiSach,SoLuotMuon,TiLe")] BAOCAOMUONSACH bAOCAOMUONSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAOCAOMUONSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach", bAOCAOMUONSACH.MaLoaiSach);
            return View(bAOCAOMUONSACH);
        }

        // GET: BAOCAOMUONSACHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOMUONSACH bAOCAOMUONSACH = db.BAOCAOMUONSACHes.Find(id);
            if (bAOCAOMUONSACH == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOMUONSACH);
        }

        // POST: BAOCAOMUONSACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAOCAOMUONSACH bAOCAOMUONSACH = db.BAOCAOMUONSACHes.Find(id);
            db.BAOCAOMUONSACHes.Remove(bAOCAOMUONSACH);
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
