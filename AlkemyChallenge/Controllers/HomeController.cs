using AlkemyChallenge.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace AlkemyChallenge.Controllers
{
    public class HomeController : Controller
    {
        AlkemyChallengeEntities _db = new AlkemyChallengeEntities();
        public ActionResult Index()
        {
            if (Session["Id_Admin"] != null || Session["Id_Student"] != null) //si idadmin o idalumno != null
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, string dni, string docket, string type)
        {
            if (type == "a")
            {
                if (ModelState.IsValid)
                {
                    var f_password = GetMD5(password);
                    var data = _db.Admins.Where(x => x.Username.Equals(username) && x.Password.Equals(f_password)).ToList();
                    if (data.Count > 0)
                    {
                        Session["Id_Admin"] = data.FirstOrDefault().Id_Admin;
                        Session["Username"] = data.FirstOrDefault().Username;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
            }
            else if (type == "s")
            {
                if (ModelState.IsValid)
                {
                    var data = _db.Students.Where(x => x.Dni.Equals(dni) && x.Docket.Equals(docket)).ToList();
                    if (data.Count > 0)
                    {
                        Session["Id_Student"] = data.FirstOrDefault().Id_Student;
                        Session["Name"] = data.FirstOrDefault().Name;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }                 
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        private static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}