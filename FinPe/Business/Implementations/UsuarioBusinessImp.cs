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
        private IRepository<LogUsuarioDeAtividade> _logUsuarioDeAtividaderepository;
        private readonly UsuarioConverter _usuarioConverter;
        private readonly LogUsuarioDeAtividadeConverter _logUsuarioDeAtividadeConverter;

        public UsuarioBusinessImp(IRepository<Usuario> repository, IRepository<LogUsuarioDeAtividade> logUsuarioDeAtividaderepository)
        {
            _repository = repository;
            _usuarioConverter = new UsuarioConverter();
            _logUsuarioDeAtividadeConverter = new LogUsuarioDeAtividadeConverter();
            _logUsuarioDeAtividaderepository = logUsuarioDeAtividaderepository;
        }

        public UsuarioVO CriarNovo(UsuarioVO usuarioVO)
        {
            var usuarioEntity = _usuarioConverter.Parce(usuarioVO);
            usuarioEntity = _repository.CriarNovo(usuarioEntity);

            LogUsuarioDeAtividadeVO logUsuarioDeAtividadeVO = new LogUsuarioDeAtividadeVO
            {
                codUsuario = usuarioEntity.codigo,
                dataAtividade = DateTime.Now,
                atividade = "Criação de novo usuário."
            };

            var logAtividadeEntity = _logUsuarioDeAtividadeConverter.Parce(logUsuarioDeAtividadeVO);
                
            logAtividadeEntity = _logUsuarioDeAtividaderepository.CriarNovo(logAtividadeEntity);

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
