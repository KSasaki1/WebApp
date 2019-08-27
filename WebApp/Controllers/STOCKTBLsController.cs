using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp
{
    public class STOCKTBLsController : Controller
    {
        private trdbEntities db = new trdbEntities();

        // GET: STOCKTBLs
        public ActionResult Index()
        {
            return View(db.STOCKTBL.ToList());
        }

        // GET: STOCKTBLs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCKTBL sTOCKTBL = db.STOCKTBL.Find(id);
            if (sTOCKTBL == null)
            {
                return HttpNotFound();
            }
            return View(sTOCKTBL);
        }

        // GET: STOCKTBLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STOCKTBLs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEALID,GOODSID,STOCK,LASTUDT")] STOCKTBL sTOCKTBL)
        {
            if (ModelState.IsValid)
            {
                db.STOCKTBL.Add(sTOCKTBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTOCKTBL);
        }

        // GET: STOCKTBLs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCKTBL sTOCKTBL = db.STOCKTBL.Find(id);
            if (sTOCKTBL == null)
            {
                return HttpNotFound();
            }
            return View(sTOCKTBL);
        }

        // POST: STOCKTBLs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEALID,GOODSID,STOCK,LASTUDT")] STOCKTBL sTOCKTBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTOCKTBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTOCKTBL);
        }

        // GET: STOCKTBLs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCKTBL sTOCKTBL = db.STOCKTBL.Find(id);
            if (sTOCKTBL == null)
            {
                return HttpNotFound();
            }
            return View(sTOCKTBL);
        }

        // POST: STOCKTBLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            STOCKTBL sTOCKTBL = db.STOCKTBL.Find(id);
            db.STOCKTBL.Remove(sTOCKTBL);
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
