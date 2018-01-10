using Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ComandaSetareUtilizator : Comanda
    {
        public Guid IdUtilizator { get; set; }
        public UtilizatorDto UtilizatorDto{ get; set; }
    }
}
