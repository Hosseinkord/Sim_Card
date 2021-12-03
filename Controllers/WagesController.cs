using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using DataLayer.Model;

namespace Sim_Card.Controllers
{
    public class WagesController : Controller
    {
        private IWageRepository wageRepository;
        private IOperatorRepository operatorRepository;

        Sim_Card_DBEntities db = new Sim_Card_DBEntities();

        public WagesController()
        {
            wageRepository = new WageRepository(db);
            operatorRepository = new OperatorRepository(db);
        }
        // GET: Wages
        public ActionResult Index()
        {
            return View(wageRepository.GetAllWage());
        }

        // GET: Wages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wage wage = wageRepository.GetWageById(id.Value);
            if (wage == null)
            {
                return HttpNotFound();
            }
            return View(wage);
        }

        // GET: Wages/Create
        public ActionResult Create()
        {
            ViewBag.OperatorID = new SelectList(operatorRepository.GetAllOperator(), "OperatorID", "Title");
            return View();
        }

        // POST: Wages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WageID,In_Out,Conversation,Message,OperatorID")] Wage wage)
        {
            if (ModelState.IsValid)
            {
                wageRepository.InsertWage(wage);
                wageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.OperatorID = new SelectList(operatorRepository.GetAllOperator(), "OperatorID", "Title", wage.OperatorID);
            return View(wage);
        }

        // GET: Wages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wage wage = wageRepository.GetWageById(id.Value);
            if (wage == null)
            {
                return HttpNotFound();
            }
            ViewBag.OperatorID = new SelectList(operatorRepository.GetAllOperator(), "OperatorID", "Title", wage.OperatorID);
            return View(wage);
        }

        // POST: Wages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WageID,In_Out,Conversation,Message,OperatorID")] Wage wage)
        {
            if (ModelState.IsValid)
            {
                wageRepository.UpdateWage(wage);
                wageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.OperatorID = new SelectList(operatorRepository.GetAllOperator(), "OperatorID", "Title", wage.OperatorID);
            return View(wage);
        }

        // GET: Wages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wage wage = wageRepository.GetWageById(id.Value);
            if (wage == null)
            {
                return HttpNotFound();
            }
            return View(wage);
        }

        // POST: Wages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wage wage = wageRepository.GetWageById(id);
            wageRepository.DeleteWage(wage);
            wageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                wageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
