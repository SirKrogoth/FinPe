using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int codigo { get; set; }
    }
}
