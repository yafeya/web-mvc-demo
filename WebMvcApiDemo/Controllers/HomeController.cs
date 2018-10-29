using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = new HomeViewModel { Persons = PersonsRepository.Repository.GetPersons() };
            return View(data);
        }

        public ActionResult SelectPerson(Person person)
        {
            if (person != null && person.ID != 0)
            {
                return PartialView("PersonDetail", person);
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            var existed = PersonsRepository.Repository.GetPersons().Where(x => x.ID == person.ID).FirstOrDefault();
            existed.Name = person.Name;
            existed.Age = person.Age;
            return RedirectToAction("Index", PersonsRepository.Repository.GetPersons());
        }
    }

    public class HomeViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
        public Person Selected { get; set; } = null;
    }
}
