using Models.DataAccessLayer;
using Models.DTO_s;
using Models.Evenimente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class WriteRepository
    {
        internal Materie GasesteMaterie(Guid idMaterie)
        {
            var evenimenteMaterie = IncarcaListaDeEvenimente().Where(e => e.IdRadacina == idMaterie);

            return new Models.Materie();
        }

        private List<Eveniment> IncarcaListaDeEvenimente()
        {
            throw new NotImplementedException();
        }

        internal void SalvareEvenimente(object materie)
        {
            throw new NotImplementedException();
        }

        internal void SalvareEvenimente(Utilizator utilizator)
        {
            SalvareEvenimente(utilizator.EvenimenteNoi);
        }

        public void AdaugareUtilizator(UtilizatorDto utilizatorDto)
        {
            var utilizator = new Utilizator(utilizatorDto);
            utilizatorDto.Password = utilizator.Password.Value.Text;
            SalvareEvenimente(utilizator);
            SalvareUtilizator(utilizatorDto);
        }

        private void SalvareUtilizator(UtilizatorDto utilizatorDto)
        {
            var dal = new Dal();
            dal.SalvareUtilizator(utilizatorDto);
        }

        private void SalvareEvenimente(ReadOnlyCollection<Eveniment> evenimenteNoi)
        {
            var dal = new Dal();
            dal.SalvareEvenimente(evenimenteNoi);
        }
    }
}
