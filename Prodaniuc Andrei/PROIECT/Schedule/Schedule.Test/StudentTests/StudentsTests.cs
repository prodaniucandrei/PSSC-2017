using Models;
using Models.DTO_s;
using Models.Evenimente;
using Models.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Schedule.Test.StudentTests
{
    public class StudentTests
    {
        private Mock<ProcesatorEveniment> _mockProcesatorProgramareMeci;
        private MagistralaEvenimente _magistrala;
        private StudentDto _studentDto;

        public StudentTests()
        {
            _studentDto = new StudentDto()
            {
                Id = Guid.NewGuid(),
                Email = "student@upt.ro",
                An = "4",
                Sectie = "IS",
                Subgrupa = "1",
                Grupa = "3",
                Facultate = "AC",
                Nume = "Andrei",
                DateContact = "ar"
            };
            _magistrala = new MagistralaEvenimente();
            _magistrala.InregistreazaProcesatoareStandard();
            _mockProcesatorProgramareMeci = new Mock<ProcesatorEveniment>();
            _magistrala.InregistreazaProcesator(TipEveniment.AdaugareUtilizator, _mockProcesatorProgramareMeci.Object);
            _magistrala.InchideInregistrarea();
        }

        [Fact]
        public void CreateStudentTest()
        {
            var student = new Student(_studentDto, _magistrala);

            Assert.Equal(student.Email.Value.Text, _studentDto.Email);
            Assert.Equal(student.An.Text, _studentDto.An);
            Assert.Equal(student.DateContact.Text, _studentDto.DateContact);
            Assert.Equal(student.Facultate.Text, _studentDto.Facultate);
            Assert.Equal(student.Grupa.Text, _studentDto.Grupa);
            Assert.Equal(student.Subgrupa.Text, _studentDto.Subgrupa);
            Assert.Equal(student.Id, _studentDto.Id);
            Assert.Equal(student.Sectie.Text, _studentDto.Sectie);
        }

        [Fact]
        public void VerificareStudentId()
        {
            string email = "std@upt.ro";
            string password = "pwd";
            var studentDto = new StudentDto() { Email = email, Nume = "Andrei" };

            Assert.Throws<EmptyGuidException>(() => { new Student(studentDto, _magistrala); });
        }


        [Fact]
        public void TrebuieSaGenerezeEvenimentNouAdaugareStudent()
        {
            var student = new Student(_studentDto, _magistrala);

            Assert.NotEmpty(student.EvenimenteNoi);
            var e = student.EvenimenteNoi.First();
            Assert.Equal(TipEveniment.AdaugareUtilizator, e.Tip);
            Assert.IsType<EvenimentGeneric<UtilizatorDto>>(e);
            Assert.Equal(student.Id, e.IdRadacina);
            Assert.Equal("student@upt.ro", ((EvenimentGeneric<StudentDto>)e).Detalii.Email);
        }
    }
}
