﻿using Microsoft.AspNetCore.Mvc;
using W2.Models;
namespace W2.Controllers
{

    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View(StudentsDbTable.OrderBy(p=>p.Id).ToList());
        }

        public static List<Student> StudentsDbTable = new List<Student>()
        {
                new Student
                {
                    Id = 1,
                    FirstName = "Faruk",
                    LastName = "Furkan",
                    Department = "Math Eng",
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Aydin",
                    LastName = "Secer",
                    Department = "Bio Eng",
                }
        };
        [HttpGet]
        public IActionResult About(int id)
        {
            Student student = StudentsDbTable.FirstOrDefault(p=> p.Id == id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentsDbTable.Add(student);
            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Student student = StudentsDbTable.FirstOrDefault(p => p.Id == id);
			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			Student studentOld = StudentsDbTable.FirstOrDefault(p => p.Id == student.Id);
            StudentsDbTable.Remove(studentOld);
			StudentsDbTable.Add(student);
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
        {
            Student student = StudentsDbTable.FirstOrDefault(p=> p.Id == id);
            StudentsDbTable.Remove(student);

            return RedirectToAction("Index");
        }
    }
}

