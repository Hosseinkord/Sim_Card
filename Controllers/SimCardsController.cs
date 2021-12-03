using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;

namespace Sim_Card.Controllers
{
    public class SimCardsController : Controller
    {
        private Sim_Card_DBEntities db = new Sim_Card_DBEntities();

        // GET: SimCards
        public ActionResult Index()
        {
            var simCards = db.SimCards.Include(s => s.Operator);
            return View(simCards.ToList());
        }

        // GET: SimCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimCard simCard = db.SimCards.Find(id);
            if (simCard == null)
            {
                return HttpNotFound();
            }
            return View(simCard);
        }

        // GET: SimCards/Create
        public ActionResult Create()
        {
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "Title");
            return View();
        }

        // POST: SimCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SimCardID,Number,CreateDate,OperatorID")] SimCard simCard)
        {
            if (ModelState.IsValid)
            {
                db.SimCards.Add(simCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "Title", simCard.OperatorID);
            return View(simCard);
        }

        // GET: SimCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimCard simCard = db.SimCards.Find(id);
            if (simCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "Title", simCard.OperatorID);
            return View(simCard);
        }

        // POST: SimCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SimCardID,Number,CreateDate,OperatorID")] SimCard simCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(simCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "Title", simCard.OperatorID);
            return View(simCard);
        }

        // GET: SimCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimCard simCard = db.SimCards.Find(id);
            if (simCard == null)
            {
                return HttpNotFound();
            }
            return View(simCard);
        }

        // POST: SimCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SimCard simCard = db.SimCards.Find(id);
            db.SimCards.Remove(simCard);
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
