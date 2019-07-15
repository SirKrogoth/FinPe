using System;
using System.ComponentModel.DataAnnotations;

namespace FinPe.Data.VO
{
    public class LogUsuarioVO
    {
        public int codUsuario { get; set; }
        public DateTime horarioLogin { get; set; }
        public DateTime horarioLogout { get; set; }//No momento aqui será o horário em que o sistema deveria ser saido
        public string atividade { get; set; }
    }
}
