using HaberAtolyesi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberAtolyesi.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Deneme()
        {
            return View();
        }
        // GET: Admin
        public ActionResult Index()
        {
            var haberler = db.Habers
           .OrderByDescending(e => e.Id)
          .ToList();
            return View(haberler);

        }
        public ActionResult BolumEkleS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BolumEkleS(BolumViewModel model)
        {

            Bolumler bolumler = new Bolumler();
            if (ModelState.IsValid)
            {
                bolumler.Baslik = model.Baslik;
                bolumler.Link = model.Link;
                bolumler.Kategori = "podcast";
                db.Bolumlers.Add(bolumler);
                db.SaveChanges();
                return RedirectToAction("PodcastList", "Admin");

            }
            else
            {
                ModelState.AddModelError("", "Alanlar boş bırakılmaz");
                ViewData["ErrorMessage"] = "Alanlar boş Bırakılmaz ";
                return View(model);
            }

        }

        public ActionResult BolumEkleY()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BolumEkleY(BolumViewModel model)
        {

            Bolumler bolumler = new Bolumler();
            if (ModelState.IsValid)
            {
                bolumler.Baslik = model.Baslik;
                bolumler.Link = model.Link;
                bolumler.Kategori = "youtube";
                db.Bolumlers.Add(bolumler);
                db.SaveChanges();
                return RedirectToAction("YoutubeList", "Admin");

            }
            else
            {
                ModelState.AddModelError("", "Alanlar boş bırakılmaz");
                ViewData["ErrorMessage"] = "Alanlar boş Bırakılmaz ";
                return View(model);
            }

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
            var podcast = db.Bolumlers
           .Where(b => b.Kategori == "youtube")
            .OrderByDescending(b => b.Id)
             .ToList();

            return View(podcast);

        }

        public ActionResult HaberEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HaberEkle(Haber model, string Photo, string haber,  string kategori )
        {
            Haber hb = new Haber();
            hb.Konu = haber;
            hb.Baslik = model.Baslik;
            hb.Ozet = model.Ozet;
            hb.Kategori=kategori;   
            hb.Create_Time = DateTime.Now;
            hb.Update_Time = DateTime.Now;
            if (Request.Files.Count != 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);

                string yol = "~/Photo/" + dosyaAdi;
                if (Photo != null)
                {
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    hb.Fotograf = dosyaAdi;
                }

                db.Habers.Add(hb);
                db.SaveChanges();
            }
            TempData["SuccessMessageH"] = "Haber Ekleme Başarılı";
            return RedirectToAction("HaberEkle");
        }






        public ActionResult Update(int Id)
        {
            var haber = db.Habers.FirstOrDefault(x => x.Id == Id);
            if (haber != null)
            {
                HaberViewModel haberViewModel = new HaberViewModel()
                {
                    Id = Id,
                    Baslik = haber.Baslik,
                    Konu = haber.Konu,
                    Ozet = haber.Ozet,
                    Create_Time = DateTime.Now,
                    Fotograf = haber.Fotograf,
                };
                return View(haberViewModel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(HaberViewModel model, string haber, string Photo)
        {

            var haber2 = db.Habers.FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                if (haber2 != null)
                {
                    if (Photo != null)
                    {
                        haber2.Fotograf = Photo;
                        if (Request.Files.Count != 0)
                        {
                            string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                            string uzanti = Path.GetExtension(Request.Files[0].FileName);

                            string yol = "~/Photo/" + dosyaAdi;

                            Request.Files[0].SaveAs(Server.MapPath(yol));
                            haber2.Fotograf = dosyaAdi;

                        }
                    }
                    else
                    {
                        haber2.Fotograf = haber2.Fotograf;
                    }
                    haber2.Id = model.Id;
                    haber2.Konu = haber;
                    haber2.Baslik = model.Baslik;
                    haber2.Ozet = model.Ozet;
                    haber2.Create_Time = DateTime.Now;
                    haber2.Update_Time = DateTime.Now;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Alanlar boş bırakılmaz");
                ViewData["ErrorMessage"] = "Alanlar boş Bırakılmaz ";
                return View(model);
            }

        }

        public ActionResult DeleteProgram(int Id)
        {
            var bolum = db.Bolumlers.FirstOrDefault(x => x.Id == Id);
            db.Bolumlers.Remove(bolum);
            db.SaveChanges();
            if (bolum.Kategori == "podcast")
            {
                TempData["SuccessMessageP"] = "Podcast Silme Başarılı";
                return RedirectToAction("PodcastList");
            }
            else
            {
                TempData["SuccessMessageY"] = "Youtube Silme Başarılı";
                return RedirectToAction("YoutubeList");
            }
        }


        public ActionResult Delete(int Id)
        {
            var haber = db.Habers.FirstOrDefault(x => x.Id == Id);
            db.Habers.Remove(haber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}