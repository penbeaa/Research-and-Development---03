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
        [Required(ErrorMessage = "Please enter a gadget name")]
        public string Name { get; set; }

        [DataType (DataType.MultilineText)]
        [Required(ErrorMessage = "please specify a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage = "Please enter a psoitive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "please specify a category")]
        public string category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMineType {  get; set; }

    }
}
