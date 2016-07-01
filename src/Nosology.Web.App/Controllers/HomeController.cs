using System.Threading.Tasks;
using System.Web.Mvc;

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

        /**
         * GET: /Home/Index
         * 
         * Try to load main form
         */
        public async Task<ActionResult> Index()
        {
            var user = Session["user"] as User;
            if (user != null)
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
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }   
        }
    }
}