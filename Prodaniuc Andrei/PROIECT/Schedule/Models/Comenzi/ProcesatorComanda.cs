using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public abstract class ProcesatorComanda
    {
        public abstract void Proceseaza(Comanda comanda);
    }
}
