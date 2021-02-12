using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class WaitListsController : Controller
    {
        private readonly MvcDbContext _context;

        public WaitListsController(MvcDbContext context)
        {
            _context = context;
        }

        // GET: WaitLists
        public ActionResult Index()
        {
            return View();
        }

        // GET: WaitLists/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WaitLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaitLists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Create([Bind("WaitListId,UserId,LectureId")] WaitList waitlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waitlist);
                await _context.SaveChangesAsync();
                return true;
                //return RedirectToAction(nameof(Index));
            }

            return false;
            //ViewData["LectureId"] = new SelectList(_context.Lecture, "LectureId", "Title", booking.LectureId);
            //ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", booking.UserId);
            //return View(booking);
        }

        // GET: WaitLists/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WaitLists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WaitLists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WaitLists/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}