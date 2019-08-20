
using Microsoft.AspNetCore.Mvc;
using MessagesClient.Models;
using System;

namespace MessagesClient.Controllers
{
    public class Chatcontroller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.allMessages = Message.GetMessages();

            return View();
        }
        [HttpPost]
        public IActionResult Index(Message message)
        {
            Console.WriteLine("INDEX CERATE");
            Message.PostMessage(message);
            return RedirectToAction("Index");
        }

        public void PostMessage()
        {
            Message testMessage = new Message();
            testMessage.MessageNote = "note note note";
            testMessage.MessageNumber = 42;
            testMessage.MessageText = "text";
            testMessage.UserName = "dragonslayer555";
            Message.PostMessage(testMessage);
        }
    }
}