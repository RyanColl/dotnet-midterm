using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.DataTable.Net.Wrapper;
using Microsoft.AspNetCore.Mvc;
using OlympicsWeb.Data;
using OlympicsWeb.Models;

namespace OlympicsWeb.Controllers
{
    public class ChartsController : Controller
{
    private readonly ApplicationDbContext _context;
    public ChartsController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> ChartData() {
        Game[] games = GetGames();

        var data = games
            .GroupBy(_ => _.Continent)
            .Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(cp => cp.Count)
            .ToList();

        //let's instantiate the DataTable.
        var dt = new Google.DataTable.Net.Wrapper.DataTable();
        dt.AddColumn(new Column(ColumnType.String, "Name", "Name"));
        dt.AddColumn(new Column(ColumnType.Number, "Count", "Count"));

        foreach (var item in data) {
            Row r = dt.NewRow();
            r.AddCellRange(new Cell[] {
                new Cell(item.Name),
                new Cell(item.Count)
            });
            dt.AddRow(r);
        }

        //Let's create a Json string as expected by the Google Charts API.
        return Content(dt.GetJson());
    }

    private Game[] GetGames()
    {
        var games = _context.Game.ToList();
        return games.ToArray();
    }
   
}
}