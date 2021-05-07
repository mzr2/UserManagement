using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;
using UserManagement.ViewModel;

namespace UserManagement.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
        public PersonRepository(MyContext conn)
        {
            this.conn = conn;
        }
        public Person Delete(string NIK)
        {
            //throw new NotImplementedException();
            var delPerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(delPerson);
            var result = conn.SaveChanges();
            return delPerson;
        }

        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> persons = new List<Person>();
            persons = conn.Persons.ToList();
            return persons;
        }

        public Person Get(string NIK)
        {
            var persons = conn.Persons.Find(NIK);
            return persons;
        }

        public Person Insert(Person person)
        {
            conn.Persons.Add(person);  //menyimpan ke db
            var result = conn.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            //Person persons = new Person();
            //persons = conn.Persons.Find(person.NIK);
            //conn.Persons.Update(person);
            //var result = conn.SaveChanges();
            conn.Entry(person).State = EntityState.Modified;
            var result = conn.SaveChanges();
            return person;
        }

        public IEnumerable<Person> GetByFirstName(string FirstName)
        {
            var persons = conn.Persons.Where(c => c.FirstName == FirstName);
            return persons;
        }

        public IEnumerable<PersonVM> GetSalary()
        {
            IEnumerable<Person> persons = conn.Persons.ToList();
            List<PersonVM> personsVM = new List<PersonVM>();
            foreach (var item in persons)
            {
                PersonVM personList = new PersonVM();
                personList.NIK = item.NIK;
                personList.FirstName = item.FirstName;
                personList.Salary = item.Salary;
                personsVM.Add(personList);
            }
            return personsVM;
        }

        public PersonVM GetSalary(string NIK)
        {
            var persons = conn.Persons.Find(NIK);
            PersonVM person = new PersonVM();
            person.NIK = persons.NIK;
            person.FirstName = persons.FirstName;
            person.Salary = persons.Salary;
            return person;
        }
    }
}
