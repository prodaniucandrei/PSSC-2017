using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ComandaAdaugareMaterie : Comanda
    {
        public Guid IdMaterie { get; set; }
        public MaterieDto Materie { get; set; }
    }
}
