using System;
using Xunit;
using Models.Evenimente;
using Moq;
using Models.DTO_s;
using Models;
using Models.Exceptions;
using System.Linq;

namespace Schedule.Test.UserTests
{
  
    public class CreateUser
    {
        private Mock<ProcesatorEveniment> _mockProcesatorProgramareMeci;
        private MagistralaEvenimente _magistrala;
        private UtilizatorDto _utilizatorDto;

        public CreateUser()
        {
            _utilizatorDto = new UtilizatorDto() { Id = Guid.NewGuid(),Email="student@upt.ro", Password="pwd", IsSetUp=false };
            _magistrala = new MagistralaEvenimente();
            _magistrala.InregistreazaProcesatoareStandard();
            _mockProcesatorProgramareMeci = new Mock<ProcesatorEveniment>();
            _magistrala.InregistreazaProcesator(TipEveniment.AdaugareUtilizator, _mockProcesatorProgramareMeci.Object);
            _magistrala.InchideInregistrarea();
        }

        [Fact]
        public void CreateUserTest()
        {
            var utilizator = new Utilizator(_utilizatorDto, _magistrala);

            Assert.Equal(utilizator.Email.Value.Text, _utilizatorDto.Email);
            Assert.Equal(utilizator.Password.Value.Text, _utilizatorDto.Password);
            Assert.Equal(utilizator.Id, _utilizatorDto.Id);
            Assert.Equal(utilizator.IsSetUp, _utilizatorDto.IsSetUp);
        }

        [Fact]
        public void VerificareUserId()
        {
            string email = "std@upt.ro";
            string password = "pwd";
            var userDto = new UtilizatorDto() { Email = email, Password = password };

            Assert.Throws<EmptyGuidException>(()=> { new Utilizator(userDto, _magistrala); });
        }


        [Fact]
        public void TrebuieSaGenerezeEvenimentNouAdaugareUtilizator()
        {
            var user = new Utilizator(_utilizatorDto, _magistrala);

            Assert.NotEmpty(user.EvenimenteNoi);
            var e = user.EvenimenteNoi.First();
            Assert.Equal(TipEveniment.AdaugareUtilizator, e.Tip);
            Assert.IsType<EvenimentGeneric<UtilizatorDto>>(e);
            Assert.Equal(_utilizatorDto.Id, e.IdRadacina);
            Assert.Equal("student@upt.ro", ((EvenimentGeneric<UtilizatorDto>)e).Detalii.Email);
        }

        [Fact]
        public void CheckUserLogin()
        {

        }

    }
}
