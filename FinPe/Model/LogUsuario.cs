using FinPe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Model
{
    public class LogUsuario
    {
        [Key]
        public int? codUsuario { get; set; }
        public DateTime horarioLogin { get; set; }
        public DateTime horarioLogout { get; set; }
        public string atividade { get; set; }
    }
}
