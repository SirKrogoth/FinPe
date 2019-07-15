using FinPe.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Model
{
    public class LogUsuarioDeAtividade : BaseEntity
    {
        public int codUsuario { get; set; }
        public DateTime dataAtividade { get; set; }
        public string atividade { get; set; }
    }
}
