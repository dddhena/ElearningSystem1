using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ElearningSystem.Data;
using ElearningSystem.Models;
using System.Security.Claims;

namespace ElearningSystem.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Course
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // GET: Course/Details/5
        public IActionResult Details(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // GET: Course/Create
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                // Assign the currently logged-in instructor's ID
                var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdStr, out int userId))
                {
                    course.InstructorId = userId;
                }
                
                course.CreatedAt = DateTime.UtcNow;
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        // GET: Course/Edit/5
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.CourseId) return BadRequest();

            if (ModelState.IsValid)
            {
                var existing = _context.Courses.FirstOrDefault(c => c.CourseId == id);
                if (existing == null) return NotFound();

                existing.Title = course.Title;
                existing.Description = course.Description;
                _context.SaveChanges();
                TempData["Success"] = "Course updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Delete/5
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Instructor")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                TempData["Success"] = "Course deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
