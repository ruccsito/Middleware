﻿using System.Web.Mvc;
using MiddlewareWeb.Data;
using MiddlewareWeb.Models;

namespace MiddlewareWeb.Controllers
{
    public class GeneradorController : Controller
    {
        private FormRepo formRepo;

        public GeneradorController()
        {
            formRepo = new FormRepo(new ProyectoEntities());
        }

        // GET: Generador
        public ActionResult Index()
        {
            ViewBag.transcoders = formRepo.GetTranscoders();
            return View();
        }

        public  ActionResult Containers(string option)
        {
            FormData fd = new FormData();
            fd.id = "containersSelect";
            fd.name = "container";
            fd.placeholder = "Seleccionar Contenedor";
            fd.options = formRepo.GetContainers(option);

            return PartialView("Selects", fd);
        }

        public ActionResult VideoCodecs(string option)
        {
            FormData fd = new FormData();
            fd.id = "videoCodecs";
            fd.name = "videoCodec";
            fd.placeholder = "Seleccionar";
            fd.options = formRepo.GetVideoCodecs(option);

            return PartialView("Selects",fd);
        }

        public ActionResult AudioCodecs(string option)
        {
            FormData fd = new FormData();
            fd.id = "audioCodecs";
            fd.name = "audioCodec";
            fd.placeholder = "Seleccionar";
            fd.options = formRepo.GetAudioCodecs(option);

            return PartialView("Selects", fd);
        }

        public ActionResult GetChannels(string option)
        {
            FormData fd = new FormData();
            fd.id = "audioCodecs";
            fd.name = "audioCodec";
            fd.placeholder = "Seleccionar";
            fd.options = formRepo.GetChannels(option);

            return PartialView("Selects", fd);
        }

        public ActionResult GetAudioBitrate(string option)
        {
            FormData fd = new FormData();
            fd.id = "audioCodecs";
            fd.name = "audioCodec";
            fd.placeholder = "Seleccionar";
            fd.options = formRepo.GetAudioBitrate(option);

            return PartialView("Selects", fd);
        }
    }
}
