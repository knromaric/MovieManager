﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieManager.Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            return View(id);
        }
    }
}