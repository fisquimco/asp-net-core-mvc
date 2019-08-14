using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChapterOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class InstituteController : Controller
    {
        private static IList<Institute> institutions = new List<Institute>
        {
            new Institute { InstituteId = 1, Name = "UniParaná", Address = "Paraná" },
            new Institute { InstituteId = 2, Name = "UniSanta", Address = "Santa Catarina" },
            new Institute { InstituteId = 3, Name = "UniSãoPaulo", Address = "São Paulo" },
            new Institute { InstituteId = 4, Name = "UniSulGrandense", Address = "Rio Grande do Sul" },
            new Institute { InstituteId = 5, Name = "UniCarioca", Address = "Rio de Janeiro" }
        };
        public IActionResult Index()
        {
            var result = institutions.OrderBy(i => i.Name);
            return View(result);
        }

        // GET : Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Institute institute)
        {
            institutions.Add(institute);
            institute.InstituteId = institutions.Select(i => i.InstituteId).Max() + 1;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            var result = institutions.Where(i => i.InstituteId == id).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Institute institute)
        {
            institutions.Remove(institutions
                .Where(i => i.InstituteId == institute.InstituteId)
                .First());
            institutions.Add(institute);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long id)
        {
            var result = institutions.Where(i => i.InstituteId == id).First();
            return View(result);
        }

        public IActionResult Delete(long id)
        {
            var result = institutions.Where(i => i.InstituteId == id).First();
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Institute institute)
        {
            institutions
                .Remove(institutions
                .Where(i => i.InstituteId == institute.InstituteId)
                .First());

            return RedirectToAction(nameof(Index));
        }
    }
}