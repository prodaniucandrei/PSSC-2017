using Models;
using Models.Comenzi;
using Models.DTO_s;
using Models.Evenimente;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();

            var writeRepository = new WriteRepository();
            
            //--------

            var utilizatorDto = new UtilizatorDto()
            {
                Id = Guid.NewGuid(),
                Email = "test1@upt.ro",
                Password = "parola",
                IsSetUp = false
            };

            //writeRepository.AdaugareUtilizator(utilizatorDto);

            var readRepository = new ReadRepository();
            utilizatorDto.Password = new Password(new PlainText(utilizatorDto.Password)).Value.Text;
            var guid = readRepository.LogareUtilizator(utilizatorDto);
            Console.WriteLine(guid);
            //-----------------




            Console.ReadKey();
        }
    }
}
