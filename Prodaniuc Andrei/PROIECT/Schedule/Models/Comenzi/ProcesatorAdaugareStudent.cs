//using Models.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Models.Comenzi
//{
//    public class ProcesatorAdaugareStudent : ProcesatorComandaGeneric<ComandaAdaugareStudent>
//    {
//        public override void Proceseaza(ComandaAdaugareStudent comanda)
//        {
//            var repo = new WriteRepository();
//            var student = comanda.Student;
//            repo.SalvareEvenimente(student);
//        }
//    }
//}
