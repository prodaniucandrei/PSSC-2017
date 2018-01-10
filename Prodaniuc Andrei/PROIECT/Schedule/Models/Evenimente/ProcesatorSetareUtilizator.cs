using Models.DTO_s;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Evenimente
{
    class ProcesatorSetareUtilizator : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {
            var eUtilizator = e.ToGeneric<UtilizatorDto>();
            var repo = new WriteRepository();
            var readRepo = new ReadRepository();
            var utilizator = readRepo.GasesteUtilizator(e.IdRadacina);
            utilizator.IsSetUp = true;
            repo.ActualizareUtilizator(utilizator);
        }
    }
}
