using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Escyug.Nosology.Models;
using Escyug.Nosology.Models.Repositories;

using Escyug.Nosology.Web.App.ViewModels;

namespace Escyug.Nosology.Web.App.Controllers
{
    [Authorize]
    public class DownloadsController : Controller
    {
        private readonly IFilesRepository _filesRepository;

        public DownloadsController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        //
        // GET: files
        /**
         * GET: files
         * 
         * Load all files and retun its in view
         */
        [HttpGet]
        public ActionResult Index()
        {
            var user = Session["user"] as User;
            if (user != null)
            {
                ViewBag.Title = "Загрузки";

                var files = _filesRepository.GetFiles();
                var filesVM = new List<FileViewModel>();
                foreach (var file in files)
                    filesVM.Add(CreateViewModelFile(file));

                if (Request.IsAjaxRequest())
                {
                    return PartialView("IndexPartial", filesVM);
                }
                else
                {
                    return View(filesVM);
                }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [Authorize]
        public ActionResult DownloadFile(string fileLink)
        {
            try
            {
                string rootFolderPath = AppDomain.CurrentDomain.BaseDirectory;

                byte[] fileBytes =
                    System.IO.File.ReadAllBytes(rootFolderPath + "\\App_Data\\files\\" + fileLink);

                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileLink);
            }
            catch (System.IO.FileNotFoundException)
            {
                return View("Error", new { Title = "File not found." });
            }
        }

        private FileViewModel CreateViewModelFile(Models.File file)
        {
            var fileViewModel = new ViewModels.FileViewModel();

            fileViewModel.Id = file.Id;
            fileViewModel.Title = file.Title;
            fileViewModel.Link = file.Link;

            fileViewModel.IconStyle = IconsList.GetIconTypeName(file.Type);

            return fileViewModel;
        }  
    }
}