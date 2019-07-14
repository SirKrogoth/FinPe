using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Data.Converters;
using FinPe.Data.VO;
using FinPe.Model;
using FinPe.Repository;

namespace FinPe.Business.Implementations
{
    public class UsuarioBusinessImp : IUsuarioBusiness
    {
        private IRepository<Usuario> _repository;
        private readonly UsuarioConverter _usuarioConverter;

        public UsuarioBusinessImp(IRepository<Usuario> repository)
        {
            _repository = repository;
            _usuarioConverter = new UsuarioConverter();
        }

        public UsuarioVO CriarNovo(UsuarioVO usuarioVO)
        {
            var usuarioEntity = _usuarioConverter.Parce(usuarioVO);
            usuarioEntity = _repository.CriarNovo(usuarioEntity);

            return _usuarioConverter.Parce(usuarioEntity);
        }

        public UsuarioVO AtualizarUsuario(UsuarioVO usuarioVO)
        {
            throw new NotImplementedException();
        }

        public UsuarioVO BuscarPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }

        public void DeletarUsuario(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioVO> BuscarTodosUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
