using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Weather.MVC.Controllers
{
    public class LoadArchiveController : Controller
    {
        // GET: LoadArchiveController
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoadArchiveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
