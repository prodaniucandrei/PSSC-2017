using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ProcesatorAdaugareUtilizator : ProcesatorComandaGeneric<ComandaAdaugareUtilizator>
    {
        public override void Proceseaza(ComandaAdaugareUtilizator comanda)
        {
            var repo = new WriteRepository();
            var utilizator = comanda.Utilizator;
            repo.SalvareEvenimente(utilizator);
        }
    }
}
