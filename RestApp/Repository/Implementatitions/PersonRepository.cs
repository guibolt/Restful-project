using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using RestApp.Model;
using RestApp.Model.Context;
using RestApp.Repository.Generic;
using RestApp.Repository.Implementatitions;

namespace RestApp.Services.Implementatitions.Repository
{

    public class PersonRepository : GenericRepository<Person> ,IPersonRepository
    {

        public PersonRepository(MySQLContext context):base(context)
        {
          
        }
        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            return _context.Persons.ToList();
        }
    }





}
