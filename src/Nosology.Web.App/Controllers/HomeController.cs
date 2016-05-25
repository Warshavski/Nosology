using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Escyug.Nosology.Models.Repositories;


namespace Escyug.Nosology.Web.App.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly IMainTextBlockRepository _mainRepository;

        public HomeController(IMainTextBlockRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public async Task<ActionResult> Index()
        {
            var mainText = await _mainRepository.GetAboutInfoAsync();
            ViewBag.TextBlock = mainText;

            return View();
        }

        public ActionResult Documents()
        {
            return RedirectToAction("Index", "Documents");
        }

        public ActionResult Downloads()
        {
            return RedirectToAction("Index", "Downloads");
        }
    }
}