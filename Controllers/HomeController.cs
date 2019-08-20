
using Microsoft.AspNetCore.Mvc;
using MessagesClient.Models;
using System;

namespace MessagesClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            return View();

        }
    }
}