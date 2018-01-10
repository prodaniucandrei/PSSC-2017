using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO_s;
using Models.DataAccessLayer;
using Models.Evenimente;

namespace Models.Repositories
{
    public class ReadRepository
    {
        public UserLogged LogareUtilizator(UtilizatorDto utilizatorDto)
        {
            var dal = new Dal();
            return dal.LogareUtilizator(utilizatorDto);
        }

        public OrarDto IncarcaOrar(string sectia)
        {
            var dal = new Dal();
            var orarDto = new OrarDto() { Sectie = sectia };
            return dal.OrarNotExists(orarDto);
        }

        public Student GasesteStudent(Guid idStudent)
        {
            var evenimenteStudent = IncarcaListaDeEvenimente().Where(e => e.IdRadacina == idStudent);
            return new Student(evenimenteStudent);
        }

        public Orar GasesteOrar(Guid Id)
        {
            var listaEvenimente = IncarcaListaDeEvenimente();
            return new Orar(listaEvenimente);
        }

        private List<Eveniment> IncarcaListaDeEvenimente()
        {
            var dal = new Dal();
            return dal.IncarcaListaEvenimente();
        }

    }
}
