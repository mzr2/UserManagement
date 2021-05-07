using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModel;

namespace UserManagement.Repository.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get();
        Person Get(string NIK);
        Person Insert(Person person);
        Person Update(Person person);
        Person Delete(string NIK);
        IEnumerable<Person> GetByFirstName(string FirstName);

        IEnumerable<PersonVM> GetSalary();
        PersonVM GetSalary(string NIK);
    }
}
