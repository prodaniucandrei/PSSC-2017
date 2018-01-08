using Models.DTO_s;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Evenimente
{
    public class ProcesatorAdaugareUtilizator : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {
            var eNewUtilizator = e.ToGeneric<UtilizatorDto>();
            //var repo = new WriteRepository();
            //repo.GasesteUtilizator(eNewUtilizator.IdRadacina);
        }
    }
}
