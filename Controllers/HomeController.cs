using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int pageNum, long? teamId)
        {
            //number of items per page
            int pageSize = 5;

            return View(new MainViewModel { 
                Bowlers = (_context.Bowlers
                .Where(b => b.TeamId == teamId || teamId == null)
                //pagenation
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList())
                ,
                pageNumberingInfo = new PageNumberingInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalItems = (teamId == null ? _context.Bowlers.Count() : _context.Bowlers.Where(b => b.TeamId == teamId).Count())
                }
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
