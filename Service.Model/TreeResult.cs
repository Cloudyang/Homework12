using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class TreeResult<T>
    {
        public int total { get; set; }
        public IEnumerable<T> rows { get; set; }
    }
}
