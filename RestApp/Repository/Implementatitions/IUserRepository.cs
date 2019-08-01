using RestApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Repository.Implementatitions
{

    public interface IUserRepository
    {
        
            User FindByLogin(string login);
        
    }
}
