using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Model;
using FinPe.Model.Context;

namespace FinPe.Repository.Implementations
{
    public class LoginRepositoryImp : ILoginRepository
    {
        private MysqlContext _context;

        public LoginRepositoryImp(MysqlContext context)
        {
            _context = context;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuario.SingleOrDefault(u => u.login.Equals(login));
        }
    }
}
