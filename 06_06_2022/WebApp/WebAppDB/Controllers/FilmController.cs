using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppDB.Data;
using WebAppDB.Models;

namespace WebAppDB.Controllers
{
    public class FilmController : Controller
    {
        FilmDB db = new FilmDB();
        public IActionResult Index()
        {
            //JOINSIZ
            return View(db.TumFilmler());
        }

        public IActionResult FilmJoin()
        {
            //Expression Tree kullanarak JOIN yazımı...
            //var filmler = db.TumFilmler().Join(db.TumKategoriler(), f => f.KatID, k => k.KatID, (f, k) => new FilmVM { FilmID = f.FilmID, FilmAdi = f.FilmAdi, Sure = f.Sure, KategoriAdi = k.KategoriAdi });

            var filmler = from f in db.TumFilmler()
                          join k in db.TumKategoriler()
                          on f.KatID equals k.KatID
                          select new FilmVM { FilmID=f.FilmID, FilmAdi=f.FilmAdi, Sure=f.Sure, KategoriAdi=k.KategoriAdi  };

            return View(filmler.ToList());

        }

        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = new SelectList(db.TumKategoriler().ToList(), "KatID", "KategoriAdi");
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Film film)
        {
            db.FilmEkle(film);
            return RedirectToAction("Index");
        }

    }
}
