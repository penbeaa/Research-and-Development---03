using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using System.Linq;
using GadgetHub.Domain.Entities;
using GadgetHub.Domain.Entites;

namespace GadgetHub.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IGadgetRepository repository;
        public AdminController(IGadgetRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Gadgets);
        }

        public ViewResult Edit(int gadgetID)
        {
            Gadget gadget = repository.Gadgets
                .FirstOrDefault(g => g.GadgetID == gadgetID);
            return View(gadget);
        }

        [HttpPost]
        public ActionResult Edit(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGadget(gadget);
                TempData["message"] = string.Format
                    ("{0} has been saved", gadget.Name);
                return RedirectToAction("Index");
            }

            else
            {
                return View(gadget);
            }
        }

        public ActionResult Create()
        {
            return View("Edit", new Gadget());
        }

        [HttpPost]
        public ActionResult Delete(int gadgetID)
        {
            repository.DeleteGadget(gadgetID);
            TempData["message"] = "Gadget was deleted";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGadget(gadget);
                TempData["message"] = $"{gadget.Name} has been created";
                return RedirectToAction("Index");
            }

            return View("Edit", gadget);
        }
    }
}

