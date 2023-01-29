﻿using BookStore2.Data;
using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.BookStoreUsers.ToList();
            List<UserViewModel> userList = new List<UserViewModel>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var UserViewModel = new UserViewModel()
                    {
                        Id = user.Id,
                        Name = user.Name
                    };
                    userList.Add(UserViewModel);
                }
                return View(userList);
            }
            return View(userList);
        }
        public IActionResult AddUser(UserViewModel userData)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel()
                {
                    Id = userData.Id,
                    Name = userData.Name,
                };
                _context.BookStoreUsers.Add(user);
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
        public IActionResult Edit(int Id)
        {
            try
            {
                var author = _context.BookStoreUsers.SingleOrDefault(x => x.Id == Id);
                if (author != null)
                {
                    var UserView = new UserViewModel()
                    {
                        Id = author.Id,
                        Name = author.Name
                    };
                    return View(UserView);
                }
                else
                {
                    TempData["errorMessage"] = $"Author details are not avaliable with Id : {Id}";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["error Message"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult UpdateUser(UserViewModel userUpdateData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = new UserModel()
                    {
                        Id = userUpdateData.Id,
                        Name = userUpdateData.Name
                    };
                    _context.BookStoreUsers.Update(book);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Author Updated Successfully";
                    return View();
                }
                else
                {
                    TempData["errorMessage"] = "Couldn't update data";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return RedirectToAction("Index");


            }
        }
        public IActionResult DeleteUser()
        {
            return View();
        }
    }
}
