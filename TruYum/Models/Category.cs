using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYum.Models
{
    //Create class for Category with Id and Name data fields
    //Use data annotation Key for the Id field
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}