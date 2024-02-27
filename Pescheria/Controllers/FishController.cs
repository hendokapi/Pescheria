using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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

        // indirizzo per gestire il submit del form della pagina Add
        [HttpPost]
        public IActionResult Add(string name, bool isSeaFish, int price)
        {
            // validare i dati
            var fish = StaticDb.Add(name, isSeaFish, price * 100);
            //return Redirect("https://localhost:7029/fish/details/" + fish.FishId);
            return RedirectToAction("Details", new { id = fish.FishId });
        }

        // pagina con un form per la modififica di un pesce
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var fish = StaticDb.GetById(id);
            // gestire il caso di id non passato
            return View(fish);
        }

        [HttpPost]
        public IActionResult Edit(Fish fish)
        {
            // gestire il caso di id non passato
            return View();
        }

        // rotta (indirizzo) per poter elimanare un pesce

        /*********************/

        public IActionResult GetFile()
        {
            return File("TODO: get the path here", "text/plain");
        }

        public IActionResult GetSlug()
        {
            return Json("questo-slug-buono");
        }
    }
}



