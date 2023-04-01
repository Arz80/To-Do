using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoTasksController : Controller
    {
        private readonly ToDoListContext _context;

        public ToDoTasksController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: ToDoTasks
        public async Task<IActionResult> Index()
        {
            var toDoListContext = _context.ToDoLists.Include(t => t.Priority).Include(t => t.Status);
            return View(await toDoListContext.ToListAsync());
        }

        // GET: ToDoTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.ToDoLists
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // GET: ToDoTasks/Create
        public IActionResult Create()
        {
            ViewData["PriorityId"] = new SelectList(_context.Prioritys, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: ToDoTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,OpenDate,EndDate,StatusId,PriorityId")] ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriorityId"] = new SelectList(_context.Prioritys, "Id", "Name", toDoTask.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", toDoTask.StatusId);
            return View(toDoTask);
        }

        // GET: ToDoTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.ToDoLists.FindAsync(id);
            if (toDoTask == null)
            {
                return NotFound();
            }
            ViewData["PriorityId"] = new SelectList(_context.Prioritys, "Id", "Name", toDoTask.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", toDoTask.StatusId);
            return View(toDoTask);
        }

        // POST: ToDoTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,OpenDate,EndDate,StatusId,PriorityId")] ToDoTask toDoTask)
        {
            if (id != toDoTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoTaskExists(toDoTask.Id))
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
            ViewData["PriorityId"] = new SelectList(_context.Prioritys, "Id", "Name", toDoTask.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", toDoTask.StatusId);
            return View(toDoTask);
        }

        // GET: ToDoTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.ToDoLists
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // POST: ToDoTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDoLists == null)
            {
                return Problem("Entity set 'ToDoListContext.ToDoLists'  is null.");
            }
            var toDoTask = await _context.ToDoLists.FindAsync(id);
            if (toDoTask != null)
            {
                _context.ToDoLists.Remove(toDoTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoTaskExists(int id)
        {
          return (_context.ToDoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
