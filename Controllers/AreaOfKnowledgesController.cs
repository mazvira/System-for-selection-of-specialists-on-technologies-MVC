using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemKnowledgeMVC.Models;

namespace SystemKnowledgeMVC.Controllers
{
    public class AreaOfKnowledgesController : Controller
    {
        private AreaOfKnowledgeDBContext db = new AreaOfKnowledgeDBContext();

        // GET: AreaOfKnowledges
        public ActionResult Index()
        {
            return View(db.AreasOfKnowledge.ToList());
        }

        public ActionResult SearchByNameOfArea(string searchString)
        {
            var areas = from m in db.AreasOfKnowledge
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                areas = areas.Where(s => s.AreaOfKnowledgeName.Contains(searchString));
            }

            return View(areas);
        }

        public ActionResult SearchByNameOfAreaWithDescription(string areaOfKnowledgeName, string description)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.AreasOfKnowledge
                           orderby d.AreaOfKnowledgeName
                           select d.AreaOfKnowledgeName;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.areaOfKnowledgeName = new SelectList(GenreLst);

            var movies = from m in db.AreasOfKnowledge
                         select m;

            if (!String.IsNullOrEmpty(description))
            {
                movies = movies.Where(s => s.Description.Contains(description));
            }

            if (!string.IsNullOrEmpty(areaOfKnowledgeName))
            {
                movies = movies.Where(x => x.AreaOfKnowledgeName == areaOfKnowledgeName);
            }

            return View(movies);
        }

        // GET: AreaOfKnowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaOfKnowledge areaOfKnowledge = db.AreasOfKnowledge.Find(id);
            if (areaOfKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(areaOfKnowledge);
        }

        // GET: AreaOfKnowledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaOfKnowledges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AreaOfKnowledgeID,AreaOfKnowledgeName,Description,UserId")] AreaOfKnowledge areaOfKnowledge)
        {
            if (ModelState.IsValid)
            {
                db.AreasOfKnowledge.Add(areaOfKnowledge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaOfKnowledge);
        }

        // GET: AreaOfKnowledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaOfKnowledge areaOfKnowledge = db.AreasOfKnowledge.Find(id);
            if (areaOfKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(areaOfKnowledge);
        }

        // POST: AreaOfKnowledges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AreaOfKnowledgeID,AreaOfKnowledgeName,Description,UserId")] AreaOfKnowledge areaOfKnowledge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaOfKnowledge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaOfKnowledge);
        }

        // GET: AreaOfKnowledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaOfKnowledge areaOfKnowledge = db.AreasOfKnowledge.Find(id);
            if (areaOfKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(areaOfKnowledge);
        }

        // POST: AreaOfKnowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaOfKnowledge areaOfKnowledge = db.AreasOfKnowledge.Find(id);
            db.AreasOfKnowledge.Remove(areaOfKnowledge);
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
