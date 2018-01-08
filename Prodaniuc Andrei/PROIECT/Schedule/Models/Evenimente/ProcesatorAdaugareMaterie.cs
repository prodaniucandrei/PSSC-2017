using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Evenimente
{
    public class ProcesatorAdaugareMaterie : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {
            var eMaterie = e.ToGeneric<Materie>();
            
        }
    }
}
