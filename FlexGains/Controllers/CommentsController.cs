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
    public class CommentsController : Controller
    {
        private FlexGainsEntities db = new FlexGainsEntities();

        // GET: Comments
        public ActionResult Index(int id)
        {
            var comments = db.Workouts.Find(id).Comments.OrderByDescending(c => c.CommentDateTime);
            return PartialView(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Authorize]
        // GET: Comments/Create
        public ActionResult Create(int id)
        {
            if (Request.Url.ToString().ToLower().Contains("comments/create"))
            {
                return RedirectToAction("Details", "Workouts", new { id = id });
            }
            var model = new Comment {UserId= User.Identity.GetUserId(), WorkoutId = id};         
            
            return PartialView(model);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        public void Create([Bind(Include = "CommentId,UserId,WorkoutId,TextBody")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CommentDateTime = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
                var workout = db.Workouts.Find(comment.WorkoutId);

                ControllerContext.HttpContext.Response.Redirect(ControllerContext.HttpContext.Request.Url.ToString());

                //return RedirectToAction("Details", "Workouts", new {id = comment.WorkoutId });
            }

            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Email", comment.UserId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", comment.WorkoutId);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Email", comment.UserId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", comment.WorkoutId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,UserId,WorkoutId,CommentDateTime,TextBody")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Email", comment.UserId);
            ViewBag.WorkoutId = new SelectList(db.Workouts, "WorkoutId", "WorkoutName", comment.WorkoutId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            var workout = comment.WorkoutId;
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Workouts", new {id = workout });
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
