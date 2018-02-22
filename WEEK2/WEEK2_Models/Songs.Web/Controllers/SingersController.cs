using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Songs.Models;
using Songs.Web.ViewModels.Singers;

namespace Songs.Web.Controllers
{
    public class SingersController : Controller
    {
        List<Person> singers = new List<Person>();

        public SingersController()
        {
            singers.Add(new Person()
            {
                ID = 1,
                Firstname = "Dan",
                Name = "Auerbach",
                Email = "dan@auerbach.com"
            });

            singers.Add(new Person()
            {
                ID = 2,
                Firstname = "Karen",
                Name = "Daemen",
                Email = "karen@k3.be"
            });
        }

        public IActionResult Index()
        {

            IndexViewModel vm = new IndexViewModel();
            vm.Singers = singers;
          
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            // persoon ophalen
            var query = from p in singers
                        where p.ID == id
                        select p;

            Person singer = query.Single();
            // persoon meegeven aan de view
            return View(singer);
        }

        [HttpPost]
        public IActionResult Edit(Person p)
        {
            if (ModelState.IsValid)
            {
                // opslaan
                return RedirectToAction("Index");
            }

            // niet valid
            return View(p);
        }
    }
}