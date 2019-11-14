using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecondProject.Models;

namespace SecondProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicContext db;
        public HomeController(ApplicContext context)
        {
            db = context;
        }
        

        
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Groups.ToListAsync());

        }
       
       

        public IActionResult GroupCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Group group)
        {
            db.Groups.Add(group);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //details
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Group group = await db.Groups.FirstOrDefaultAsync(p => p.GroupId == id);
                if (group != null)
                    return View(group);
            }
            return NotFound();
        }

        // edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Group group = await db.Groups.FirstOrDefaultAsync(p => p.GroupId == id);
                if (group != null)
                    return View(group);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Group group)
        {
            db.Groups.Update(group);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //// Studentedit
        //public async Task<IActionResult> StudentEdit(int? id)
        //{
        //    if (id != null)
        //    {
        //        Group group = await db.Groups.FirstOrDefaultAsync(p => p.GroupId == id);
        //        if (group != null)
        //            return View(group);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> StudentEdit(Group group)
        //{
        //    db.Groups.Update(group);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //delete
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Group group = await db.Groups.FirstOrDefaultAsync(p => p.GroupId == id);
                if (group != null)
                    return View(group);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Group group= await db.Groups.FirstOrDefaultAsync(p => p.GroupId == id);
                if (group!= null)
                {
                    db.Groups.Remove(group);
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
