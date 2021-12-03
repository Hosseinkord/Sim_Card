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
    public class PersonSimCardsController : Controller
    {
        private Sim_Card_DBEntities db = new Sim_Card_DBEntities();

        // GET: PersonSimCards
        public ActionResult Index()
        {
            return View(db.PersonSimCards.ToList());
        }

        // GET: PersonSimCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonSimCard personSimCard = db.PersonSimCards.Find(id);
            if (personSimCard == null)
            {
                return HttpNotFound();
            }
            return View(personSimCard);
        }

        // GET: PersonSimCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonSimCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonSimID,PersonID,SimID,JoinDate,Charge")] PersonSimCard personSimCard)
        {
            if (ModelState.IsValid)
            {
                db.PersonSimCards.Add(personSimCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personSimCard);
        }

        // GET: PersonSimCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonSimCard personSimCard = db.PersonSimCards.Find(id);
            if (personSimCard == null)
            {
                return HttpNotFound();
            }
            return View(personSimCard);
        }

        // POST: PersonSimCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonSimID,PersonID,SimID,JoinDate,Charge")] PersonSimCard personSimCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personSimCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personSimCard);
        }

        // GET: PersonSimCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonSimCard personSimCard = db.PersonSimCards.Find(id);
            if (personSimCard == null)
            {
                return HttpNotFound();
            }
            return View(personSimCard);
        }

        // POST: PersonSimCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonSimCard personSimCard = db.PersonSimCards.Find(id);
            db.PersonSimCards.Remove(personSimCard);
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
