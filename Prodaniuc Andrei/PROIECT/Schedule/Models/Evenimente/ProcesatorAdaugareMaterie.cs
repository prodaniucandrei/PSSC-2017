using Models.Comenzi;
using Models.Repositories;
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
            var eMaterie = e.ToGeneric<MaterieDto>();
            var repo = new WriteRepository();
            var orar = repo.GasesteOrarInLista(e.IdRadacina);
            orar.Materii.Add(eMaterie.Detalii);
            repo.ActualizareOrar(orar);
        }
    }
}
