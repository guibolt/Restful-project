using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using RestApp.Model;
using RestApp.Model.Context;
using RestApp.Repository.Implementatitions;

namespace RestApp.Services.Implementatitions.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySQLContext Context;
        public PersonRepository(MySQLContext context)
        {
            Context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                Context.Add(person);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }
        public void Delete(long id)
        {

            var result = Context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null) Context.Persons.Remove(result);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            return Context.Persons.ToList();

        }

        public Person FindById(long id)
        {
            return Context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = Context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                Context.Entry(result).CurrentValues.SetValues(person);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

    }



}
