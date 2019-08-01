using RestApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Repository.Generic
{
    public interface IRepository<T> where T :BaseEntity 
    {

        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        int GetCount(string query);
        bool Exists(long? id);
        List<T> FindWithPagedSearch(string g);
    }
}
