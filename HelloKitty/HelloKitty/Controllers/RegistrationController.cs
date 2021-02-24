using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using HelloKitty.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloKitty.Controllers{
    public class RegistrationController : Controller{
        private static Dictionary<string,RegistrationViewModel> users = new Dictionary<string, RegistrationViewModel>();
        private static bool loggedIn;
        private static string currentUser;
        [HttpGet]
       
        public IActionResult Index(string email, string password, string name){

            var model = new RegistrationViewModel{
                Email = email,
                Password = password,
                Name = name
            };
            
           
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(RegistrationViewModel model){
            users.Add(model.Name,model);
            loggedIn = true;
            currentUser = model.Name;
            return RedirectToAction("UserPage","Registration");
        }

        [HttpGet]
        public IActionResult UserPage(){
            if (!loggedIn){
                return RedirectToAction("Index", "Registration");
            }
            return View(users[currentUser]);
        }

        [HttpPost]
        public IActionResult UserPage(bool leave){
            loggedIn = false;
            currentUser = "";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string name, string password){
            if (users.Count == 0) return RedirectToAction("Index", "Registration");
            var model = new RegistrationViewModel{
                Name = name,
                Password = password
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult LogIn(RegistrationViewModel model){
            if (users.ContainsKey(model.Name)){
                var user = users[model.Name];
                if (model.Password == user.Password){
                    loggedIn = true;
                    currentUser = model.Name;
                    return RedirectToAction("UserPage","Registration");
                }
            }
            return View();
        }
        
    }
}