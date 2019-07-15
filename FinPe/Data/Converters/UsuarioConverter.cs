using FinPe.Data.Converter;
using FinPe.Data.VO;
using FinPe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Data.Converters
{
    public class UsuarioConverter : IParce<UsuarioVO, Usuario>, IParce<Usuario, UsuarioVO
        >
    {
        public Usuario Parce(UsuarioVO origem)
        {
            if (origem == null) return new Usuario();

            return new Usuario
            {
                codigo = Convert.ToInt32(origem.codigo),
                nome = origem.nome,
                sobreNome = origem.sobreNome,
                email = origem.email,
                login = origem.login,
                senha = origem.senha,
                telefone = origem.telefone,
                dataCadastro = origem.dataCadastro                
            };
        }

        public UsuarioVO Parce(Usuario origem)
        {
            if (origem == null) return new UsuarioVO();

            return new UsuarioVO
            {
                codigo = Convert.ToInt32(origem.codigo),
                nome = origem.nome,
                sobreNome = origem.sobreNome,
                email = origem.email,
                login = origem.login,
                senha = origem.senha,
                telefone = origem.telefone,
                dataCadastro = origem.dataCadastro
            };
        }

        public List<Usuario> ParceList(List<UsuarioVO> origem)
        {
            if (origem == null) return new List<Usuario>();

            return origem.Select(item => Parce(item)).ToList();
        }

        public List<UsuarioVO> ParceList(List<Usuario> origem)
        {
            if (origem == null) return new List<UsuarioVO>();

            return origem.Select(item => Parce(item)).ToList();
        }
    }
}
