using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ComandaStartActivitate:Comanda
    {
        public Guid IdActivitate { get; set; }
    }
}
