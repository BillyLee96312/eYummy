using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecipeApp.Controllers
{
    public class BlogsController : Controller
    {
        public ViewResult BlogsList()
        {
            return View("Blog");
        }
    }
}