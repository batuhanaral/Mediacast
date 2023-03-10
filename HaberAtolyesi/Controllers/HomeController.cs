using HaberAtolyesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace HaberAtolyesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DataContext db = new DataContext();

            // haberler = db.Habers.ToList();
            var haberler = db.Habers
             .OrderByDescending(e => e.Id)
             .Take(20)
            .ToList();
            return View(haberler);
        }
        public ActionResult Gundem()
        {
            DataContext db = new DataContext();
            var gundem = db.Habers
           .Where(b => b.Kategori == "Gundem")
            .OrderByDescending(b => b.Id)
             .ToList();
            return View(gundem);
        }
        
        public ActionResult Kent()
        {
            DataContext db = new DataContext();
            var kent = db.Habers
           .Where(b => b.Kategori == "Kent")
            .OrderByDescending(b => b.Id)
             .ToList();
            return View(kent);
        }
        public ActionResult Sanat()
        {
            DataContext db = new DataContext();
            var sanat = db.Habers
           .Where(b => b.Kategori == "Sanat")
            .OrderByDescending(b => b.Id)
             .ToList();
            return View(sanat);
        }
        public ActionResult Kadin()
        {
            DataContext db = new DataContext();
            var kadın = db.Habers
           .Where(b => b.Kategori == "Kadın")
            .OrderByDescending(b => b.Id)
             .ToList();
            return View(kadın);
        }
        public ActionResult Saglik()
        {
            DataContext db = new DataContext();
            var saglık = db.Habers
           .Where(b => b.Kategori == "Saglık")
            .OrderByDescending(b => b.Id)
             .ToList();
            return View(saglık);
        }
        public ActionResult Spor()
        {
            DataContext db = new DataContext();
            var spor = db.Habers
           .Where(b => b.Kategori == "Spor")
            .OrderByDescending(b => b.Id)
             .ToList();
            return View(spor);
        }
        public ActionResult All()
        {
            DataContext db = new DataContext();

            // haberler = db.Habers.ToList();
            var haberler = db.Habers
             .OrderByDescending(e => e.Id)
            .ToList();
            return View(haberler);
        }
        public ActionResult PodcastList()
        {
            DataContext db = new DataContext();

            // haberler = db.Habers.ToList();
            var podcast = db.Bolumlers
           .Where(b => b.Kategori == "podcast")
            .OrderByDescending(b => b.Id)
             .ToList();

            return View(podcast);

        }

        public ActionResult YoutubeList()
        {
            DataContext db = new DataContext();

            // haberler = db.Habers.ToList();
            var youtube = db.Bolumlers
           .Where(b => b.Kategori == "youtube")
            .OrderByDescending(b => b.Id)
             .ToList();

            return View(youtube);

        }

        public ActionResult Detay(int id)
        {
            DataContext db = new DataContext();
            var ogel = db.Habers.FirstOrDefault(x => x.Id == id);

            if (ogel != null)
            {
                // Öğe varsa, view modeline dönüştür ve view'e gönder
                var viewModel = new HaberViewModel
                {
                    Baslik = ogel.Baslik,
                    Konu = ogel.Konu,
                    Fotograf = ogel.Fotograf,
                    Create_Time = ogel.Create_Time,
                    // vb. diğer özellikler
                };

                return View(viewModel);
            }
            return View("Index");
        }
    }
}