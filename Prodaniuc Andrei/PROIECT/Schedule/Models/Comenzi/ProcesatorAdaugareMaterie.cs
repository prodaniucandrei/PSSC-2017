using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ProcesatorAdaugareMaterie:ProcesatorComandaGeneric<ComandaAdaugareMaterie>
    {
        public override void Proceseaza(ComandaAdaugareMaterie comanda)
        {
            var repo = new WriteRepository();
            var materie = repo.GasesteMaterie(comanda.IdMaterie);
            materie.Adaugare();
            repo.SalvareEvenimente(materie);
        }
    }
}
