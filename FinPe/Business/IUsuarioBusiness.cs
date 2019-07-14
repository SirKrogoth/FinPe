using FinPe.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Business
{
    public interface IUsuarioBusiness
    {
        UsuarioVO CriarNovo(UsuarioVO usuarioVO);
        UsuarioVO BuscarPorCodigo(int codigo);
        List<UsuarioVO> BuscarTodosUsuarios();
        UsuarioVO AtualizarUsuario(UsuarioVO usuarioVO);
        void DeletarUsuario(int codigo);
    }
}
