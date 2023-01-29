﻿using BookStore2.Data;
using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStore2.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var admins = _context.BookStoreAdmins.ToList();
            List<AdminViewModel> adminList = new List<AdminViewModel>();

            if (admins != null)
            {
                foreach (var admin in admins)
                {
                    var AdminViewModel = new AdminViewModel()
                    {
                        Id = admin.Id,
                        Name = admin.Name
                    };
                    adminList.Add(AdminViewModel);
                }
                return View(adminList);
            }
            return View(adminList);
        }
        [HttpPost]
        public IActionResult AddAdmin(AdminViewModel adminData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var admin = new AdminModel()
                    {
                        Id = adminData.Id,
                        Name = adminData.Name,
                    };
                    _context.BookStoreAdmins.Add(admin);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return View();
                }
            }
            catch (Exception e)
            {

                TempData["errorMessage"] = e.Message;
                return View("Index");
            }

        }
        [HttpPost]

        public IActionResult UpdateAdmin(AdminViewModel model)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var admin = new AdminModel()
                    {
                        Id = model.Id,
                        Name = model.Name,
                    };
                    _context.BookStoreAdmins.Update(admin);
                    _context.SaveChanges();
                    TempData["sucessMessage"] = "Admin details Updated Successully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return View();
            }
            //return View();

        }
        [HttpPost]//2
        public IActionResult DeleteAdmin(AdminViewModel model)
        {
            try
            {
                var admin = _context.BookStoreAdmins.SingleOrDefault(x =>x.Id== model.Id);
                if(admin != null)
                {
                    _context.BookStoreAdmins.Remove(admin);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Admin deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not avaliable with the Id:{model.Id}";
                    return RedirectToAction("index");
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return View();

            }


        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {

            try
            {
                var admin = _context.BookStoreAdmins.SingleOrDefault(x => x.Id == Id);
                if (admin != null)
                {
                    var adminView = new AdminViewModel()
                    {
                        Id = admin.Id,
                        Name = admin.Name
                    };
                    return View(adminView);
                }
                else
                {
                    TempData["errorMessage"] = $"Admin details are not avaliable with Id : {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error Message"] = e.Message;
                return RedirectToAction("Index");
            }





        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var admin = _context.BookStoreAdmins.SingleOrDefault(x => x.Id == Id);
                if (admin != null)
                {
                    var adminView = new AdminViewModel()
                    {
                        Id = admin.Id,
                        Name = admin.Name,
                    };
                    return View(adminView);
                }
                else
                {
                    TempData["errorMessage"] = "Admin details are not avaliable with Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        //// [HttpPost]
        // public IActionResult DeleteAdmin(AdminViewModel admin)
        // {
        //     try
        //     {
        //         var Admin = _context.BookStoreAdmins.SingleOrDefault(x => x.Id == admin.Id);
        //         if (Admin != null)
        //         {

        //             _context.BookStoreAdmins.Remove(Admin);
        //             _context.SaveChanges();
        //             TempData["successMessage"] = "Admin deleted successfully";
        //             return RedirectToAction("Index");
        //         }
        //         else
        //         {
        //             TempData["errormessage"] = $"Admin is not avaliable with{admin.Name}";
        //             return RedirectToAction("Index");

        //         }
        //     }
        //     catch (Exception e )
        //     {
        //         TempData["errormessage"] = e.Message;
        //         return RedirectToAction("Index");
        //     }
        // }


        // }

    }
}



