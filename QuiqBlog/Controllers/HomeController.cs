﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Models;

namespace QuiqBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostBusinessManager postBusinessManager;
        private readonly IHomeBusinessManager homeBusinessManager;

        public HomeController(IPostBusinessManager blogBusinessManager, IHomeBusinessManager homeBusinessManager)
        {
            this.postBusinessManager = blogBusinessManager;
            this.homeBusinessManager = homeBusinessManager;
        }

        public IActionResult Index(string searchString, int? page)
        {
            return View(postBusinessManager.GetIndexViewModel(searchString, page));
        }

        public IActionResult Author(string authorId, string searchString, int? page)
        {
            var actionResult = homeBusinessManager.GetAuthorViewModel(authorId, searchString, page);
            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
    }
}
