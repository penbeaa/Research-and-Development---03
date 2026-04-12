using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GadgetHub.Domain.Entites
{
    public class Gadget
    {
        [HiddenInput (DisplayValue = false)]
        public int GadgetID { get; set; }
        public string Name { get; set; }

        [DataType (DataType.MultilineText)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string category { get; set; }

    }
}
