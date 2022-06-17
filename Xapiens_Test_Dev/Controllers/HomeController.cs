using System.Web.Mvc;
using System.Web.Security;
using MVC5RealWorld.Models.ViewModel;
using Newtonsoft.Json;

namespace MVC5RealWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {

            if (Session["token"] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }

        public JsonResult GetData()
        {
            object o = new { stat = "error",data=string.Empty};
            var token_ = Session["token"].ToString();
           if (string.IsNullOrEmpty(token_)) return Json(o, JsonRequestBehavior.AllowGet);
            MVC5RealWorld.Models.User.ListUsers listUsers = MVC5RealWorld.Models.User.ListUsers.GetList_User(token_);
            if(listUsers==null) return Json(o, JsonRequestBehavior.AllowGet);

            int totalPage = (int)listUsers.total_pages;

            // if (totalPage == null ) return Json(o, JsonRequestBehavior.AllowGet);
            if (totalPage <= 0)
            {
                return Json(o, JsonRequestBehavior.AllowGet);
            }


            string numberpage = new MVC5RealWorld.Models.User.Uri_().url_Pages;
            System.Collections.Generic.List<Xapiens.Datum> datum = new System.Collections.Generic.List<Xapiens.Datum>();

            for (int i = 1; i <= totalPage; i++)
            {
                string r_page = numberpage.Replace("<index>", "" + i);
                Xapiens.Ls lds =Xapiens.Ls.GetList_Data(token_,r_page);
                foreach (var x in lds.data)
                {
                    datum.Add(x);
                }
            }

            if (datum.Count>0)
            {
                o = new { stat = "success", data = datum };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Signout()
        {
            Session["email"] = null;
            Session["pass"] = null;
            Session["token"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}