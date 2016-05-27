using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escyug.Nosology.Web.App.Controllers
{
    [Authorize]
    public class DownloadsController : Controller
    {
        // GET: Download
        public ActionResult Index()
        {
            return View();
        }
    }
}