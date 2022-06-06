﻿using Lab3_WebsiteBigSchool.Models;
using Lab3_WebsiteBigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace Lab3_WebsiteBigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Course
        private readonly ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}