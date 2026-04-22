using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entites;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetRepository myrepository;
        public GadgetController(IGadgetRepository gadgetRepository)
        {
            this.myrepository = gadgetRepository;
        }

        public int PageSize = 4;

        public ViewResult List(string category, int page = 1)
        {
            GadgetsListViewModel model = new GadgetsListViewModel
            {
                Gadgets = myrepository.Gadgets
                                              .Where(g => category == null || g.category == category)
                                              .OrderBy(g => g.GadgetID)
                                              .Skip((page - 1) * PageSize)
                                              .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                 myrepository.Gadgets.Count() :
                                 myrepository.Gadgets.Where
                                       (e => e.category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }


        public FileContentResult GetImage(int gadgetId)
        {
            Gadget gadg = myrepository.Gadgets.FirstOrDefault(g => g.GadgetID == gadgetId);



            if (gadg != null)
            {
                return File(gadg.ImageData, gadg.ImageMineType);

            }
            else
            {
                return null;
            }
        }
    }
}