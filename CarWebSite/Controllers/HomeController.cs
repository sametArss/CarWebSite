using System.Diagnostics;
using BusiniessLayer.Abstract;
using CarWebSite.Models;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMessageService _messageService;
        private readonly IAboutService _aboutService;

        public HomeController (IMessageService messageService, IAboutService aboutService)
        {
            _messageService = messageService;   
            _aboutService = aboutService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            ViewBag.UnreadCount = _messageService.GetAllFilter().Count();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]   
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Contact(Message m )
        {
            if (ModelState.IsValid)
            {
                _messageService.Insert(m);  
                TempData["Success"] = "Mesajınız alınmıştır.";
                return RedirectToAction("Contact");
            }
            return View(m);
        }

        public IActionResult ListContact()
        {
            var value = _messageService.GetAll();
            return View(value);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            _messageService.Delete(id);
            TempData["Delete"] = "Mesaj silindi.";
            return RedirectToAction("ListContact");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var msg = _messageService.GetById(id);
            if (msg != null && !msg.IsRead)
            {
                msg.IsRead = true;
                _messageService.Update(msg);
            }
            return Ok();
        }

        public IActionResult About()
        {
            var value = _aboutService.GetAbout();
            return View(value);
        }

        public IActionResult Detail()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateAbout([FromBody] string aboutMessage)
        {
            var about = _aboutService.GetAbout(); 
            if (about != null)
            {
                about.AboutMessage = aboutMessage;
                _aboutService.Update(about);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
