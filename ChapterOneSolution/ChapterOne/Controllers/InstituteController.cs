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
            return View(institutions);
        }
    }
}