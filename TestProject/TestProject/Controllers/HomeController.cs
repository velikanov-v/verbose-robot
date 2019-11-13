using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            return View(await db.Teams.ToListAsync());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Redacting()
        {
            return View();
        }
         
               
        public async Task<IActionResult> Tempor()
        {
            return View(await db.Teams.ToListAsync());
        }
        public IActionResult GroupRed()
        {
            return View();

        }
        public async Task<IActionResult> TestView()
        {
            return View(await db.Teams.ToListAsync());

        }
        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            db.Teams.Add(team);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //details
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Team team = await db.Teams.FirstOrDefaultAsync(p => p.Id == id);
                if (team != null)
                    return View(team);
            }
            return NotFound();
        }

        // edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Team team = await db.Teams.FirstOrDefaultAsync(p => p.Id == id);
                if (team != null)
                    return View(team);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Team team)
        {
            db.Teams.Update(team);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Studentedit
        public async Task<IActionResult> StudentEdit(int? id)
        {
            if (id != null)
            {
                Team team = await db.Teams.FirstOrDefaultAsync(p => p.Id == id);
                if (team != null)
                    return View(team);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> StudentEdit(Team team)
        {
            db.Teams.Update(team);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //delete
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Team team = await db.Teams.FirstOrDefaultAsync(p => p.Id == id);
                if (team != null)
                    return View(team);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Team team = await db.Teams.FirstOrDefaultAsync(p => p.Id == id);
                if (team != null)
                {
                    db.Teams.Remove(team);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
