using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Evenimente
{
    public static class MagistralaEvenimenteEx
    {
        public static void InregistreazaProcesatoareStandard(this MagistralaEvenimente magistrala)
        {
            magistrala.InregistreazaProcesator(TipEveniment.AdaugareMaterie, new ProcesatorAdaugareMaterie());
            magistrala.InregistreazaProcesator(TipEveniment.AprobareMaterie, new ProcesatorAprobareMaterie());
            magistrala.InregistreazaProcesator(TipEveniment.AdaugareUtilizator, new ProcesatorAdaugareUtilizator());
            magistrala.InregistreazaProcesator(TipEveniment.SetareUtilizator, new ProcesatorSetareUtilizator());
        }
    }
}
