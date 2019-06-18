using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZinciriKirma.Model;

namespace ZinciriKirma.Controllers
{
    public class UserController : Controller
    {
        ZinciriKirmaEntities db = new ZinciriKirmaEntities();

        // GET: User
        public ActionResult Index()
        {
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            List<Chain> chainList = db.Chains.Where(x => x.UserId == userId).ToList();
            return View(chainList);

        }




        public ActionResult AddChain()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddChain(/*string ChainName, DateTime StartingDate, string Frequency, DateTime EndDate*/Chain ch)
        {
        

            Chain chain = new Chain();
            chain.ChainName = ch.ChainName;
            chain.StartingDate = ch.StartingDate;
            chain.Frequency = ch.Frequency;
            chain.EndDate = ch.EndDate;

            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            chain.UserId = userId;

            db.Chains.Add(chain);

            db.SaveChanges();

         
            return RedirectToAction("Index", "User");

        }


        public ActionResult MemberLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public string RemoveChain(int id)
        //{

        //    //Sepet varsa,gelen ürünün varolan sepete ekle,sepet yoksa önce aktif session için(oturum) için sepet oluştur ve sepete gelen ürünü ekle

        //    string cartMessage = "";

            
        //    Chain chn = db.Chains.FirstOrDefault(x => x.ChainID == id); //Producttan o id'li ürünü bul
        //    //crt.PrdList.Remove(prd);

        //    db.Chains.Remove(chn);

        //    //crt.PrdList.RemoveAll(x => x.ProductID == id);

        //    //Session["CurrentCart"] = crt;

        //    cartMessage = "Ürün sepetten çıkarılmıştır. ";

        //    return cartMessage;


        //}


       //public ActionResult deleteChain()
       // {
       //     return View();
       // }


        [HttpPost]
        public ActionResult deleteChain(int id)
        {

            Chain chain = db.Chains.Where(x => x.ChainID == id).FirstOrDefault();
            List<ChainDetail> chainDetail = db.ChainDetails.Where(x => x.ChainID == id).ToList();
            db.Chains.Remove(chain);

            foreach (var item in chainDetail)
            {
                db.ChainDetails.Remove(item);
            }
           
            db.SaveChanges();

            
            return RedirectToAction("Index","User");
         
        }



        //public ActionResult ChainListPartialView()
        //{
        //    Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
        //    List<Chain> chainList = db.Chains.Where(x => x.UserId == userId).ToList();


        //    return PartialView(chainList);

        //}


        [HttpGet]
        public ActionResult ChainDetail(int? id)
        {
            // gelen id yi Veritabanımızda kontrol ediyoruz ve gelen employee partialviewimize gönderiyoruz
            var model = db.Chains.FirstOrDefault(x => x.ChainID == id);
            //return PartialView("_AddRecord", model);
            return PartialView("ChainDetail", model);

            //return PartialView(db.Chains.FirstOrDefault(x => x.ChainID == id));
        }

        [HttpPost]
        public ActionResult ChainDetail(Chain ch)
        {
            var findChain = db.Chains.Where(x => x.ChainID == ch.ChainID).FirstOrDefault();
            findChain.ChainName = ch.ChainName;
            findChain.StartingDate = ch.StartingDate;
            findChain.EndDate = ch.EndDate;
            findChain.Frequency = ch.Frequency;
            db.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        //[HttpPost]
        //public ActionResult ChainDetail(int? id)
        //{
        //    // gelen id yi Veritabanımızda kontrol ediyoruz ve gelen employee partialviewimize gönderiyoruz
          

        //    //return PartialView(db.Chains.FirstOrDefault(x => x.ChainID == id));
        //}

        public ActionResult CalenderView(int? id)
        {
            return View(db.Chains.FirstOrDefault(x=> x.ChainID==id));
        }

        public JsonResult GetCalendarEvents(int ChainID)
        {
            List<CalendarEvent> eventItems = new List<CalendarEvent>();
            List<ChainDetail> chainDetails = db.ChainDetails.Where(x=> x.ChainID==ChainID).ToList();

            int i = 0, n = chainDetails.Count();

            for (i = 0; i < n; i++)
            {
                CalendarEvent item = new CalendarEvent();
                item.id = chainDetails[i].ChainDetailID;
                item.title = chainDetails[i].ChainRingArchived ? "Yapıldı" : "Yapılmadı";
                item.start = chainDetails[i].ChainRingDate.ToString("s");
                item.end = item.start;
                item.color = chainDetails[i].ChainRingArchived ? "green" : "red";
                item.allday = true;
                eventItems.Add(item);

                //db.CalendarEvents.Add(item);
                //db.SaveChanges();

            }

        

            return Json(eventItems, JsonRequestBehavior.AllowGet);

        
        }

        /// <summary>
        /// Veritabanına Ekleme yapar veya varolan kayıtta güncelleme yapar
        /// </summary>
        /// <param name="item">İşlem yapılması istenen event nesnesi</param>
        /// <returns></returns>
    
        public JsonResult AddOrEditItem(ChainDetail item)
        {
           
                
                ChainDetail chain = new ChainDetail();
            //chain.ChainRingArchieved = item.ChainRingArchieved;
            
                chain.ChainRingArchived = item.ChainRingArchived;
                chain.ChainRingDate = item.ChainRingDate;
                chain.ChainID = item.ChainID;
             
                db.ChainDetails.Add(chain);
                db.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
           


        }

        //chaindetail durumunu yapıldı, yapılmadı olarak güncelliyoruz
        public JsonResult UpdateChainRingArchieved(int ChainDetailID)
        {
            ChainDetail chainDetail = db.ChainDetails.Where(x => x.ChainDetailID == ChainDetailID).FirstOrDefault();
            chainDetail.ChainRingArchived = !chainDetail.ChainRingArchived;
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}