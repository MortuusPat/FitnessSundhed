using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessSundhed.Models;
using FitnessSundhed.ViewModels;

namespace FitnessSundhed.Controllers
{
    public class WorkoutsController : Controller
    {

        private ApplicationDbContext _context;

        public WorkoutsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult New()
        {
            Workouts workout = new Workouts();
            return View("WorkoutForm", workout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult Create(Workouts model)
        {
            if (!ModelState.IsValid)
            {
                
                return View("WorkoutForm", model);
            }
            

            if (model.Id == 0)
            {
                Workouts workout = new Workouts();
                workout = model;
                _context.Workoutss.Add(workout);
            }
            else
            {
                var workoutInDb = _context.Workoutss.Single(c => c.Id == model.Id);
                workoutInDb.Name = model.Name;
                workoutInDb.Author = model.Author;
                workoutInDb.Description = model.Description;
                workoutInDb.Equipment = model.Equipment;
                workoutInDb.Targets = model.Targets;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Library", "Workouts");
        }


        public ActionResult Library()
        {
            var workouts = _context.Workoutss.ToList();
            return View(workouts);
        }

        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult Edit(int id)
        {
            var workout = _context.Workoutss.SingleOrDefault(c => c.Id == id);

            if (workout == null)
            {
                return HttpNotFound();
            }

            return View("WorkoutForm", workout);
        }

        [Route("workouts/overview/{id}/{name}")]
        public ActionResult Overview(int id, string name)
        {
            Sets Set = new Sets();
            var workouts = _context.Workoutss.SingleOrDefault(w => w.Id == id);
            var sets = _context.Setss.ToList();
            var execises = _context.Execisess.ToList();
            WorkoutViewModel viewModel = new WorkoutViewModel();
            viewModel.Workout = workouts;
            viewModel.Sets = sets;
            viewModel.Set = Set;
            viewModel.Execises = execises;
            
            if (workouts == null)
            {
                return HttpNotFound();
            }



            if (User.IsInRole("CanManageAdmin"))
                return View(viewModel);
            else
                return View("OverviewReadOnly", viewModel);
            
        }

        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult Delete(int id)
        {
            var workout = _context.Workoutss.SingleOrDefault(c => c.Id == id);
            List<Sets> workoutSets = new List<Sets>();
            workoutSets = _context.Setss.ToList();
            List<Execises> workoutExecises = new List<Execises>();
            workoutExecises = _context.Execisess.ToList();

            foreach (var set in workoutSets)
            {
                if (set.WorkoutsId == workout.Id)
                {
                    foreach (var execise in workoutExecises)
                    {
                        if (execise.SetsId == set.Id)
                        {
                            _context.Execisess.Remove(execise);
                        }
                    }
                    _context.Setss.Remove(set);
                }
            }
            _context.Workoutss.Remove(workout);

            _context.SaveChanges();
            return RedirectToAction("Library", "Workouts");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult CreateSet(WorkoutViewModel model)
        {

            

            Sets set = new Sets();
            set = model.Set;
            set.WorkoutsId = model.Workout.Id;
            _context.Setss.Add(set);
            _context.SaveChanges();
            return RedirectToAction("Overview", "Workouts", new { id = model.Workout.Id, name = model.Workout.Name });
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult CreateExecise(WorkoutViewModel model)
        {
            Execises execise = new Execises();
            execise = model.Execise;
            execise.SetsId = model.Set.Id;
            _context.Execisess.Add(execise);
            _context.SaveChanges();
            return RedirectToAction("Overview", "Workouts", new { id = model.Workout.Id, name = model.Workout.Name });

        }

        
        [Route("workouts/overview/{workoutId}/edit/set/{id}")]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult EditSet(int workoutId, int id)
        {
            var set = _context.Setss.SingleOrDefault(c => c.Id == id);
            
            if (set == null)
            {
                return HttpNotFound();
            }

            

            return View("EditSet", set);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult UpdateSet(Sets set)
        {

            if (!ModelState.IsValid)
            {

                return View("EditSet", set);
            }

            var setInDB = _context.Setss.Single(c => c.Id == set.Id);
            var workoutInDB = _context.Workoutss.Single(c => c.Id == set.WorkoutsId);
            setInDB.SetDesc = set.SetDesc;
            setInDB.SetName = set.SetName;
            _context.SaveChanges();




            
            return RedirectToAction("Overview", "Workouts", new { id = workoutInDB.Id, name = workoutInDB.Name });







        }
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult DeleteSet(int id)

        {
            var set = _context.Setss.SingleOrDefault(c => c.Id == id);
            var workoutInDB = _context.Workoutss.Single(c => c.Id == set.WorkoutsId);
            List<Execises> setExecises = new List<Execises>();
            setExecises = _context.Execisess.ToList();

            foreach (var execise in setExecises)
            {
                if (execise.SetsId == set.Id)
                {
                    
                    _context.Execisess.Remove(execise);
                }
            }
            _context.Setss.Remove(set);

            _context.SaveChanges();
            return RedirectToAction("Overview", "Workouts", new { id = workoutInDB.Id, name = workoutInDB.Name });
        }
        
        [Route("workouts/overview/{workoutId}/set/{setId}/edit/execise/{id}")]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult EditExecise(int workoutId, int setId, int id )
        {


            var execise = _context.Execisess.SingleOrDefault(c => c.Id == id);

            if (execise == null)
            {
                return HttpNotFound();
            }



            return View("EditExecise", execise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult UpdateExecise(Execises execise)
        {

            if (!ModelState.IsValid)
            {

                return View("EditExecise", execise);
            }

            var execiseInDB = _context.Execisess.Single(c => c.Id == execise.Id);
            var setInDB = _context.Setss.Single(c => c.Id == execiseInDB.SetsId);
            var workoutInDB = _context.Workoutss.Single(c => c.Id == setInDB.WorkoutsId);
            execiseInDB.Name = execise.Name;
            execiseInDB.Reps = execise.Reps;
            execiseInDB.Note = execise.Note;
            _context.SaveChanges();




            _context.SaveChanges();
            return RedirectToAction("Overview", "Workouts", new { id = workoutInDB.Id, name = workoutInDB.Name });







        }
        [Authorize(Roles = "CanManageAdmin")]
        public ActionResult DeleteExecise(int id)
        {
            var execise = _context.Execisess.SingleOrDefault(c => c.Id == id);
            var setInDB = _context.Setss.SingleOrDefault(c => c.Id == execise.SetsId);
            var workoutInDB = _context.Workoutss.Single(c => c.Id == setInDB.WorkoutsId);
            
            _context.Execisess.Remove(execise);

            _context.SaveChanges();
            return RedirectToAction("Overview", "Workouts", new { id = workoutInDB.Id, name = workoutInDB.Name });
        }


        [Route("workouts/overview/{goal}/{workoutName}/{intensity:regex(\\d{1}):range(1, 3)}")]
        public ActionResult ByType(int goal, string workoutName, int intensity)
        {
            return Content(goal + "/" + intensity);
        }
    }
}