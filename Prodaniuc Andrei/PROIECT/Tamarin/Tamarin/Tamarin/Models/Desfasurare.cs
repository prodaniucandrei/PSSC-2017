using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamarin.Models
{
    public class Desfasurare
    {
        public PlainText Zi { get; set; }
        public PlainText Semestru { get; set; }
        public OraStart OraStart { get; set; }
        public Durata Durata { get; set; }
    }
}
