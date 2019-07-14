using FinPe.Model;

namespace FinPe.Business
{
    public interface ILoginBusiness
    {
        object BuscarPorLogin(Login usuarioLogin);
    }
}