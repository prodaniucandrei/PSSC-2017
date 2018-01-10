using Models.DataAccessLayer;
using Models.DTO_s;
using Models.Evenimente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Comenzi;

namespace Models.Repositories
{
    public class WriteRepository
    {
        internal Materie GasesteMaterie(Guid idMaterie)
        {
            var evenimenteMaterie = IncarcaListaDeEvenimente().Where(e => e.IdRadacina == idMaterie);

            return new Models.Materie(evenimenteMaterie);
        }

        public OrarDto GasesteOrarInLista(Guid idRadacina)
        {
            var dal = new Dal();
            return dal.GasesteOrar(idRadacina);
        }

        public void ActualizareUtilizator(Utilizator utilizator)
        {
            var dal = new Dal();
            dal.ActualizeazaUtilizator(utilizator);
        }

        public void ActualizareOrar(OrarDto orar)
        {
            var dal = new Dal();
            dal.ActualizeazaOrar(orar);
        }



        public void SalvareEvenimente(Orar orar)
        {
            SalvareEvenimente(orar.EvenimenteNoi);
            orar.DeleteAddedEvents();
        }



        private List<Eveniment> IncarcaListaDeEvenimente()
        {
            var dal = new Dal();
            return dal.IncarcaListaEvenimente();
        }

        internal void SalvareEvenimente(Materie materie)
        {
            throw new NotImplementedException();
        }

        public void SalvareEvenimente(Student student)
        {
            SalvareEvenimente(student.EvenimenteNoi);
            student.DeleteSavedEvents();
        }

        public void SalvareEvenimente(Utilizator utilizator)
        {
            SalvareEvenimente(utilizator.EvenimenteNoi);
            utilizator.DeleteSavedEvents();
        }

        public void AdaugareUtilizator(UtilizatorDto utilizatorDto)
        {
            var readRepo = new ReadRepository();
            if (readRepo.GasesteUtilizator(utilizatorDto.Email).Id == Guid.Empty)
            {
                var utilizator = new Utilizator(utilizatorDto);
                utilizatorDto.Password = utilizator.Password.Value.Text;
                SalvareEvenimente(utilizator);
                SalvareUtilizator(utilizatorDto);
            }
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

        public void AdaugareStudent(StudentDto studentDto)
        {
            var readRepo = new ReadRepository();
            if (readRepo.GasesteStudent(studentDto.Email).Id==Guid.Empty)
            {
                var student = new Student(studentDto);
                SalvareEvenimente(student);
                SalvareStudent(studentDto);
            }
        }

        private void SalvareStudent(StudentDto studentDto)
        {
            var dal = new Dal();
            dal.SalvareStudent(studentDto);
        }

        public OrarDto CreareOrar(OrarDto orarDto)
        {
            var orar = new Orar(orarDto);
            OrarDto orarDtoExists;
            if ((orarDtoExists = OrarNotExists(orarDto)).Id == Guid.Empty)
            {
                orarDtoExists = AdaugaOrar(orarDto);
                SalvareEvenimente(orar);
            }
            else
            {
                orar.DeleteAddedEvents();
                return orarDto;
            }
            return orarDtoExists;
        }

        private OrarDto AdaugaOrar(OrarDto orarDto)
        {
            var dal = new Dal();
            return dal.AdaugareOrar(orarDto);
        }

        private OrarDto OrarNotExists(OrarDto orarDto)
        {
            var dal = new Dal();
            return dal.OrarNotExists(orarDto);
        }
    }
}
