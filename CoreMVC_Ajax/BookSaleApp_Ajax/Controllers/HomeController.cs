using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookSaleApp_Ajax.Models;
using BookSaleApp_Ajax.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSaleApp_Ajax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
       
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var author =await _context.Authors.ToListAsync();
            return Json(author);
        }
        [HttpPost]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Json(await _context.AuthorBooks.Where(x => x.AuthorId == id)
                              .Select(x => new { x.Book.Id, x.Book.Name }).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            return Json(await _context.BookLanguages.Where(x => x.BookId == id)
                            .Select(x => new { x.Language.Id, x.Language.Name }).ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
