using SPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using SPS.Datafile;
using SPS.Models;
using System.Diagnostics;
using KPS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace KPS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        private readonly Data_Base obj;
        public HomeController(Data_Base obj)
        {
            this.obj = obj;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Admin_Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Admin_Login(Admin d)
        {
            var s = obj.Admins.Where(a => a.Email.ToLower() == d.Email.ToLower()).FirstOrDefault();
            if (s == null)
            {
                TempData["InvalidEmail"] = "Email not match";
            }
            else
            {
                if (s.Email.ToLower() == d.Email.ToLower() && s.Password == d.Password)
                {
                    List<Claim> c = new List<Claim>();
                    c.Add(new Claim(ClaimTypes.Email, s.Email));
                    c.Add(new Claim(ClaimTypes.NameIdentifier, s.Email));
                    ClaimsIdentity i = new ClaimsIdentity(c, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal p = new ClaimsPrincipal(i);

                    HttpContext.SignInAsync(p);
                    HttpContext.Session.SetString("k", s.Email);
                    return RedirectToAction("Stu_Table");
                }
                else
                {
                    TempData["Invalidpassword"] = "password is incorrect";
                }
            }
            return View();
        }

        public IActionResult Admin_Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Admin_Login");
        }

        //User_Id
        [AllowAnonymous]
        public async Task<IActionResult> User_Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> User_Login(Admin d)
        {
            var s = obj.User_Ids.Where(a => a.Email.ToLower() == d.Email.ToLower()).FirstOrDefault();
            if (s == null)
            {
                TempData["InvalidEmail"] = "Email not match";
            }
            else
            {
                if (s.Email.ToLower() == d.Email.ToLower() && s.Password == d.Password)
                {
                    List<Claim> c = new List<Claim>();
                    c.Add(new Claim(ClaimTypes.Email, s.Email));
                    c.Add(new Claim(ClaimTypes.NameIdentifier, s.Email));
                    ClaimsIdentity i = new ClaimsIdentity(c, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal p = new ClaimsPrincipal(i);

                    HttpContext.SignInAsync(p);
                    HttpContext.Session.SetString("k", s.Email);
                    return RedirectToAction("Stu_Table");
                }
                else
                {
                    TempData["Invalidpassword"] = "password is incorrect";
                }
            }
            return View();
        }

        public IActionResult User_Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("User_Login");
        }

        public async Task<IActionResult> user_Table()
        {
            var a = obj.Students.ToList();
            return View(a);
        }

        [AllowAnonymous]
        public async Task<IActionResult> User_Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> User_Register(User_Id c)
        {
            try
            {
                obj.User_Ids.Add(c);
                obj.SaveChanges();
                TempData["Register"] = "Registration has been successfull";
                return RedirectToAction("User_Login");
            }
            catch
            {
                TempData["Email"] = "This Email is already exits";
                return View();
            }
        }
        [AllowAnonymous]
        public IActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Forget(User_Id s)
        {

            var res = obj.User_Ids.Where(a => a.Email.ToLower() == s.Email.ToLower()).FirstOrDefault();
            if (res == null)
            {
                return View();
            }
            else
            {
                if (s.Password != s.C_Password)
                {
                    //TempData["PASS"] = "C_Password is not matched";
                    return View();
                }
                else
                {
                    res.Password = s.Password;
                    obj.Update(res);
                    obj.SaveChanges();
                    // TempData["forget"] = "Password is successfully  Changed";
                    return RedirectToAction("Login");
                }
            }
            // return View();
        }

        public async Task<IActionResult> user_Delete(int Id)
        {
            var ab = await obj.User_Ids.FindAsync(Id);
            obj.User_Ids.Remove(ab);
            await obj.SaveChangesAsync();
            return RedirectToAction("user_Table");
        }

        //STUDENT
        public async Task<IActionResult> Stu_Table()
        {
            var a=obj.Students.ToList();
            return View(a);
        }

        public async Task<IActionResult> Stu_Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Stu_Create(Student ab)
        {
            if(ab == null)
            {
                obj.Students.Add(ab);
                obj.SaveChanges();
            }
            else
            {
                obj.Update(ab);
                obj.SaveChanges();
              
            }
            return RedirectToAction("Stu_Table");
        }

        public async Task<IActionResult> Stu_Details(int Id)
        {
            var a=obj.Students.Where(s=>s.Id == Id).First();
            return View(a);
        }

        public async Task<IActionResult> Stu_Edit(int Id) 
        { 
            var a= obj.Students.Where(o=>o.Id == Id).First();
            Student ss=new Student();
            ss.Id = a.Id;
            ss.Name = a.Name;
            ss.Father_Name = a.Father_Name;
            ss.Mother_Name = a.Mother_Name;
            ss.Address = a.Address;
            ss.DOB = a.DOB;
            ss.Gender = a.Gender;
            ss.Contect = a.Contect;
            ss.Alter_Contect = a.Alter_Contect;
            ss.Addmission_Date = a.Addmission_Date;
            ss.Class = a.Class;
            ss.Image = a.Image;
            ss.January = a.January;
            ss.February = a.February;
            ss.March = a.March;
            ss.April = a.April;
            ss.May = a.May;
            ss.June = a.June;
            ss.July = a.July;
            ss.August = a.August;
            ss.September = a.September;
            ss.October = a.October;
            ss.November = a.November;
            ss.December = a.December;
            return View("Stu_Create", ss);
        }

        public async Task<IActionResult> Stu_Delete(int Id)
        {
            var a = obj.Students.Where(a => a.Id == Id).FirstOrDefault();
            obj.Students.Remove(a);
            obj.SaveChanges();
            return RedirectToAction("Stu_Table");
        }




        //Teachers Details


        public async Task<IActionResult> Teac_Table()
        {
            var a = obj.Teachers.ToList();
            return View(a);
        }

        public async Task<IActionResult> Teac_Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Teac_Create(Teacher ab)
        {
            if (ab == null)
            {
                obj.Teachers.Add(ab);
                obj.SaveChanges();
            }
            else
            {
                obj.Update(ab);
                obj.SaveChanges();
              
            }
            return RedirectToAction("Teac_Table");
        }

        public async Task<IActionResult> Teac_Details(int Id)
        {
            var a = obj.Teachers.Where(s => s.Id == Id).First();
            return View(a);
        }

        public async Task<IActionResult> Teac_Edit(int Id)
        {
            var a = obj.Teachers.Where(o => o.Id == Id).First();
            Teacher ss = new Teacher();
            ss.Id = a.Id;
            ss.Name = a.Name;
            ss.Address = a.Address;
            ss.Gender = a.Gender;
            ss.Contect = a.Contect;
            ss.Alter_Contect = a.Alter_Contect;
            ss.Email = a.Email;
            ss.Education = a.Education;
            ss.Join_Date = a.Join_Date;
            ss.January = a.January;
            ss.February = a.February;
            ss.March = a.March;
            ss.April = a.April;
            ss.May = a.May;
            ss.June = a.June;
            ss.July = a.July;
            ss.August = a.August;
            ss.September = a.September;
            ss.October = a.October;
            ss.November = a.November;
            ss.December = a.December;
            return View("Teac_Create", ss);
        }

        public async Task<IActionResult> Teac_Delete(int Id)
        {
            var ab = await obj.Teachers.FindAsync(Id);
            obj.Teachers.Remove(ab);
           await obj.SaveChangesAsync();
            return RedirectToAction("Teac_Table");
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}