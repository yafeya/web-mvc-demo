using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public interface IPersonRepository
    {
        int Count { get; }
        IEnumerable<Person> GetPersons();
        void Update(Person person);
    }

    public class PersonsRepository: IPersonRepository
    {
        private List<Person> mPersons = new List<Person>();
        private readonly Person[] Persons = {
            new Person{ ID=1, Name="Person1", Age=20 },
            new Person{ ID=2, Name="Person2", Age=20 },
            new Person{ ID=3, Name="Person3", Age=20 },
            new Person{ ID=4, Name="Person4", Age=20 },
            new Person{ ID=5, Name="Person5", Age=20 },
            new Person{ ID=6, Name="Person6", Age=20 }

        };

        public PersonsRepository()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (mPersons.Count == 0)
            {
                mPersons.AddRange(Persons);
            }
        }

        public int Count
        {
            get { return mPersons.Count; }
        }
        
        public IEnumerable<Person> GetPersons()
        {
            return mPersons.ToArray();
        }

        public void Update(Person person)
        {
            var existed = mPersons.Where(x => x.ID == person.ID).FirstOrDefault();
            if (existed != null)
            {
                existed.Name = person.Name;
                existed.Age = person.Age;
            }
        }
    }
}