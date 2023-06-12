using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVCtest.Models;
using NuGet.Protocol.Plugins;
using RestSharp;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace MVCtest.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly SignInManager<IdentityUser> signInManager;
        //public EmployeeController(SignInManager<IdentityUser> signInManager)
        //{
        //    this.signInManager = signInManager;
        //}

        static List<Employee> Emp = new List<Employee>()
        {
            new Employee(){Id=1,Name="Vedika Dwivedi",Department="Product Developmenmt",Contact=9876426899,Email="VedikaDwivedi@gmail.com",HireDate=DateTime.Parse("06/03/2023 9:00 AM")},
            new Employee(){Id=2,Name="Tripti Tripathi",Department="Product Development",Contact=7484498396,Email="Triptitripathi@gmail.com",HireDate=DateTime.Parse("06/03/2023 9:00 AM")},
            //new Employee(){Id=3,Name="Rahul Singh",Department="Power BI",contact=7484498391,email="RahulSingh@gmail.com"},
            //new Employee(){Id=4,Name="Sakshi Gaur",Department="Product Development",contact=7486698396,email="SakshiGaur@yahoo.in"},
            //new Employee(){Id=5,Name="Akshay Sinha",Department="QA",contact=7486698396,email="AkshaySinha@yahoo.in"},
            //new Employee(){Id=6,Name="Himanshu Ranjan",Department="Product Development",contact=7486698396,email="himanshuRanjan@gmail.com"}
        };



        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult TestFunc(LoginCredentials login)
        {
            try
            {
                return View(Emp);
            }
            catch (Exception ex) 
            {
               
                throw ex;
            }
        }

        public IActionResult Logout(LoginCredentials login)
        {
            HttpContext.Response.Cookies.Delete("Email");
            HttpContext.Response.Cookies.Delete("password");
            return RedirectToAction("Login") ;
        }



        public IActionResult Login()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Email") && HttpContext.Request.Cookies.ContainsKey("password"))
            {
                return RedirectToAction("TestFunc",Emp);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginCredentials login)
        {
            var checkbox = login.RememberMe;
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    HttpContext.Response.Cookies.Append("Email", login.Email);
                    HttpContext.Response.Cookies.Append("password", login.Password);

                }
                return RedirectToAction("TestFunc", Emp);
            }
            return View(login);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Emp.Add(emp);
                return RedirectToAction("TestFunc");
            }
            return View();
        }

        public IActionResult EditEmployee(int Id)
        {
            Employee employee = GetEmployeeById(Id);
            return View(employee);
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee=Emp.Where(e=> e.Id == id).FirstOrDefault();
            return employee;
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee employee, int id)
        {
            Emp.Where(e => e.Id == id).FirstOrDefault().Name = employee.Name;
            Emp.Where(e => e.Id == id).FirstOrDefault().Department = employee.Department;
            Emp.Where(e => e.Id == id).FirstOrDefault().Contact = employee.Contact;
            Emp.Where(e => e.Id == id).FirstOrDefault().Email = employee.Email;

            return RedirectToAction("TestFunc");
        }

        public IActionResult DeleteById(int id)
        {
            var itemToRemove = Emp.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                Emp.Remove(itemToRemove);
                RedirectToAction("TestFunc");
            }
            return RedirectToAction("TestFunc");
        }

    }
}
