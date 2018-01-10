using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public static class MagistralaComenziEx
    {
        public static void InregistreazaProcesatoareStandard(this MagistralaComenzi magistrala)
        {
            magistrala.InregistreazaProcesator(new ProcesatorAdaugareMaterie());
            magistrala.InregistreazaProcesator(new ProcesatorAprobareMaterie());
            magistrala.InregistreazaProcesator(new ProcesatorSetareStudent());

        }
    }
}
