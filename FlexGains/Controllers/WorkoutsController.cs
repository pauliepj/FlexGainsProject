using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlexGains.Models;

namespace FlexGains.Controllers
{
    public class WorkoutsController : Controller
    {
        private FlexGainsEntities db = new FlexGainsEntities();

        // GET: Workouts
        [Authorize(Roles = "User, Trainer, Admin")]
        public ActionResult Index()
        {
            var workouts = db.Workouts.Include(w => w.Account);
            return View(workouts.ToList());
        }
        [Authorize(Roles = "User, Trainer, Admin")]
        // GET: Workouts/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Workouts/Create
        [Authorize(Roles = "User, Trainer, Admin")]
        
        public ActionResult Create()
        {
            ViewBag.UserName = new SelectList(db.Accounts, "UserName", "Email");
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkoutId,WorkoutName,UserName")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.Accounts, "UserName", "Email", workout.UserId);
            return View(workout);
        }

        // GET: Workouts/Edit/5
        [Authorize(Roles = "User, Trainer, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Email", workout.UserId);
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [Authorize(Roles = "User, Trainer, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkoutId,WorkoutName,UserId")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Email", workout.UserId);
            return View(workout);
        }

        // GET: Workouts/Delete/5
        [Authorize(Roles = "User, Trainer, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "User, Trainer, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
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
