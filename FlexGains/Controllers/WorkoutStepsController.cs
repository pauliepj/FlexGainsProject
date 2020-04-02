using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlexGains.Models;
using Microsoft.AspNet.Identity;

namespace FlexGains.Controllers
{
    public class WorkoutStepsController : Controller
    {
        private FlexGainsEntities db = new FlexGainsEntities();

        // GET: WorkoutSteps
        public ActionResult Index()
        {
 
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            var workoutSteps = db.WorkoutSteps.Include(w => w.Exercise).Include(w => w.Workout);
            return View(workoutSteps.ToList());
        }

        // GET: WorkoutSteps/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
        public ActionResult Create(int? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName");
            var workout = db.Workouts.Find(id);
            var stepCount = workout.WorkoutSteps.Count();
            var step = new WorkoutStep {WorkoutId = id.Value, Workout = workout, WorkoutOrder = (byte) (stepCount+1)};
            return View(step);
        }

        // POST: WorkoutSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StepId,WorkoutId,ExerciseId,WorkoutOrder,RepsNumber,SetsNumber")] WorkoutStep workoutStep)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            if (ModelState.IsValid)
            {
                db.WorkoutSteps.Add(workoutStep);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", workoutStep.ExerciseId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", workoutStep.WorkoutId);
            return View(workoutStep);
        }
        // GET: WorkoutSteps/Create
        public ActionResult MiniCreate(int? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            ViewBag.MuscleGroupMap = db.MuscleGroups.ToDictionary(g => g, g => g.Exercises.ToList());
            ViewBag.AllMuscleGroups = new SelectList(db.MuscleGroups, "GroupId", "GroupName");
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName");
            var workout = db.Workouts.Find(id);
            var stepCount = workout.WorkoutSteps.Count();
            var step = new WorkoutStep { WorkoutId = id.Value, Workout = workout, WorkoutOrder = (byte)(stepCount + 1) };
            return View(step);
        }

        // POST: WorkoutSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MiniCreate([Bind(Include = "StepId,WorkoutId,ExerciseId,WorkoutOrder,RepsNumber,SetsNumber")] WorkoutStep workoutStep)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            if (ModelState.IsValid)
            {
                db.WorkoutSteps.Add(workoutStep);
                db.SaveChanges();
                return RedirectToAction("MiniCreate");
            }
            ViewBag.MuscleGroupMap = db.MuscleGroups.ToDictionary(g => g, g => g.Exercises.ToList());
            ViewBag.AllMuscleGroups = new SelectList(db.MuscleGroups, "GroupId", "GroupName");
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", workoutStep.ExerciseId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", workoutStep.WorkoutId);
            return View(workoutStep);
        }
        // GET: WorkoutSteps/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            WorkoutStep workoutStep = db.WorkoutSteps.Find(id);
            db.WorkoutSteps.Remove(workoutStep);
            db.SaveChanges();
            return RedirectToAction("Index", "Workouts");
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
