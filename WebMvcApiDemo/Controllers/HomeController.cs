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
        private IPersonRepository mRepository;

        public HomeController(IPersonRepository repository)
        {
            mRepository = repository;
        }

        public ActionResult Index()
        {
            var persons = mRepository.GetPersons();
            var data = new HomeViewModel { Persons = persons };
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
            mRepository.Update(person);
            var persons = mRepository.GetPersons();
            return RedirectToAction("Index", persons);
        }
    }

    public class HomeViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
        public Person Selected { get; set; } = null;
    }
}
