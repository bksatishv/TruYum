using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYum.Models
{
    //Create the MenuItem model with the required fields and data annotations

    //Use the data annotation  DataType as Date for  DateOfLaunch.
    //This will help to display the date field in the format that is expected.

    //Reference the CategoryId and the Category class reference as Foreign key in the MenuItem class
    public class MenuItem
    {
        //Use data annotation Keyfor the Id field
        //Use data annotation Requiredfor the Name& Pricefields.
        //This data annotation will show the default message on the UI while creating a MenuItem.
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float? Price { get; set; }

        //Use data annotation Displaywithname attribute for the fields, FreeDelivery and DateOfLaunch.
        //This will ensure that the detail listed on the UI will be appropriate.
        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }
        public bool Active { get; set; }

        [Display(Name = "Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfLaunch { get; set; }
        //The ApplyFormatInEditModebeing set  to  true  is  used to  ensure that 
        //the date is filled in correct manner in the text box

        //Reference the CategoryId and the Category class reference as Foreign key in the MenuItem class
        public Category Category { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }

    }
}