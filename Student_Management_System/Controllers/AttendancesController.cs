using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using Student_Management_System.View_Model;

namespace Student_Management_System.Controllers
{
    [Route("attendance")]
    public class AttendancesController : Controller
    {
        private readonly MyDbContext _context;

        public AttendancesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Attendances
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return _context.Attendances != null ? 
                          View(await _context.Attendances.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Attendances'  is null.");
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        [Route("createget")]
        public async Task<IActionResult> Create()
        {
            var model = new AttendanceViewModel();
            try
            {
                // For heavy database querying
                // Operation done in database
                var groupData = _context.Groups.Where(x => x.Name != null).Select(x => new Group
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                model.GroupData = groupData;

                // Operation done in memory
                var levelData = await _context.Level.ToListAsync();
                model.LevelData = levelData;

                var courseData = await _context.Course_1.ToListAsync();
                model.CourseData = courseData;

                model.Date = DateTime.Now.Date;
            }
            catch (Exception ex)
            {

            }

            ViewData["AttendanceDataList"] = model;

            return View();

            /*
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

            */

        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date,CourseId,LevelId,GroupId")] Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.Id))
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
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendances == null)
            {
                return Problem("Entity set 'MyDbContext.Attendance'  is null.");
            }
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
          return (_context.Attendances?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [Route("getStudentData")]
        public async Task<IActionResult> getStudentData([FromBody] AttendanceFilterModel model)
        {
            var studentData = new List<StudentDataModel>();
            try
            {
                var dataExist = await _context.Attendances.FirstOrDefaultAsync(x => x.date.Date == model.Date.Date && x.CourseId == model.CourseId && x.LevelId == model.LevelId && x.GroupId == model.GroupId);
                if (dataExist == null)
                {
                    studentData = _context.StudentRegistration.Where(x => x.LevelId == model.LevelId && x.CourseId == model.CourseId && x.GroupId == model.GroupId).Select(x => new StudentDataModel 
                    {
                        Name = x.Name,
                        Id = x.Id,
                        CourseId = x.CourseId,
                        LevelId =x.LevelId,
                        GroupId = x.GroupId,
                        Status = 0,
                        StudentId = x.Id
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return Json(studentData);
        }

        [HttpPost]
        [Route ("saveAttendanceData")]
        public async Task<IActionResult> saveAttendanceData([FromBody] StudentDataModel model)
        {
            var response = new JsonResponse<dynamic>();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dataExist = await _context.Attendances.AnyAsync
                                        (x => x.date.Date == model.Date.Date &&
                                                x.LevelId == model.LevelId &&
                                                x.GroupId == model.GroupId &&
                                                x.CourseId == model.CourseId);

                    var attendanceData = new Attendance
                    {
                        LevelId = model.LevelId,
                        date = model.Date,
                        CourseId = model.CourseId,
                        GroupId = model.GroupId
                    };

                    if (!dataExist)
                    {
                        await _context.Attendances.AddAsync(attendanceData);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var entity = await _context.Attendances.
                            FirstOrDefaultAsync(x => x.date.Date == model.Date.Date &&
                                            x.LevelId == model.LevelId &&
                                            x.GroupId == model.GroupId &&
                                            x.CourseId == model.CourseId);
                        entity.date = model.Date;
                        entity.LevelId = model.LevelId;
                        entity.GroupId = model.GroupId;
                        entity.CourseId = model.CourseId;
                        _context.Attendances.Update(attendanceData);
                        await _context.SaveChangesAsync();
                    }

                    var attendanceDataObj = await _context.Attendances.
                        FirstOrDefaultAsync(x => x.date.Date == model.Date.Date && x.LevelId ==
                        model.LevelId && x.GroupId == model.GroupId && x.CourseId == model.CourseId);

                    if (attendanceDataObj == null)
                    {
                        transaction.Rollback();
                    }
                    else
                    {
                        if (dataExist && attendanceDataObj != null)
                        {
                            var getTotalExistData = await _context.AttendanceDetail.ToListAsync();
                            foreach (var da in getTotalExistData.Where(x => x.AttendanceId == attendanceDataObj.Id))
                            {
                                _context.AttendanceDetail.Remove(da);
                                await _context.SaveChangesAsync();
                            }
                        }

                        foreach (var da in model.StudentDetailData)
                        {
                            var attendanceDetail = new AttendanceDetail
                            {
                                AttendanceId = attendanceDataObj.Id,
                                StudentId = da.StudentId,
                                AbsentPresentStatus = (byte)da.Status
                            };
                            await _context.AttendanceDetail.AddAsync(attendanceDetail);
                            await _context.SaveChangesAsync();
                        }
                    }
                    transaction.Commit();
                    response.Status = true;

                    if (dataExist)
                    {
                        response.Message = "Data Update Successfully";
                    }
                    else
                    {
                        response.Message = "Data added successfully";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.Status = false;
                    response.Message = ex.Message;
                }
            }
            return Ok(response);
        }
    }
}
