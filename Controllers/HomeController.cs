
using Microsoft.AspNetCore.Mvc;
using MessagesClient.Models;

namespace MessagesClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allMessages = Message.GetMessages();
            PostMessage();
            return View(allMessages);
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