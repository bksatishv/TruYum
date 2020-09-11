using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruYum.Models;

namespace TruYum.ViewModels
{
    public class ItemFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}