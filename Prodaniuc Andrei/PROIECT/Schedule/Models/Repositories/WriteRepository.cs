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

        public void ActualizareOrar(OrarDto orar)
        {
            var dal = new Dal();
            dal.ActualizeazaOrar(orar);
        }

        public Orar GasesteOrar(Guid Id)
        {
            var listaEvenimente = IncarcaListaDeEvenimente();
            return new Orar(listaEvenimente);
        }

        public void SalvareEvenimente(Orar orar)
        {
            SalvareEvenimente(orar.EvenimenteNoi);
        }

        public Student GasesteStudent(Guid idStudent)
        {
            var evenimenteStudent = IncarcaListaDeEvenimente().Where(e => e.IdRadacina == idStudent);
            return new Student(evenimenteStudent);
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

        public void AdaugareStudent(StudentDto studentDto)
        {
            var student = new Student(studentDto);
            SalvareEvenimente(student);
            SalvareStudent(studentDto);
        }

        private void SalvareStudent(StudentDto studentDto)
        {
            var dal = new Dal();
            dal.SalvareStudent(studentDto);
        }

        public OrarDto CreareOrar(OrarDto orarDto)
        {
            OrarDto orar;
            if ((orar=OrarNotExists(orarDto)).Id==Guid.Empty)
            {
                orar = AdaugaOrar(orarDto);
            }
            else
            {
                return orar;
            }
            return orar;
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
