using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using Student_Management_System.View_Model;

namespace Student_Management_System.Controllers
{
    public class StudentRegistrationsController : Controller
    {
        private readonly MyDbContext _context;

        public StudentRegistrationsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: StudentRegistrations
        public async Task<IActionResult> Index()
        {
            List<StudentRegistrationViewModel> modelList = new List<StudentRegistrationViewModel>();

            try
            {
                // Creates a list container from StudentRegistration class 
                var studentData = await _context.StudentRegistration.ToListAsync();
                foreach (var student in studentData)
                {
                    var levelData = await _context.Level.FirstOrDefaultAsync(x => x.Id == student.LevelId);
                    var groupData = await _context.Groups.FirstOrDefaultAsync(x => x.Id == student.GroupId);
                    var courseData = await _context.Course_1.FirstOrDefaultAsync(x => x.Id == student.CourseId);

                    modelList.Add(new StudentRegistrationViewModel
                    {
                        StudentId = student.Id,
                        Name = student.Name,
                        Address = student.Address,
                        Phone = student.Phone,
                        CourseName = courseData != null ? courseData.name : "",
                        LevelName = levelData != null ? levelData.Name : "",
                        GroupName = groupData != null ? groupData.Name : ""
                    }) ;
                }
            }

            catch (Exception ex)
            {

            }

            return View(modelList);
        }

        // GET: StudentRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return View(studentRegistration);
        }

        public async Task<IActionResult> Create() 
        {
            var model = new StudentRegistrationViewModel();
            try
            {
                // For Groups list dropdown menu
                var groupList = new List<SelectListItem>();
                var getGroupData = await _context.Groups.ToListAsync();

                foreach (var group in getGroupData)
                {
                    groupList.Add(new SelectListItem
                    {
                        Text = group.Name,
                        Value = group.Id.ToString(),
                    });
                }
                model.GroupData = groupList;

                // For Levels list dropdown menu
                var levelList = new List<SelectListItem>();
                var getLevelData = await _context.Level.ToListAsync();

                foreach (var level in getLevelData)
                {
                    levelList.Add(new SelectListItem
                    {
                        Text = level.Name,
                        Value = level.Id.ToString(),
                    });
                }
                model.LevelData = levelList;

                // For Course list dropdown menu
                var courseList = new List<SelectListItem>();
                var getCourseData = await _context.Course_1.ToListAsync();

                foreach (var courseId in getCourseData)
                {
                    courseList.Add(new SelectListItem
                    {
                        Text = courseId.name,
                        Value = courseId.Id.ToString(),
                    });
                }
                model.CourseData = courseList;

            }
            catch (Exception ex)
            {

            }

            return View(model);
        }

        // POST: StudentRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,LevelId,CourseId,Id,Name,Address,Email,Phone")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentRegistration);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var model = new StudentRegistrationViewModel();
            try
            {
                // For Groups list dropdown menu
                var groupList = new List<SelectListItem>();
                var getGroupData = await _context.Groups.ToListAsync();

                foreach (var group in getGroupData)
                {
                    groupList.Add(new SelectListItem
                    {
                        Text = group.Name,
                        Value = group.Id.ToString(),
                    });
                }
                model.GroupData = groupList;

                // For Levels list dropdown menu
                var levelList = new List<SelectListItem>();
                var getLevelData = await _context.Level.ToListAsync();

                foreach (var level in getLevelData)
                {
                    levelList.Add(new SelectListItem
                    {
                        Text = level.Name,
                        Value = level.Id.ToString(),
                    });
                }
                model.LevelData = levelList;

                // For Course list dropdown menu
                var courseList = new List<SelectListItem>();
                var getCourseData = await _context.Course_1.ToListAsync();

                foreach (var courseId in getCourseData)
                {
                    courseList.Add(new SelectListItem
                    {
                        Text = courseId.name,
                        Value = courseId.Id.ToString(),
                    });
                }

                /*
                var courseData = await _context.Course_1.ToListAsync();
                foreach (var da in courseData)
                {
                    model.CourseData.Add(new SelectListItem { Text = da.Name, Value = da.Id.ToString()});
                }
                */
                
                //model.CourseData = courseList;

                var StudentRegistration = await _context.StudentRegistration.FindAsync(id);
                model.Name = StudentRegistration.Name;
                model.Address = StudentRegistration.Address;
                model.Phone = StudentRegistration.Phone;
                model.GroupId = StudentRegistration.GroupId;
                model.LevelId = StudentRegistration.LevelId;
                model.CourseId = StudentRegistration.CourseId;

            }
            catch (Exception ex)
            {

            }

            return View(model);
        }

        // POST: StudentRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,LevelId,CourseId,Id,Name,Address,Email,Phone")] StudentRegistration studentRegistration)
        {
            if (id != studentRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentRegistrationExists(studentRegistration.Id))
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
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentRegistration == null)
            {
                return Problem("Entity set 'MyDbContext.StudentRegistration'  is null.");
            }
            var studentRegistration = await _context.StudentRegistration.FindAsync(id);
            if (studentRegistration != null)
            {
                _context.StudentRegistration.Remove(studentRegistration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentRegistrationExists(int id)
        {
          return (_context.StudentRegistration?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
