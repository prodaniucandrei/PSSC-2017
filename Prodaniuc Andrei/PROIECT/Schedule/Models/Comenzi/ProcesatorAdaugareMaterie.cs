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
            var readRepo = new ReadRepository();
            var orar = readRepo.GasesteOrar(comanda.IdOrar);
            orar.AdaugareMaterie(comanda.MaterieDto);
            repo.SalvareEvenimente(orar);
        }
    }
}
