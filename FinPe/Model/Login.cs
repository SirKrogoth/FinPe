using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Model
{
    public class Login
    {
        [Key]
        public int? codigo { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
    }
}
