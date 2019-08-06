using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestApp.Data.VO;
using RestApp.Model;
using RestApp.Model.Context;
using RestApp.Repository.Generic;
using RestApp.Repository.Implementatitions;
using Tapioca.HATEOAS.Utils;

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

        public PagedSearchDTO<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

            var persons = FindWithPagedSearch(query);

            int totalResults = GetCount(countQuery);

            return new PagedSearchDTO<Person>
            {
                CurrentPage = page + 1,
                List = persons,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
    }





}
