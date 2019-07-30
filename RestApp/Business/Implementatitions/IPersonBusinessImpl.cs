using RestApp.Model;
using RestApp.Model.Context;
using RestApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Business.Implementatitions
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private  IPersonRepository Reposiotory;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            Reposiotory = repository;
        }
        public Person Create(Person person)
        {

            return Reposiotory.Create(person);
        }
        public void Delete(long id)
        {

            Reposiotory.Delete(id);
        }

        public List<Person> FindAll()
        {
            return Reposiotory.FindAll();

        }

        public Person FindById(long id)
        {
            return Reposiotory.FindById(id);
        }

        public Person Update(Person person)
        {

            return Reposiotory.Update(person);
        }

        public bool Exists(long id)
        {
            return Reposiotory.Exists(id);
        }
       
    }
}
