using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class GOODSTBLsController : Controller
    {
        private trdbEntities db = new trdbEntities();

        // GET: GOODSTBLs
        public ActionResult Index()
        {
            return View(db.GOODSTBL.ToList());
        }

        // GET: GOODSTBLs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOODSTBL gOODSTBL = db.GOODSTBL.Find(id);
            if (gOODSTBL == null)
            {
                return HttpNotFound();
            }
            return View(gOODSTBL);
        }

        // GET: GOODSTBLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GOODSTBLs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GOODSID,GOOSNM,PRICE")] GOODSTBL gOODSTBL)
        {
            if (ModelState.IsValid)
            {
                db.GOODSTBL.Add(gOODSTBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gOODSTBL);
        }

        // GET: GOODSTBLs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOODSTBL gOODSTBL = db.GOODSTBL.Find(id);
            if (gOODSTBL == null)
            {
                return HttpNotFound();
            }
            return View(gOODSTBL);
        }

        // POST: GOODSTBLs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GOODSID,GOOSNM,PRICE")] GOODSTBL gOODSTBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gOODSTBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gOODSTBL);
        }

        // GET: GOODSTBLs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOODSTBL gOODSTBL = db.GOODSTBL.Find(id);
            if (gOODSTBL == null)
            {
                return HttpNotFound();
            }
            return View(gOODSTBL);
        }

        // POST: GOODSTBLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GOODSTBL gOODSTBL = db.GOODSTBL.Find(id);
            db.GOODSTBL.Remove(gOODSTBL);
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
