using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comenzi
{
    public class ProcesatorSetareStudent : ProcesatorComandaGeneric<ComandaSetareStudent>
    {
        public override void Proceseaza(ComandaSetareStudent comanda)
        {
            var repo = new WriteRepository();
            var student = repo.GasesteStudent(comanda.IdStudent);
            student.Setare();
            repo.SalvareEvenimente(student);
        }
    }
}
