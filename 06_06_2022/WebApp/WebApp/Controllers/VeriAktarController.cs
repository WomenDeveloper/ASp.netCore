global using WebApp.Models; //Core 6 ile geldi...
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class VeriAktarController : Controller
    {
        //Controller => VIEW
        //Veri aktarımı ...
        //1-ViewData
        //2-ViewBag   ***
        //3-TempData
        //4-Model     ***
        //5-ViewModel **

        public IActionResult Index()
        {
            ViewData["Message"] = "İyi günler"; //Dictionary =>Key,Value Pairs
            ViewBag.Mesaj = "Günaydin";         //dynamic => C# 4.0
            ViewData["Veri"] = "Veriler veriler...";

            //Veri Kolleksiyon olursa
            List<string> sehirler = new List<string>() { "Istanbul", "Ankara", "Bursa", "Zonguldak" };

            //View tarafında tip donusumu yapılmalı...
            ViewData["Cities"] = sehirler;
            //View tarafında tip donusumu yapmaya gerek yok...
            ViewBag.Sehirler = sehirler;

            //Veri Model olursa
            Urun urun = new Urun() { UrunID=12, UrunAdi="Urun 1", Fiyat=12 };

            ViewData["product"] = urun;
            ViewBag.Urun = urun;

            List<Urun> urunler = new List<Urun> {
            new Urun() { UrunID=12, UrunAdi="Urun 1", Fiyat=12 },
            new Urun() { UrunID=16, UrunAdi="Urun 2", Fiyat=18 },
            new Urun() { UrunID=18, UrunAdi="Urun 3", Fiyat=86 }
            };

            ViewData["products"] = urunler;
            ViewBag.Urunler = urunler;


            //Tempdata Kullanımı
            //Controller dan View'e veri aktarabileceği gibi
            //Aksiyonlara da veri aktarabilir...
            //Veriyi kalıcı hale getirmek için Keep() metodu kullanılır aksi durumda ilk kullanımından sonra siler...
            TempData["temp"] = "gizli veri...";
            TempData.Keep();

            return View();
        }


        public IActionResult VeriGoster()
        {
            return Content(TempData["temp"].ToString());
        }

        public IActionResult UrunGoster()
        {
            Urun urun = new Urun() { UrunID = 12, UrunAdi = "Urun 1", Fiyat = 12 };
 
            //View içerisinde kullanılacak olan verilerin bulunduğu nesne...

            //Tanımlarken @model
            //Kullanırken @Model

            return View(urun);
        }

        public IActionResult UrunleriGoster()
        {
            List<Urun> urunler = new List<Urun> {
            new Urun() { UrunID=12, UrunAdi="Urun 1", Fiyat=12 },
            new Urun() { UrunID=16, UrunAdi="Urun 2", Fiyat=18 },
            new Urun() { UrunID=18, UrunAdi="Urun 3", Fiyat=86 }
            };

            //View içerisinde kullanılacak olan verilerin bulunduğu nesne...

            return View(urunler);
        }

        public IActionResult Fatura() {

            //FaturaVM içerisine veri doldurulmalı...
            return View(new FaturaVM());
        }
    }
}
