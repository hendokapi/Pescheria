using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Pescheria.Models;


namespace Pescheria.Controllers
{
    public class FishController : Controller
    {
        // lista dei pesci
        [HttpGet]
        public IActionResult Index()
        {
            return View(StaticDb.GetAll());
        }

        // pagina di dettaglio di un singolo pesce
        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (id.HasValue)  // (id is null)
            {
                var fish = StaticDb.GetById(id);
                if (fish is null)
                {
                    return View("Error");
                }
                return View(fish);
            }
            else
            {
                return RedirectToAction("Index", "Home");
                //retrun Redirect("https://localhost:7029");
            }
        }

        // pagina con un form per l'aggiunta di un nuovo pesce
        [HttpGet]
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
        [HttpGet]
        public IActionResult Edit([FromRoute] int? id)
        {
            if (id is null) return RedirectToAction("Index", "Fish");

            var fish = StaticDb.GetById(id);
            if (fish is null) return View("Error");

            return View(fish);
        }

        [HttpPost]
        public IActionResult Edit(Fish fish)
        {
            var updatedFish = StaticDb.Modify(fish);
            if (updatedFish is null) return View("Error");

            return RedirectToAction("Details", new { id = updatedFish.FishId });
        }

        // rotta (indirizzo) per poter elimanare un pesce
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var fish = StaticDb.GetById(id);
            return View(fish);
        }

        [HttpPost]
        public IActionResult Delete(Fish fish)
        {
            var fishDeleted = StaticDb.HardDelete(fish.FishId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SoftDelete(Fish fish)
        {
            var fishDeleted = StaticDb.SoftDelete(fish.FishId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cestino()
        {
            var fishesDeleted = StaticDb.GetAllDeleted();
            return View(fishesDeleted);
        }

        [HttpPost]
        public IActionResult Recover(Fish fish)
        {
            var recoveredFish = StaticDb.Recover(fish.FishId);
            if (recoveredFish is null)
            {
                return RedirectToAction("Cestino");
            }
            return RedirectToAction("Details", new {id = recoveredFish.FishId });
        }

        /*********************/

        public IActionResult GetFile()
        {
            return PhysicalFile(Directory.GetCurrentDirectory() + "\\Contents\\spedire.txt", "text/plain");
        }

        public IActionResult GetSlug()
        {
            return Json("questo-slug-buono");
        }
    }
}



