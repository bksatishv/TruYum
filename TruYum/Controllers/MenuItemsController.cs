using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum.Models;
using TruYum.ViewModels;
using System.Data.Entity;

namespace TruYum.Controllers
{
    public class MenuItemsController : Controller
    {
        TruYumContext context;

        public MenuItemsController()
        {
            context = new TruYumContext();
        }
        // GET: MenuItems
        //Create a boolean parameter “isAdmin”to the Index method and set the default value to false.
        //This would be used to filter the menu item listing for Admin and Customer
        public ActionResult Index(bool isAdmin=false)
        {
            if (isAdmin)
                return View("MenuItemAdmin",context.MenuItems.Include(m => m.Category).ToList());
            else
                return View("MenuItemUser", context.MenuItems.Include(m => m.Category).ToList());
        }

        //Display form to add MenuItem
        [HttpGet]
        public ActionResult Add()
        {
            var Categories = context.Categories.ToList();
            var viewModel = new ItemFormViewModel
            {
                Categories = Categories,
                MenuItem = new MenuItem()
            };
            return View("ItemForm",viewModel);
        }

        //Method to add or edit MenuItem 
        [HttpPost]
        public ActionResult Add(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                if (menuItem.Id != 0)
                {
                    System.Diagnostics.Debug.Write("Edit");
                    var menuItemFromDb = context.MenuItems.Single(m => m.Id == menuItem.Id);
                    menuItemFromDb.Active = menuItem.Active;
                    menuItemFromDb.Price = menuItem.Price;
                    menuItemFromDb.FreeDelivery = menuItem.FreeDelivery;
                    context.SaveChanges();
                }
                else
                {
                    System.Diagnostics.Debug.Write("Add " + menuItem.Id);
                    context.MenuItems.Add(menuItem);
                    context.SaveChanges();
                }
                return View("MenuItemAdmin", context.MenuItems.Include(m => m.Category).ToList());

            }
            else
            {
                var Categories = context.Categories.ToList();

                var viewModel = new ItemFormViewModel
                {
                    Categories = Categories,
                    MenuItem = menuItem
                };
                return View("ItemForm", viewModel);
            }

        }

        //Display form to edit MenuItem
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menuItem = context.MenuItems.Single(m => m.Id == id);
            var Categories = context.Categories.ToList();
            var viewModel = new ItemFormViewModel
            {
                Categories = Categories,
                MenuItem = menuItem
            };
            return View("ItemForm", viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var cart = new Cart { MenuItemId = id };
            context.Carts.Add(cart);
            context.SaveChanges();
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            var Carts = context.Carts.Include(c=>c.MenuItem).ToList();

            return View("Cart",Carts);
        }

        public ActionResult RemoveItemFromCart(int id)
        {
            var cart = context.Carts.Single(c => c.Id == id);
            context.Carts.Remove(cart);
            context.SaveChanges();
            return RedirectToAction("ViewCart");
        }
    }
}