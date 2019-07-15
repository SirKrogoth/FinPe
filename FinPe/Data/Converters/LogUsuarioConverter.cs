using FinPe.Data.Converter;
using FinPe.Data.VO;
using FinPe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Data.Converters
{
    public class LogUsuarioConverter : IParce<LogUsuarioVO, LogUsuario>, IParce<LogUsuario, LogUsuarioVO>
    {
        public LogUsuario Parce(LogUsuarioVO origem)
        {
            if (origem == null) return new LogUsuario();

            return new LogUsuario
            {
                codUsuario = origem.codUsuario,
                horarioLogin = origem.horarioLogin,
                horarioLogout = origem.horarioLogout,
                atividade = origem.atividade
            };
        }

        public LogUsuarioVO Parce(LogUsuario origem)
        {
            if (origem == null) return new LogUsuarioVO();

            return new LogUsuarioVO
            {
                codUsuario = origem.codUsuario,
                horarioLogin = origem.horarioLogin,
                horarioLogout = origem.horarioLogout,
                atividade = origem.atividade
            };
        }

        public List<LogUsuario> ParceList(List<LogUsuarioVO> origem)
        {
            if (origem == null) return new List<LogUsuario>();

            return origem.Select(item => Parce(item)).ToList();
        }

        public List<LogUsuarioVO> ParceList(List<LogUsuario> origem)
        {
            if (origem == null) return new List<LogUsuarioVO>();

            return origem.Select(item => Parce(item)).ToList();
        }
    }
}