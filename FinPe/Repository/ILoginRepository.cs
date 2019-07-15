using FinPe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Repository
{
    public interface ILoginRepository
    {
        Usuario BuscarPorLogin(string login);
        void InserirLogDeAcesso(LogUsuario logUsuario);
    }
}
