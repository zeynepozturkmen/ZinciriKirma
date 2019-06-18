using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZinciriKirma.Model;

namespace ZinciriKirma.Controllers {
    public class UserController : Controller {
        ZinciriKirmaEntities db = new ZinciriKirmaEntities();

        // GET: User
        public ActionResult Index() {
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            List<Chain> chainList = db.Chains.Where(x => x.UserId == userId).ToList();
            return View(chainList);
        }

        //[HttpPost]
        //public ActionResult Index()
        //{


        //}


        public ActionResult AddChain() {
            return View();
        }


        [HttpPost]
        public ActionResult AddChain(string ChainName, DateTime StartingDate, string Frequency, DateTime EndDate) {


            Chain chain = new Chain();
            chain.ChainName = ChainName;
            chain.StartingDate = StartingDate;
            chain.Frequency = Frequency;
            chain.EndDate = EndDate;

            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            chain.UserId = userId;

            db.Chains.Add(chain);

            db.SaveChanges();


            return RedirectToAction("Index", "User");

        }


        public ActionResult MemberLogout() {
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


        public ActionResult deleteChain() {
            return View();
        }


        [HttpPost]
        public ActionResult deleteChain(int id) {

            Chain chain = db.Chains.Where(x => x.ChainID == id).FirstOrDefault();
            db.Chains.Remove(chain);
            db.SaveChanges();

            return RedirectToAction("Index", "User");

        }



        //public ActionResult ChainListPartialView()
        //{
        //    Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
        //    List<Chain> chainList = db.Chains.Where(x => x.UserId == userId).ToList();


        //    return PartialView(chainList);

        //}

        [HttpPost]
        public ActionResult ChainDetail(int? id) {
            //gelen id yi Veritabanımızda kontrol ediyoruz ve gelen employee partialviewimize gönderiyoruz
            return PartialView(db.Chains.FirstOrDefault(x => x.ChainID == id));
        }

        // chain modelimizi dönüyoruz
        public ActionResult CalenderView(int? id) {
            return View(db.Chains.FirstOrDefault(x => x.ChainID == id));
        }

        //chaindetails verilerimizi takvime çekiyoruz
        public JsonResult GetCalendarEvents(int ChainID) {
            List<CalendarEvent> eventItems = new List<CalendarEvent>();

            List<ChainDetail> chainDetails = db.ChainDetails.Where(x => x.ChainID == ChainID).ToList();

            int i = 0, n = chainDetails.Count;
            for (i = 0; i < n; i++) {
                CalendarEvent item = new CalendarEvent();
                item.id = chainDetails[i].ChainDetailID;
                item.title = chainDetails[i].ChainRingArchieved ? "Yapıldı" : "Yapılmadı";
                item.start = chainDetails[i].ChainRingDate.ToString("s");
                item.end = item.start;
                item.color = chainDetails[i].ChainRingArchieved ? "green" : "red";
                item.allDay = true;
                eventItems.Add(item);
            }

            return Json(eventItems, JsonRequestBehavior.AllowGet);
        }

        //chaindetail durumunu yapıldı, yapılmadı olarak güncelliyoruz
        public JsonResult UpdateChainRingArchieved(int ChainDetailID) {
            ChainDetail chainDetail = db.ChainDetails.Where(x => x.ChainDetailID == ChainDetailID).FirstOrDefault();
            chainDetail.ChainRingArchieved = !chainDetail.ChainRingArchieved;
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //Random random = new Random();
        //public void AddItem(List<CalendarEvent> eventItems) {
        //    CalendarEvent item = new CalendarEvent();

        //    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, random.Next(1, 30));

        //    item.id = random.Next(1, 100);
        //    item.start = startDate.ToString("s");
        //    item.end = startDate.AddDays(random.Next(1, 5)).ToString("s");
        //    item.allDay = true;
        //    item.color = "blue";
        //    item.title = "Calendar Item " + item.id;
        //    eventItems.Add(item);

        //}


    }
}