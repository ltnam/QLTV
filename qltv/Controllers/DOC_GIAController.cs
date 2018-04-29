using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qltv.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace qltv.Controllers
{
    public class DOC_GIAController : Controller
    {
        private QLTVEntities1 db = new QLTVEntities1();

        // GET: DOC_GIA
        public ActionResult Index()
        {
            var dOC_GIA = db.DOC_GIA.Include(d => d.LOAI_DOCGIA);
            return View(dOC_GIA.ToList());
        }
        public ActionResult ExportCustomers()
        {
            List<DOC_GIA> allDOCGIA = new List<DOC_GIA>();
            allDOCGIA = db.DOC_GIA.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport1.rpt"));

            rd.SetDataSource(allDOCGIA);
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
            
        }
        // GET: DOC_GIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOC_GIA dOC_GIA = db.DOC_GIA.Find(id);
            if (dOC_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dOC_GIA);
        }

        // GET: DOC_GIA/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG");
            return View();
        }

        // POST: DOC_GIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,MaLoaiDG,HoTen,NgaySinh,DiaChi,Email,NgayLapThe,TienNo,HanThe")] DOC_GIA dOC_GIA)
        {
            if (ModelState.IsValid)
            {
                db.DOC_GIA.Add(dOC_GIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG", dOC_GIA.MaLoaiDG);
            return View(dOC_GIA);
        }

        // GET: DOC_GIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOC_GIA dOC_GIA = db.DOC_GIA.Find(id);
            if (dOC_GIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG", dOC_GIA.MaLoaiDG);
            return View(dOC_GIA);
        }

        // POST: DOC_GIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,MaLoaiDG,HoTen,NgaySinh,DiaChi,Email,NgayLapThe,TienNo,HanThe")] DOC_GIA dOC_GIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOC_GIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG", dOC_GIA.MaLoaiDG);
            return View(dOC_GIA);
        }

        // GET: DOC_GIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOC_GIA dOC_GIA = db.DOC_GIA.Find(id);
            if (dOC_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dOC_GIA);
        }

        // POST: DOC_GIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOC_GIA dOC_GIA = db.DOC_GIA.Find(id);
            db.DOC_GIA.Remove(dOC_GIA);
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
