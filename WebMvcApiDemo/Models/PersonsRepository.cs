using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class PersonsRepository
    {
        private List<Person> mPersons = new List<Person>();
        private static PersonsRepository mRepository = new PersonsRepository();
        private readonly Person[] Persons = {
            new Person{ ID=1, Name="Person1", Age=20 },
            new Person{ ID=2, Name="Person2", Age=20 },
            new Person{ ID=3, Name="Person3", Age=20 },
            new Person{ ID=4, Name="Person4", Age=20 },
            new Person{ ID=5, Name="Person5", Age=20 },
            new Person{ ID=6, Name="Person6", Age=20 }

        };

        private PersonsRepository() {
            if (mPersons.Count == 0)
            {
                mPersons.AddRange(Persons);
            }
        }

        public int Count
        {
            get { return mPersons.Count; }
        }

        public void AddRange(IEnumerable<Person> persons)
        {
            mPersons.AddRange(persons);
        }

        public IEnumerable<Person> GetPersons()
        {
            return mPersons.ToArray();
        }

        public static PersonsRepository Repository
        {
            get { return mRepository; }
        }
    }
}