using Entities.ObsEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Services.Obs.Abstract;

namespace ObsWebUI.Controllers
{
    public class FacultiesController : Controller
    {

        private IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // GET: Faculties
        public IActionResult Index()
        {
            return View( _facultyService.GetList());
        }

        // GET: Faculties/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = _facultyService.Get(p => p.Id == id);
                
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _facultyService.Add(faculty);
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty =  _facultyService.Get(p => p.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DeanName")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _facultyService.Update(faculty);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty =  _facultyService.Get(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var faculty = _facultyService.Get(p => p.Id == id);
            if (faculty != null)
            {
                _facultyService.Remove(faculty);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(int id)
        {
            return _facultyService.Any(e => e.Id == id);
        }
    }
}
