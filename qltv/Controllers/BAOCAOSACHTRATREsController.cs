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
    public class BAOCAOSACHTRATREsController : Controller
    {
        private QLTVEntities1 db = new QLTVEntities1();

        // GET: BAOCAOSACHTRATREs
        public ActionResult Index()
        {
            var bAOCAOSACHTRATREs = db.BAOCAOSACHTRATREs.Include(b => b.SACH);
            return View(bAOCAOSACHTRATREs.ToList());
        }

        // GET: BAOCAOSACHTRATREs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOSACHTRATRE bAOCAOSACHTRATRE = db.BAOCAOSACHTRATREs.Find(id);
            if (bAOCAOSACHTRATRE == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOSACHTRATRE);
        }

        // GET: BAOCAOSACHTRATREs/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach");
            return View();
        }

        // POST: BAOCAOSACHTRATREs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaoCaoSachTraTre,MaSach,GhiChu,SoNgayTraTre")] BAOCAOSACHTRATRE bAOCAOSACHTRATRE)
        {
            if (ModelState.IsValid)
            {
                db.BAOCAOSACHTRATREs.Add(bAOCAOSACHTRATRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", bAOCAOSACHTRATRE.MaSach);
            return View(bAOCAOSACHTRATRE);
        }

        // GET: BAOCAOSACHTRATREs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOSACHTRATRE bAOCAOSACHTRATRE = db.BAOCAOSACHTRATREs.Find(id);
            if (bAOCAOSACHTRATRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", bAOCAOSACHTRATRE.MaSach);
            return View(bAOCAOSACHTRATRE);
        }

        // POST: BAOCAOSACHTRATREs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaoCaoSachTraTre,MaSach,GhiChu,SoNgayTraTre")] BAOCAOSACHTRATRE bAOCAOSACHTRATRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAOCAOSACHTRATRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", bAOCAOSACHTRATRE.MaSach);
            return View(bAOCAOSACHTRATRE);
        }

        // GET: BAOCAOSACHTRATREs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOSACHTRATRE bAOCAOSACHTRATRE = db.BAOCAOSACHTRATREs.Find(id);
            if (bAOCAOSACHTRATRE == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOSACHTRATRE);
        }

        // POST: BAOCAOSACHTRATREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAOCAOSACHTRATRE bAOCAOSACHTRATRE = db.BAOCAOSACHTRATREs.Find(id);
            db.BAOCAOSACHTRATREs.Remove(bAOCAOSACHTRATRE);
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
