using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Data.Converter
{
    public interface IParce<O, D>
    {
        D Parce(O origem);
        List<D> ParceList(List<O> origem);
    }
}
