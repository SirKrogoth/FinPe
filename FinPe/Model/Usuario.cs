using FinPe.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Model
{
    public class Usuario : BaseEntity
    {
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}
