using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Weather.MVC.Models;
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
    public ActionResult Create(IFormCollection collection)
    {
        IFormFile? formFile = null;
        try
        {
            foreach (var file in collection.Files)
            {
                formFile = file;
                using var stream = file.OpenReadStream();
                _weatherParser.Parse(stream);
            }
            return View(nameof(Index), "Files uploaded successfully");
        }
        catch (Exception exc)
        {
            string message = formFile is null ? exc.Message : $"Error in file: {formFile.FileName}. " + exc.Message;
            return View(nameof(Index), message);
        }
    }
}
