using Microsoft.AspNetCore.Mvc;
using W3.Models;

namespace W3.Controllers
{
	public class StudentsController : Controller
	{
		public StudentsController()
		{
			SchooldDb.InitializeDb(50);
		}
		public IActionResult Index()
		{
			var students = SchooldDb.Students.OrderBy(p=>p.Id).ToList();
			return View(students);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Student student)
		{
			var maxId = SchooldDb.Students.Max(p=>p.Id)+1;
			student.Id = maxId;

			if(ModelState.IsValid)
			{
				SchooldDb.Students.Add(student);
				return RedirectToAction("Index");
			}
			return View(student);
		}

		[HttpGet]
		public IActionResult Edit(int studentId)
		{
			var student = SchooldDb.Students.FirstOrDefault(p=> p.Id == studentId);
			return View(student);
		}
		[HttpPost]
		public IActionResult Edit(Student student)
		{

			if (ModelState.IsValid)
			{
				var toBeRemoved = SchooldDb.Students.FirstOrDefault(p=> p.Id == student.Id);
				SchooldDb.Students.Remove(toBeRemoved);
				SchooldDb.Students.Add(student);
				return RedirectToAction("Index");
			}
			return View(student);
		}

		[HttpGet]
		public IActionResult Delete(int studentId)
		{
			var student = SchooldDb.Students.FirstOrDefault(p => p.Id == studentId);

			SchooldDb.Students.Remove(student);

			return RedirectToAction("Index");
		}
	}
}
