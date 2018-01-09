using Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ComandaAdaugareMaterie : Comanda
    {
        public Guid IdOrar { get; set; }
        public MaterieDto MaterieDto{ get; set; }
    }
}
