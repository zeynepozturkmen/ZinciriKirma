using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZinciriKirma.App_Classes;

namespace ZinciriKirma.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Index(User uc)
        {

            MembershipCreateStatus status;
            var user = Membership.CreateUser(uc.UserName, uc.Password, uc.Email, null, null, true, out status);

            string createmessage = "";

            switch (status)
            {
                case MembershipCreateStatus.Success: //basarılı   
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    createmessage = "Gerçersiz kullanıcı adı.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    createmessage = "Gerçersiz şifre adı.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    createmessage = "Gerçersiz email";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    createmessage = "Kullanılmıs kullanıcı adı.";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    createmessage = "Kullanılmış email adresi";
                    break;
                case MembershipCreateStatus.UserRejected:
                    createmessage = "Kullanıcı engellendi";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    createmessage = "Geçersiz kullanıcı anahtarı";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    createmessage = "Tekrarlanmış kullanıcı anahtarı";
                    break;
                case MembershipCreateStatus.ProviderError:
                    createmessage = "Sağlayıcı hatası.";
                    break;
                default:
                    break;
            }

            ViewBag.createMessage = createmessage;

            if (createmessage == "")
            {
                ViewBag.Message = "Kullanıcı kaydedildi.";
                //return View(); //hata yoksa kullanıcı giriş sayfasına gelicek.
                return View();
            }
            else
            {
                return View();
                //eger hata varsa oldugu sayfada kalsın
            }

        }

        public ActionResult Profile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Profile(User uc, string RememberMe)
        {
            string username = Membership.GetUserNameByEmail(uc.Email);
            uc.UserName = username;

            bool validationResult = Membership.ValidateUser(uc.UserName, uc.Password);


            if (validationResult == true)
            {
                //Girilen kullanıcı ve şifre bilgileri doğru ise, kullanıcının web sitemize giriş yapabilmesi gerekir.
                //Bunun için öncelikle web.config dosyasında authorization ayarlarının yapılması gerekir.
                //Ayarlar yapıldıktan sonra FormsAuthentication.RedirectFromLoginPage() metodu çağrılacak.
                /* <authentication mode="Forms" (roleManger'ın altına ekliyoruz.>

                 <forms    defaultUrl="/Home/Index" loginUrl="/Member/MemberLogin" timeout="30" slidingExpiration="true">
                 </forms>
                </authentication>
                */

                if (RememberMe == "on")
                {
                    FormsAuthentication.RedirectFromLoginPage(uc.UserName, true);
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(uc.UserName, false);
                }

                return RedirectToAction("Index", "User");

            }
            else
            {
                ViewBag.Message = "Kullanıcı adı ya da parola hatalı.";
                return RedirectToAction("Index", "Home");
            }


        }



    }
}