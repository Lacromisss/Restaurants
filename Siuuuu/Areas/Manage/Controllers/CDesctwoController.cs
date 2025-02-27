﻿using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Curious;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CDesctwoController : Controller
    {

        private readonly AppDbContext _context;

        public CDesctwoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CuriorDescription2> curior = _context.curiorDescription2s.ToList();
            return View(curior);
        }

        public IActionResult Update(int Id)
        {
            CuriorDescription2 curior = _context.curiorDescription2s.Find(Id);
            if (curior == null)
            {
                return BadRequest();

            }
            return View(curior);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, CuriorDescription2 curior)
        {
            if (Id != curior.Id)
            {
                return BadRequest();
            }
            CuriorDescription2 curior1 = _context.curiorDescription2s.Find(Id);
            if (curior1 == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View();

            }
            curior1.Title = curior.Title;
            curior1.Description = curior.Description;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
