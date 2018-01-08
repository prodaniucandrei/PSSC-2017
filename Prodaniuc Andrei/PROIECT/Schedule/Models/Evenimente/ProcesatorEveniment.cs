using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Evenimente
{
    public abstract class ProcesatorEveniment
    {
        public abstract void Proceseaza(Eveniment e);
    }
}
