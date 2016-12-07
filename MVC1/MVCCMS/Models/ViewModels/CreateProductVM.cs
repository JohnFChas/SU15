using MVCCMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCMS.Models.ViewModels
{
    public class CreateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
    }
}