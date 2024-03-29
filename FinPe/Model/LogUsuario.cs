﻿using FinPe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Model
{
    public class LogUsuario : BaseEntity
    {
        public int codUsuario { get; set; }
        public DateTime horarioLogin { get; set; }
        public DateTime horarioLogout { get; set; }//No momento aqui será o horário em que o sistema deveria ser saido
        public string atividade { get; set; }
    }
}
