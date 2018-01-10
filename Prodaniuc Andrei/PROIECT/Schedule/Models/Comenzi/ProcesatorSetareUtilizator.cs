using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    class ProcesatorSetareUtilizator : ProcesatorComandaGeneric<ComandaSetareUtilizator>
    {
        public override void Proceseaza(ComandaSetareUtilizator comanda)
        {
            var repo = new WriteRepository();
            var readRepo = new ReadRepository();
            var utilizator = readRepo.GasesteUtilizator(comanda.IdUtilizator);
            utilizator.SetareUtilizator(comanda.UtilizatorDto);
            repo.SalvareEvenimente(utilizator);
        }
    }
}
