using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SatisMVC.Controllers
{
    public class HomeController : Controller
    {
        private Db_incelemeEntities db = new Db_incelemeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult admin()
        {
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Uyeler uye = new Uyeler();
            uye.rol_id = 2;
            uye.uye_adi = form["nameCheck"].Trim();
            uye.uye_soyad = form["surnameCheck"].Trim();
            uye.uye_mail = form["emailCheck"].Trim();
            uye.uye_sifre = form["passwordCheck"].Trim();
            uye.uye_tel = Int32.Parse(form["tlfCheck"].Trim());

            db.Uyelers.Add(uye);
            db.SaveChanges();
            return View("/Views/Home/Index.cshtml");
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();

            string eMail = form["emailCheck"].Trim();
            string sifre = form["passwordCheck"].Trim();
            var sorgu = (from q in db.Uyelers where q.uye_mail == eMail && q.uye_sifre == sifre select new { q.uye_mail, q.uye_sifre, q.uye_id, q.rol_id }).FirstOrDefault();


            if (sorgu.rol_id == 1)
            {
                Session.Add("kullaniciAdmin", sorgu.uye_id);

                return View("/Views/Home/admin.cshtml");
            }

            if (sorgu.rol_id == 2)
            {
                Session.Add("kullanici", sorgu.uye_id);

                return View("/Views/Home/Index.cshtml");
            }
            else
                return View();


        }
        public ActionResult Cikis()
        {
            Session.RemoveAll();
            return View("/Views/Home/Index.cshtml");
        }

        public ActionResult araclar()
        {
            return View();

        }
        public ActionResult telefonlar()
        {
            return View();
        }
        public ActionResult bilgisayarlar()
        {
            return View();
        }
        public ActionResult fotografMakineler()
        {
            return View();
        }


        public ActionResult tabletler()
        {
            return View();
        }

        [HttpGet]
        public ActionResult adminaracekle()
        {
            return View();
        }


        [HttpGet]
        public ActionResult adminaracduzenle(string duzenle)
        {
            try
            {
                Db_incelemeEntities db = new Db_incelemeEntities();
                if (duzenle != null)
                {
                    int num = Int32.Parse(duzenle);
                    var duzen = (from q in db.Otomobils where q.otomobil_id == num select q).FirstOrDefault();

                    return View("adminaracduzenle", duzen);

                }
                return View();

            }
            catch (Exception ex)
            {

                return View();
            }


        }
        [HttpPost]
        public ActionResult adminaracduzenle(FormCollection forms)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Otomobil model11 = new Otomobil();

            model11.otomobil_id = Int32.Parse(forms["otomobilid"].Trim());
            model11.otomobil_marka = forms["otomobilmarka"].Trim();
            model11.otomobil_model = forms["otomobilmodel"].Trim();
            model11.otomobil_yil = forms["otomobilyil"].Trim();
            model11.otomobil_vites = forms["otomobilvites"].Trim();

            model11.otomobil_km = forms["otomobilkm"].Trim();
            model11.otomobil_kasatipi = forms["otomobilkasatipi"].Trim();
            model11.otomobil_renk = forms["otomobilrenk"].Trim();
            model11.otomobil_motorgucu = forms["otomobilmotorgucu"].Trim();
           



            Otomobil dersCheck = db.Otomobils.Where(w => w.otomobil_id == model11.otomobil_id).FirstOrDefault();
            if (dersCheck != null)
            {
                db.Otomobils.Remove(dersCheck);
                db.SaveChanges();
                db.Otomobils.Add(model11);
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View("/Views/Home/adminaracekle.cshtml");
            }
            ViewBag.Mesaj = "ekleme başarısız";
            return View("/Views/Home/adminaracekle.cshtml");

        }


        [HttpPost]
        public ActionResult adminaracekle(FormCollection forms, string silme,string duzunle)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Otomobil model = new Otomobil();
            if (silme != null)
            {
                int num = Int32.Parse(silme);
                var sil = (from q in db.Otomobils where q.otomobil_id == num select q).FirstOrDefault();
                db.Otomobils.Remove(sil);
                db.SaveChanges();
                ViewBag.Mesaj = "silme başarılı";
                return View();
            }


            model.otomobil_km = forms["arackm"].Trim();
            model.otomobil_marka = forms["aracmarka"].Trim();
            model.otomobil_model = forms["aracmodel"].Trim();
            model.otomobil_motorgucu = forms["aracmotorgucu"].Trim();
            model.otomobil_renk = forms["aracrenk"].Trim();
            model.otomobil_vites = forms["aracvites"].Trim();
            model.otomobil_yil = forms["aracyil"].Trim();
            model.otomobil_kasatipi = forms["arackasatipi"].Trim();


            var dersCheck = (from q in db.Otomobils where q.otomobil_id == model.otomobil_id select new { q.otomobil_id }).FirstOrDefault();
            if (dersCheck == null)
            {
                db.Otomobils.Add(model);
                db.SaveChanges();
                ViewBag.Mesaj = "arac ekleme başarılı";
                return View("/Views/Home/adminaracekle.cshtml");

            }
            ViewBag.Mesaj = "arac ekleme başarısız";
            return View("/Views/Home/adminaracekle.cshtml");
        }
        [HttpGet]
        public ActionResult adminbilgisayarekle()
        {
            return View();
        }
        [HttpGet]
        public ActionResult adminbilgisayarduzenle(string duzenle)
        {
            try
            {
                Db_incelemeEntities db = new Db_incelemeEntities();
                if (duzenle != null)
                {
                    int num = Int32.Parse(duzenle);
                    var duzen = (from q in db.Bilgisayars where q.bilgisayar_id == num select q).FirstOrDefault();

                    return View("adminbilgisayarduzenle", duzen);

                }
                return View();

            }
            catch (Exception ex)
            {

                return View();
            }
            

        }
        [HttpPost]
        public ActionResult adminBilgisayarDuzenle(FormCollection forms)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Bilgisayar model = new Bilgisayar();

            model.bilgisayar_id = Int32.Parse( forms["pcID"].Trim());
            model.bilgisayar_ekrankarti_boyut = forms["ekranBoyut"].Trim();
            model.bilgisayar_ekrankarti_model = forms["ekrankarti"].Trim();
            model.bilgisayar_garanti = forms["garanti"].Trim();
            model.bilgisayar_hafiza = forms["bilgisayarhafiza"].Trim();
            model.bilgisayar_isletim_sistemi = forms["bilgisayarisletim"].Trim();
            model.bilgisayar_marka = forms["bilgisayarmarka"].Trim();
            model.bilgisayar_model = forms["bilgisayarmodel"].Trim();
            model.bilgisayar_ram = forms["bilgisayarram"].Trim();
            model.bilgisayar_boyut = Int32.Parse(forms["bilgisayarBoyut"].Trim());


            Bilgisayar dersCheck = db.Bilgisayars.Where(w => w.bilgisayar_id == model.bilgisayar_id).FirstOrDefault();
            if (dersCheck != null)
            {
                db.Bilgisayars.Remove(dersCheck);
                db.SaveChanges();
                db.Bilgisayars.Add(model);
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View("/Views/Home/adminbilgisayarekle.cshtml");
            }
            ViewBag.Mesaj = "ekleme başarısız";
            return View("/Views/Home/adminbilgisayarekle.cshtml");

        }

        [HttpPost]
        public ActionResult adminbilgisayarekle(FormCollection forms, string silme, string duzenle)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Bilgisayar model = new Bilgisayar();
            if (silme != null)
            {
                int num = Int32.Parse(silme);
                var sil = (from q in db.Bilgisayars where q.bilgisayar_id == num select q).FirstOrDefault();
                db.Bilgisayars.Remove(sil);
                db.SaveChanges();
                ViewBag.Mesaj = "silme başarılı";
                return View();
            }


            model.bilgisayar_ekrankarti_boyut = forms["pcboyut"].Trim();
            model.bilgisayar_ekrankarti_model = forms["ekrankarti"].Trim();
            model.bilgisayar_garanti = forms["garanti"].Trim();
            model.bilgisayar_hafiza = forms["bilgisayarhafiza"].Trim();
            model.bilgisayar_isletim_sistemi = forms["bilgisayarisletim"].Trim();
            model.bilgisayar_marka = forms["bilgisayarmarka"].Trim();
            model.bilgisayar_model = forms["bilgisayarmodel"].Trim();
            model.bilgisayar_boyut = Int32.Parse(forms["bilgisayarBoyut"].Trim());
            model.bilgisayar_ram = forms["bilgisayarram"].Trim();


            var dersCheck = (from q in db.Bilgisayars where q.bilgisayar_id == model.bilgisayar_id select new { q.bilgisayar_id }).FirstOrDefault();
            if (dersCheck == null)
            {
                db.Bilgisayars.Add(model);
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View("/Views/Home/adminbilgisayarekle.cshtml");
            }
            ViewBag.Mesaj = "ekleme başarısız";
            return View("/Views/Home/adminbilgisayarekle.cshtml");

        }
        [HttpGet]
        public ActionResult adminfotografmakinesiekle()
        {
            return View();
        }

        [HttpGet]
        public ActionResult adminfotografmakinesiduzenle(string duzenle)
        {
            try
            {
                Db_incelemeEntities db = new Db_incelemeEntities();
                if (duzenle != null)
                {
                    int num = Int32.Parse(duzenle);
                    var duzen = (from q in db.Fotograf_Makinesi where q.fotoğraf_id == num select q).FirstOrDefault();

                    return View("adminfotografmakinesiduzenle", duzen);

                }
                return View();

            }
            catch (Exception ex)
            {

                return View();
            }


        }
        [HttpPost]
        public ActionResult adminfotografmakinesiduzenle(FormCollection forms)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Fotograf_Makinesi foto1 = new Fotograf_Makinesi();

            foto1.fotoğraf_id = Int32.Parse(forms["fotoid"].Trim());
            foto1.fotoğraf_marka = forms["fotografmarka"].Trim();
            foto1.fotoğraf_model = forms["fotografmodel"].Trim();
            foto1.fotoğraf_cozunurluk = forms["fotografcozunurluk"].Trim();
            foto1.fotoğraf_garanti = forms["fotografgaranti"].Trim();
            foto1.fotoğraf_ekranboyutu = Int32.Parse(forms["fotografekranboyutu"].Trim());


            Fotograf_Makinesi dersCheck = db.Fotograf_Makinesi.Where(w => w.fotoğraf_id == foto1.fotoğraf_id).FirstOrDefault();
            if (dersCheck != null)
            {
                db.Fotograf_Makinesi.Remove(dersCheck);
                db.SaveChanges();
                db.Fotograf_Makinesi.Add(foto1);
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View("/Views/Home/adminfotografmakinesiekle.cshtml");
            }
            ViewBag.Mesaj = "ekleme başarısız";
            return View("/Views/Home/adminfotografmakinesiekle.cshtml");

        }





        [HttpPost]
        public ActionResult adminfotografmakinesiekle(FormCollection form, string silme,string duzenle)
        {

            Db_incelemeEntities db = new Db_incelemeEntities();
            Fotograf_Makinesi foto = new Fotograf_Makinesi();
            if (silme != null)
            {
                int num = Int32.Parse(silme);
                var sil = (from q in db.Fotograf_Makinesi where q.fotoğraf_id == num select q).FirstOrDefault();
                db.Fotograf_Makinesi.Remove(sil);
                db.SaveChanges();
                ViewBag.Mesaj = "silme başarılı";
                return View();
            }
            foto.fotoğraf_marka = form["fotografmarka"].ToString();
            foto.fotoğraf_model = form["fotografmodel"].ToString();
            foto.fotoğraf_cozunurluk = form["fotografcozunurluk"].ToString();
            foto.fotoğraf_garanti = form["fotografgaranti"].ToString();
            foto.fotoğraf_ekranboyutu = float.Parse(form["fotografmakinesiboyut"].ToString());
            db.Fotograf_Makinesi.Add(foto);

            try
            {
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View();
            }
            catch
            {
                ViewBag.Mesaj = "ekleme başarısız";
                return View();
            }

        }


        [HttpGet]
        public ActionResult admintelefonekle()
        {
            return View();
        }

        [HttpGet]
        public ActionResult admintelefonduzenle(string duzenle)
        {
            try
            {
                Db_incelemeEntities db = new Db_incelemeEntities();
                if (duzenle != null)
                {
                    int num = Int32.Parse(duzenle);
                    var duzen = (from q in db.Telefons where q.telefon_id == num select q).FirstOrDefault();

                    return View("admintelefonduzenle", duzen);

                }
                return View();

            }
            catch (Exception ex)
            {

                return View();
            }


        }
        [HttpPost]
        public ActionResult admintelefonduzenle(FormCollection forms)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Telefon model11 = new Telefon();

            model11.telefon_id = Int32.Parse(forms["telefonid"].Trim());
            model11.telefon_marka = forms["telefonmarka"].Trim();
            model11.telefon_model = forms["telefonmodel"].Trim();
            model11.telefon_isletim_sistemi = forms["telefonisletim"].Trim();
            model11.telefon_cozunurluk = forms["telefoncozunurluk"].Trim();
           
            model11.telefon_cozunurluk = forms["telefoncozunurluk"].Trim();
            model11.telefon_boyut = forms["telefonboyut"].Trim();
            model11.telefon_arka_kamera = forms["telefonarkakamera"].Trim();
            model11.telefon_on_kamera= forms["telefononkamera"].Trim();
            model11.telefon_ram = forms["telefonram"].Trim();
            model11.telefon_hafiza = forms["telefonhafiza"].Trim();
            model11.telefon_garanti = forms["telefongaranti"].Trim();



            Telefon dersCheck = db.Telefons.Where(w => w.telefon_id == model11.telefon_id).FirstOrDefault();
            if (dersCheck != null)
            {
                db.Telefons.Remove(dersCheck);
                db.SaveChanges();
                db.Telefons.Add(model11);
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View("/Views/Home/admintelefonekle.cshtml");
            }
            ViewBag.Mesaj = "ekleme başarısız";
            return View("/Views/Home/admintelefonekle.cshtml");

        }



        [HttpPost]
        public ActionResult admintelefonekle(FormCollection forms, string silme,string duzenle)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Telefon model1 = new Telefon();
            if (silme != null)
            {
                int num = Int32.Parse(silme);
                var sil = (from q in db.Telefons where q.telefon_id == num select q).FirstOrDefault();
                db.Telefons.Remove(sil);
                db.SaveChanges();
                ViewBag.Mesaj = "silme başarılı";
                return View();
            }


            model1.telefon_marka = forms["telefonmarka"].Trim();
            model1.telefon_model = forms["telefonmodel"].Trim();
            model1.telefon_isletim_sistemi = forms["telefonisletimsistemi"].Trim();
            model1.telefon_cozunurluk = forms["telefoncozunurluk"].Trim();
            model1.telefon_boyut = forms["telefonboyut"].Trim();
            model1.telefon_arka_kamera = forms["telefonarkakamera"].Trim();
            model1.telefon_on_kamera = forms["telefononkamera"].Trim();
            model1.telefon_ram = forms["telefonram"].Trim();
            model1.telefon_hafiza = forms["telefonhafiza"].Trim();
            model1.telefon_garanti = forms["telefongaranti"].Trim();



            var dersCheck = (from q in db.Telefons where q.telefon_id == model1.telefon_id select new { q.telefon_id }).FirstOrDefault();
            if (dersCheck == null)
            {
                db.Telefons.Add(model1);
                db.SaveChanges();
                ViewBag.Mesaj = "telefon ekleme başarılı";
                return View("/Views/Home/admintelefonekle.cshtml");

            }
            ViewBag.Mesaj = "telefon ekleme başarısız";
            return View("/Views/Home/admintelefonekle.cshtml");
        }



        [HttpGet]
        public ActionResult admintabletekle()
        {
            return View();
        }

        [HttpGet]
        public ActionResult admintabletduzenle(string duzenle)
        {
            try
            {
                Db_incelemeEntities db = new Db_incelemeEntities();
                if (duzenle != null)
                {
                    int num = Int32.Parse(duzenle);
                    var duzen = (from q in db.Tablets where q.tablet_id == num select q).FirstOrDefault();

                    return View("admintabletduzenle", duzen);

                }
                return View();

            }
            catch (Exception ex)
            {

                return View();
            }


        }
        [HttpPost]
        public ActionResult admintabletduzenle(FormCollection forms)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Tablet model11 = new Tablet();

            model11.tablet_id = Int32.Parse(forms["tabletid"].Trim());
            model11.tablet_marka = forms["tabletmarka"].Trim();            
            model11.tablet_model = forms["tabletmodel"].Trim();
            model11.tablet_isletim_sistemi = forms["tabletisletim"].Trim();       
            model11.tablet_hafiza = forms["tablethafiza"].Trim();
            model11.tablet_ekran_cozunurluk = forms["tabletcozunurluk"].Trim();
            model11.tablet_kamera = forms["tabletkamera"].Trim();
            model11.tablet_bluetooth = forms["tabletbluetooth"].Trim();            
            model11.tablet_ram = forms["tabletram"].Trim();
            


           Tablet dersCheck = db.Tablets.Where(w => w.tablet_id == model11.tablet_id).FirstOrDefault();
            if (dersCheck != null)
            {
                db.Tablets.Remove(dersCheck);
                db.SaveChanges();
                db.Tablets.Add(model11);
                db.SaveChanges();
                ViewBag.Mesaj = "ekleme başarılı";
                return View("/Views/Home/admintabletekle.cshtml");
            }
            ViewBag.Mesaj = "ekleme başarısız";
            return View("/Views/Home/admintabletekle.cshtml");

        }






        [HttpPost]
        public ActionResult admintabletekle(FormCollection forms, string silme,string duzenle)
        {
            Db_incelemeEntities db = new Db_incelemeEntities();
            Tablet model1 = new Tablet();
            if (silme != null)
            {
                int num = Int32.Parse(silme);
                var sil = (from q in db.Tablets where q.tablet_id == num select q).FirstOrDefault();
                db.Tablets.Remove(sil);
                db.SaveChanges();
                ViewBag.Mesaj = "silme başarılı";
                return View();
            }


            model1.tablet_marka = forms["tabletmarka"].Trim();
            model1.tablet_model = forms["tabletmodel"].Trim();
            model1.tablet_isletim_sistemi = forms["tabletisletimsistemi"].Trim();
            model1.tablet_hafiza = forms["tablethafiza"].Trim();
            model1.tablet_ekran_cozunurluk = forms["tabletcozunurluk"].Trim();
            model1.tablet_kamera = forms["tabletkamera"].Trim();
            model1.tablet_bluetooth = forms["tabletbluetooth"].Trim();
            model1.tablet_ram = forms["tabletram"].Trim();





            var dersCheck = (from q in db.Tablets where q.tablet_id == model1.tablet_id select new { q.tablet_id }).FirstOrDefault();
            if (dersCheck == null)
            {
                db.Tablets.Add(model1);
                db.SaveChanges();
                ViewBag.Mesaj = "telefon ekleme başarılı";
                return View("/Views/Home/admintabletekle.cshtml");

            }
            ViewBag.Mesaj = "telefon ekleme başarısız";
            return View("/Views/Home/admintabletekle.cshtml");
        }

    }

}





