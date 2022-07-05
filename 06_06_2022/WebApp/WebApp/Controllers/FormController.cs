using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Yakala(int id)
        {
                //GET:Aksiyonun parametresi olarak querystring uzerinden gelen veriler eklenebilir...  
                 return Content( id + "Gelen Degerlerler" +Request.QueryString);
        }

        [HttpPost]
        public IActionResult Yakala()
        {
            //POST:1. Yontem
            //Request.Form üzerinden
            int id = Convert.ToInt32(Request.Form["id"]);
            string ad = Request.Form["ad"].ToString();
            double fiyat = Convert.ToDouble(Request.Form["fiyat"]);
            string renk = Request.Form["renk"].ToString();
            return Content(id+ " " + ad + " " + fiyat + " " +renk);
        }


        [HttpPost]
        public IActionResult Yakala2(int id, string ad, double fiyat , string renk)
        {
            //POST:2. Yontem
            //Aksiyon parametreleri üzerinden
            //parametre isimleri View deki name alanları ile aynı olmalı... 
           
            return Content(id + " " + ad + " " + fiyat + " " + renk);
        }

        [HttpPost]
        public IActionResult Yakala3(IFormCollection form)
        {
            //POST:3. Yontem
            //IFormCollection arayuzu üzerinden
            //form[""] isimleri View deki name alanları ile aynı olmalı... 
            return Content(form["id"] + " " + form["ad"] + " " + form["fiyat"] + " " + form["renk"]);
        }

        

        [HttpPost]
        public IActionResult Yakala4(Urun urun)
        {
            //POST:4. Yontem
            //Model üzerinden
            //UrunID ile UrunAdi gelmez => id=>UrunID, ad =>UrunAdi
            return Content(urun.UrunID + " "+ urun.UrunAdi +" "+ urun.Fiyat + " "+urun.Renk);
        }

        //HtmlHelper, TagHelper
        [HttpPost]
        public IActionResult Yakala5(Urun urun)
        {
            //POST:5. Yontem
            //Model üzerinden
            return Content(urun.UrunID + " " + urun.UrunAdi + " " + urun.Fiyat + " " + urun.Renk);
        }
    }
}
