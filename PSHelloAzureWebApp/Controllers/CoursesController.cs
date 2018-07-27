using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSHelloAzureWebApp.Models.Courses;
using PSHelloAzureWebApp.Services;

namespace PSHelloAzureWebApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseStore courseStore;

        public CoursesController(CourseStore courseStore)
        {
            this.courseStore = courseStore;
        }
        public IActionResult Index()
        {
            var model = courseStore.GetAllCourses();

            return View(model);
        }

        public async Task<IActionResult> Insert()
        {
            var data = new SampleData().GetCourses();
            await courseStore.InsertCourses(data);
            return RedirectToAction(nameof(Index));
        }
    }
}