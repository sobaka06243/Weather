using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Weather.Services.Services;

namespace Weather.MVC.Controllers;

public class LoadArchiveController : Controller
{
    private readonly IWeatherParser _weatherParser;

    public LoadArchiveController(IWeatherParser weatherParser)
    {
        _weatherParser = weatherParser;
    }

    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(IFormCollection collection)
    {
        try
        {
            foreach (var file in collection.Files)
            {
                using var stream = file.OpenReadStream();
                await _weatherParser.Parse(stream);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
