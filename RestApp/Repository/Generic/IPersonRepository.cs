using RestApp.Model;
using RestApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Repository.Generic
{
    public interface IPersonRepository: IRepository<Person>
    {

        List<Person> FindByName(string firstName, string lastName);
   
    }
}
