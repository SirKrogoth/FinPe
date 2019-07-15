using FinPe.Data.VO;
using FinPe.Model;

namespace FinPe.Business
{
    public interface ILoginBusiness
    {
        object BuscarPorLogin(Login usuarioLogin);
        void InserirLogDeAcesso(LogUsuarioVO logUsuarioVO);
    }
}