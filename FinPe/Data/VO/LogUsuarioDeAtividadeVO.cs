using FinPe.Model.Base;
using System;

namespace FinPe.Data.VO
{
    public class LogUsuarioDeAtividadeVO : BaseEntity
    {
        public int codUsuario { get; set; }
        public DateTime dataAtividade { get; set; }
        public string atividade { get; set; }
    }
}
