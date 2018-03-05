using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuggestionBox.Models;

namespace SuggestionBox.Controllers
{
    public class SuggestionModelsController : Controller
    {
        private SuggestionBoxContext db = new SuggestionBoxContext();

        // GET: SuggestionModels
        public ActionResult Index()
        {
            return View(db.SuggestionModels.ToList());   /*returns view with everything in SuggestionModels */
        }

        // GET: SuggestionModels/Details/5           /* 5 is the ID of the object*/
        public ActionResult Details(int? id)         /*? is nullable*/
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionModel suggestionModel = db.SuggestionModels.Find(id);  /* go into db, go into Sug..Mod and find matching ID*/
            if (suggestionModel == null)   /* info nullable*/
            {
                return HttpNotFound();  /* find info on above*/
            }
            return View(suggestionModel);
        }

        // GET: SuggestionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuggestionModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]                          /* put stuff on website*/
        [ValidateAntiForgeryToken]          /* ensure no one is hacking program*/
        public ActionResult Create([Bind(Include = "SuggestionID,Topic,Suggestion")] SuggestionModel suggestionModel)
        {
            if (ModelState.IsValid)
            {
                db.SuggestionModels.Add(suggestionModel);    
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggestionModel);
        }

        // GET: SuggestionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionModel suggestionModel = db.SuggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModel);
        }

        // POST: SuggestionModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]          /* check if valid */
        public ActionResult Edit([Bind(Include = "SuggestionID,Topic,Suggestion")] SuggestionModel suggestionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestionModel);
        }

        // GET: SuggestionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionModel suggestionModel = db.SuggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModel);
        }

        // POST: SuggestionModels/Delete/5              /* where deleting gets done */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuggestionModel suggestionModel = db.SuggestionModels.Find(id);
            db.SuggestionModels.Remove(suggestionModel);
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
