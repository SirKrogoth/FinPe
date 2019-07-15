using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Model;
using FinPe.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace FinPe.Repository.Implementations
{
    public class LoginRepositoryImp : ILoginRepository
    {
        private MysqlContext _context;
        private DbSet<LogUsuario> dataset;

        public LoginRepositoryImp(MysqlContext context)
        {
            _context = context;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuario.SingleOrDefault(u => u.login.Equals(login));
        }

        public void InserirLogDeAcesso(LogUsuario logUsuario)
        {
            try
            {
                dataset.Add(logUsuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }
    }
}