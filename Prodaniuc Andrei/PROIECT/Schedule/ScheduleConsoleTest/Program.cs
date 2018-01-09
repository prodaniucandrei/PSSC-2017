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


            var studentDto = new StudentDto()
            {

                Id = Guid.Parse("0E38FAA1-7C1D-4DCE-A4A7-89A6AD960154"),
                Email = utilizatorDto.Email,
                Facultate="AC",
                Sectie="IS",
                An="4",
                Grupa="3",
                Subgrupa="1",
                Nume="Prodaniuc Andrei",
                DateContact="AR15PRD"
            };

            //writeRepository.AdaugareStudent(studentDto);

            //----------------
            var student = writeRepository.GasesteStudent(Guid.Parse("0E38FAA1-7C1D-4DCE-A4A7-89A6AD960154"));


            Console.ReadKey();
        }
    }
}
