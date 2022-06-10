#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreApp05.Models;

namespace EFCoreApp05.Controllers
{
    public class CoursesController : Controller
    {
        //private readonly EmployeeDBContext _context;

        //public CoursesController(EmployeeDBContext context)
        //{
        //    _context = context;
        //}

        //// GET: Courses
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TblCourses.ToListAsync());
        //}

        EmployeeDBContext context = new EmployeeDBContext();
        // GET: CoursesController
        public ActionResult Index()
        {
            return View(context.TblCourses.ToList());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCourse = await context.TblCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCourse == null)
            {
                return NotFound();
            }

            return View(tblCourse);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseName,Hod,Fee")] TblCourse tblCourse)
        {
            if (ModelState.IsValid)
            {
                context.Add(tblCourse);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCourse);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCourse = await context.TblCourses.FindAsync(id);
            if (tblCourse == null)
            {
                return NotFound();
            }
            return View(tblCourse);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,Hod,Fee")] TblCourse tblCourse)
        {
            if (id != tblCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(tblCourse);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCourseExists(tblCourse.Id))
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
            return View(tblCourse);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCourse = await context.TblCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCourse == null)
            {
                return NotFound();
            }

            return View(tblCourse);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCourse = await context.TblCourses.FindAsync(id);
            context.TblCourses.Remove(tblCourse);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCourseExists(int id)
        {
            return context.TblCourses.Any(e => e.Id == id);
        }
    }
}
