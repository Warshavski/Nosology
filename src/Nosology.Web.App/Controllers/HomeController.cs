using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Escyug.Nosology.Models;
using Escyug.Nosology.Models.Repositories;


namespace Escyug.Nosology.Web.App.Controllers
{
    [Authorize]
    public sealed class HomeController : Controller
    {
        private readonly IMainTextBlockRepository _mainTextRepository;

        public HomeController(IMainTextBlockRepository mainTextRepository)
        {
            _mainTextRepository = mainTextRepository;
        }

        public async Task<ActionResult> Index()
        {
            var mainText = await _mainTextRepository.GetAboutInfoAsync();

            ViewBag.Title = "Главная";
            ViewBag.MainText = mainText;

            if (Request.IsAjaxRequest())
            {
                return PartialView("IndexPartial");
            }
            else
            {
                var user = Session["user"] as User;
                return View(user);
            }
        }

       
    }
}