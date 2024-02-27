using Microsoft.AspNetCore.Mvc;
using Pescheria.Models;


namespace Pescheria.Controllers
{
    public class FishController : Controller
    {
        // lista dei pesci
        public IActionResult Index()
        {
            ViewBag.method = Request.Method;
            ViewBag.saluto = "Ciao a tutti";

            return View(StaticDb.GetAll());
        }

        // pagina di dettaglio di un singolo pesce
        public IActionResult Details([FromRoute] int? id)
        {
            if (id.HasValue)  // (id is null)
            {
                return View(StaticDb.GetById(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
                //retrun Redirect("https://localhost:7029");
            }
        }

        // pagina con un form per l'aggiunta di un nuovo pesce
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult GetSlug()
        {
            return Json("questo-slug-buono");
        }

        public IActionResult GetFile()
        {
            return File("TODO: get the path here", "text/plain");
        }

        // pagina con un form per la modififica di un pesce
        public IActionResult Edit(int? id)
        {
            // gestire il caso di id non passato
            return View();
        }

        // rotta (indirizzo) per poter elimanare un pesce
    }
}



