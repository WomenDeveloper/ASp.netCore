using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BaslangicController : Controller
    {
        public IActionResult Index()
        {
            //View klasorunde => Baslangic içerisinde Index'i arar...
            return View();
        }

        public IActionResult AnaSayfa()
        {
            //View klasorunde => Baslangic içerisinde Index'i arar...
            return View("Index");
        }

        public string Deneme()
        {
            return "Merhaba MVC";
        }

        public IActionResult Merhaba()
        {
            return Content("Merhaba Dünya!!!");
        }

        public IActionResult Selam(string ad)
        {
            return Content("Selam " + ad);
        }

        public IActionResult Data()
        {
            List<string> sehirler = new List<string>() {"Istanbul","Ankara","Bursa","Zonguldak"};

            return Json(sehirler);
        }
    }
}
