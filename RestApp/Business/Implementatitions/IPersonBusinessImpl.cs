﻿using RestApp.Data.Converters;
using RestApp.Data.VO;
using RestApp.Model;
using RestApp.Model.Context;
using RestApp.Repository.Generic;
using RestApp.Repository.Implementatitions;
using RestApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapioca.HATEOAS.Utils;

namespace RestApp.Business.Implementatitions
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page + 1,
                List = _converter.ParseList(persons),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }

}

