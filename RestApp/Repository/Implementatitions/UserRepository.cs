using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using RestApp.Model;
using RestApp.Model.Context;
using RestApp.Repository.Implementatitions;

namespace RestApp.Services.Implementatitions.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }





}
