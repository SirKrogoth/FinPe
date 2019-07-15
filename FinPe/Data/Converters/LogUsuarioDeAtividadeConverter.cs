using FinPe.Data.Converter;
using FinPe.Data.VO;
using FinPe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Data.Converters
{
    public class LogUsuarioDeAtividadeConverter : IParce<LogUsuarioDeAtividadeVO, LogUsuarioDeAtividade>, IParce<LogUsuarioDeAtividade, LogUsuarioDeAtividadeVO>
    {
        public LogUsuarioDeAtividade Parce(LogUsuarioDeAtividadeVO origem)
        {
            if (origem == null) return new LogUsuarioDeAtividade();

            return new LogUsuarioDeAtividade
            {
                codUsuario = origem.codUsuario,
                dataAtividade = origem.dataAtividade,
                atividade = origem.atividade
            };
        }

        public LogUsuarioDeAtividadeVO Parce(LogUsuarioDeAtividade origem)
        {
            if (origem == null) return new LogUsuarioDeAtividadeVO();

            return new LogUsuarioDeAtividadeVO
            {
                codUsuario = origem.codUsuario,
                dataAtividade = origem.dataAtividade,
                atividade = origem.atividade
            };
        }

        public List<LogUsuarioDeAtividade> ParceList(List<LogUsuarioDeAtividadeVO> origem)
        {
            if (origem == null) return new List<LogUsuarioDeAtividade>();

            return origem.Select(item => Parce(item)).ToList();
        }

        public List<LogUsuarioDeAtividadeVO> ParceList(List<LogUsuarioDeAtividade> origem)
        {
            if (origem == null) return new List<LogUsuarioDeAtividadeVO>();

            return origem.Select(item => Parce(item)).ToList();
        }
    }
}