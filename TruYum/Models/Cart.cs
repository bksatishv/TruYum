using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYum.Models
{
    //Create the Cart model with the required fields and data annotations.
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        //Create a reference to the MenuItem class to create foreignkey reference
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
    }
}