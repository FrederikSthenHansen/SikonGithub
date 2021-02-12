using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIKONSystem.Data;
using SIKONSystem.DisplayModel;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class LecturesController : Controller
    {
        private readonly MvcDbContext _context;
        private LectureDisplayModel Display;
        private LectureDetailDM DetailDisplay;

        public LecturesController(MvcDbContext context)
        {
            _context = context;
            Display = new LectureDisplayModel(context);
            DetailDisplay = new LectureDetailDM(context);
        }

        // GET: Lectures
        public IActionResult Index()
        {
            return View(GetHelper());
        }

        //Get letcures helpermethod
        public LectureDisplayModel GetHelper()
        {
            var mvcDbContext = _context.Room;
            Display.RoomDisplayList = mvcDbContext.ToList();
            var NewMvcDbContext = _context.Lecture;
            Display.LectureDisplayList = NewMvcDbContext.ToList();
            var mvcContext = _context;
            Display.CategoryDisplayList = mvcContext.Category.ToList();
            Display.NoOfRooms = Display.RoomDisplayList.Count;
            
            foreach (var L in Display.LectureDisplayList)
            {
                int x = L.Spaces;
                L.Spaces = SpacesCount(L);
                if (x != L.Spaces)
                {
                    Edit(L.LectureId, L);
                }

            }

            return Display;
        }
    

    // GET: Lectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var displayLecture = Display.LectureDisplay;

            var lecture = await _context.Lecture
                .Include(l => l.Room)
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }

            

            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name");

            return View(GetDisplayDM(lecture));
        }

        private LectureDetailDM GetDisplayDM(Lecture lecture)
        {
            var mvcDbContext = _context.Booking;
            DetailDisplay.Bookings = mvcDbContext.ToList();
            var mvcDbContext2 = _context.User;
            DetailDisplay.Users = mvcDbContext2.ToList();
            DetailDisplay.Lecture = lecture;
            return DetailDisplay;
        }

        // GET: Lectures/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name");
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LectureId,RoomId,Title,StartTime,Speaker,CategoryId,Description,TimeFrame")] Lecture lecture)
        {
            //lecture.Spaces = SpacesCount(lecture);

            if (ModelState.IsValid)
            {
                lecture.Spaces = _context.Room.FindAsync(lecture.RoomId).Result.Capacity;
                _context.Add(lecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "Name", lecture.RoomId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", lecture.CategoryId);
            return View(lecture);
        }

        //Gammel hjælpemetode
        private int SpacesCount(Lecture l)
        {
            int count = 0;
            foreach (var booking in _context.Booking)
            {
                if (booking.LectureId == l.LectureId && booking.WaitList == 0)
                {
                    count = count + 1;
                }
            }

            return _context.Room.FindAsync(l.RoomId).Result.Capacity - count;
        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "Name", lecture.RoomId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", lecture.CategoryId);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LectureId,RoomId,Title,StartTime,Speaker,CategoryId,Description,TimeFrame")] Lecture lecture)
        {
            if (id != lecture.LectureId)
            {
                return NotFound();
            }

            lecture.Spaces = SpacesCount(lecture);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.LectureId))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "Name", lecture.RoomId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", lecture.CategoryId);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture
                .Include(l => l.Room)
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecture = await _context.Lecture.FindAsync(id);
            _context.Lecture.Remove(lecture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(int id)
        {
            return _context.Lecture.Any(e => e.LectureId == id);
        }

        public async Task<IActionResult> Partake(int? id)
        {
            
            // BookingSingleton.Instance().Partake(await _context.Lecture.FindAsync(id), new User());
            //return false;
             return RedirectToAction("Index");

            //}
        }
    }
}
