using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chinookmssqlmvc.Models;

namespace chinookmssqlmvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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

    public async Task<IActionResult> Chinook(HttpClient client) {
        var data = new List<Artist>();

        var response = await client.GetAsync(Environment.GetEnvironmentVariable("CHINOOKAPIRUL"));

        if (response.IsSuccessStatusCode) {
            data = await response.Content.ReadFromJsonAsync<List<Artist>>();
        }

        return View(data);
    }
}
