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
    public class WorkoutStepsController : Controller
    {
        private FlexGainsEntities db = new FlexGainsEntities();

        // GET: WorkoutSteps
        public ActionResult Index()
        {
            var workoutSteps = db.WorkoutSteps.Include(w => w.Exercise).Include(w => w.Workout);
            return View(workoutSteps.ToList());
        }

        // GET: WorkoutSteps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutStep workoutStep = db.WorkoutSteps.Find(id);
            if (workoutStep == null)
            {
                return HttpNotFound();
            }
            return View(workoutStep);
        }

        // GET: WorkoutSteps/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName");
            return View();
        }

        // POST: WorkoutSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StepId,WorkoutId,ExerciseId,WorkoutOrder,RepsNumber,SetsNumber")] WorkoutStep workoutStep)
        {
            if (ModelState.IsValid)
            {
                db.WorkoutSteps.Add(workoutStep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", workoutStep.ExerciseId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", workoutStep.WorkoutId);
            return View(workoutStep);
        }
        // GET: WorkoutSteps/Create
        public ActionResult MiniCreate()
        {
            ViewBag.MuscleGroupMap = db.MuscleGroups.ToDictionary(g => g, g => g.Exercises.ToList());
            ViewBag.AllMuscleGroups = new SelectList(db.MuscleGroups, "GroupId", "GroupName");
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName");
            return View();
        }

        // POST: WorkoutSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MiniCreate([Bind(Include = "StepId,WorkoutId,ExerciseId,WorkoutOrder,RepsNumber,SetsNumber")] WorkoutStep workoutStep)
        {
            if (ModelState.IsValid)
            {
                db.WorkoutSteps.Add(workoutStep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", workoutStep.ExerciseId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", workoutStep.WorkoutId);
            return View(workoutStep);
        }
        // GET: WorkoutSteps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutStep workoutStep = db.WorkoutSteps.Find(id);
            if (workoutStep == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", workoutStep.ExerciseId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", workoutStep.WorkoutId);
            return View(workoutStep);
        }

        // POST: WorkoutSteps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StepId,WorkoutId,ExerciseId,WorkoutOrder,RepsNumber,SetsNumber")] WorkoutStep workoutStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workoutStep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", workoutStep.ExerciseId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", workoutStep.WorkoutId);
            return View(workoutStep);
        }

        // GET: WorkoutSteps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutStep workoutStep = db.WorkoutSteps.Find(id);
            if (workoutStep == null)
            {
                return HttpNotFound();
            }
            return View(workoutStep);
        }

        // POST: WorkoutSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkoutStep workoutStep = db.WorkoutSteps.Find(id);
            db.WorkoutSteps.Remove(workoutStep);
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
