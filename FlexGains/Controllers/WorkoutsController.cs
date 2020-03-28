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
    public class WorkoutsController : Controller
    {
        private FlexGainsEntities db = new FlexGainsEntities();

        // GET: Workouts
        

        public ActionResult Index(bool? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            ViewBag.isOwnView = id ?? false;
            List<Workout> workouts;
            if(ViewBag.isOwnView)
            {
                var userId = User.Identity.GetUserId();
                workouts = db.Accounts.Find(userId).Workouts.ToList();
            }
            else
            {
                workouts = db.Workouts.ToList();
            }
            return View(workouts);
        }

        
        // GET: Workouts/Details/5

        public ActionResult Details(int? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                workout.UserId = userId;
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("MiniCreate", "WorkoutSteps", new {id = workout.WorkoutId});
            }

            ViewBag.UserName = new SelectList(db.Accounts, "UserName", "Email", workout.UserId);
            return View(workout);
        }

        public ActionResult ByMuscleGroup(WorkoutClass? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            ViewBag.AllMuscleGroups = new SelectList(db.MuscleGroups, "GroupId", "GroupName");
            if (id != null)
            {
                var model = new MuscleGroupSelectionViewModel();
                model.groupId = id.Value;
                var workouts = db.Workouts.AsEnumerable().Where(w => w.GetType() == id.Value);
                model.workouts = workouts.ToList();
                return View(model);

            }
            return View();



        }



        // GET: Workouts/Edit/5
        [Authorize(Roles = "User, Trainer, Admin")]
        public ActionResult Edit(int? id)
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
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
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            Workout workout = db.Workouts.Find(id);
            workout.WorkoutSteps.Clear();
            db.SaveChanges();
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
