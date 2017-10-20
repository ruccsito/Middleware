using System.Collections.Generic;
using System.Web.Mvc;
using MiddlewareWeb.Data;

namespace MiddlewareWeb.Controllers
{
    public class TrabajosController : Controller
    {
        private TrabajosRepo trRepo;

        public TrabajosController()
        {
            trRepo = new TrabajosRepo();
        }

        // GET: Trabajos
        public ActionResult Index()
        {
            IEnumerable<Trabajo> trabajos = trRepo.Get();
            ViewBag.newJob = TempData["newJob"];
            return View(trabajos);
        }

        [HttpPost]  // POST: Trabajos/Crear
        public ActionResult Crear(Trabajo trabajo)
        {
            // Agregar trabajo a la DB.
            if (ModelState.IsValid)
            {
                trabajo.transcodeStatus = "Creado";
                trRepo.Insert(trabajo);
                trRepo.Save();
                TempData["newJob"] = "true";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Ok()
        {
            ViewBag.Message = "Creado!";
            return View();
        }
    }
}