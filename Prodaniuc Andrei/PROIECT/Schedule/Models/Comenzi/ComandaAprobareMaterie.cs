using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ComandaAprobareMaterie : Comanda
    {
        public Guid IdMaterie { get; set; }
    }
}
