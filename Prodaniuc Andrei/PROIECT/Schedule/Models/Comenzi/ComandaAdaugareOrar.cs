using Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ComandaAdaugareOrar:Comanda
    {
        public int IdOrar { get; set; }
        public OrarDto OrarDto{ get; set; }
    }
}
