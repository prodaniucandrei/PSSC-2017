using Models;
using Models.Comenzi;
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

namespace Schedule.Test.ScheduleTests
{
    public class StudentTests
    {
        private Mock<ProcesatorEveniment> _mockProcesatorProgramareMeci;
        private MagistralaEvenimente _magistrala;
        private OrarDto _orarDto;

        public StudentTests()
        {
            _orarDto = new OrarDto()
            {
                Id = Guid.NewGuid(),
                Sectie="IS"
            };

            _magistrala = new MagistralaEvenimente();
            _magistrala.InregistreazaProcesatoareStandard();
            _mockProcesatorProgramareMeci = new Mock<ProcesatorEveniment>();
            _magistrala.InregistreazaProcesator(TipEveniment.AdaugareUtilizator, _mockProcesatorProgramareMeci.Object);
            _magistrala.InchideInregistrarea();
        }

        [Fact]
        public void CreateOrarTest()
        {
            var orar = new Orar(_orarDto, _magistrala);

            Assert.Equal(orar.Id, _orarDto.Id);
            Assert.Equal(orar.Sectie.Text, _orarDto.Sectie);
        }

        [Fact]
        public void VerificareOrarId()
        {
            string sectie = "IS";
            var orar = new OrarDto() { Sectie = sectie};

            Assert.Throws<EmptyGuidException>(() => { new Orar(_orarDto, _magistrala); });
        }


        [Fact]
        public void TrebuieSaGenerezeEvenimentNouAdaugareUtilizator()
        {
            var orar = new Orar(_orarDto, _magistrala);

            Assert.NotEmpty(orar.EvenimenteNoi);
            var e = orar.EvenimenteNoi.First();
            Assert.Equal(TipEveniment.AdaugareUtilizator, e.Tip);
            Assert.IsType<EvenimentGeneric<UtilizatorDto>>(e);
            Assert.Equal(orar.Id, e.IdRadacina);
            Assert.Equal("IS", ((EvenimentGeneric<OrarDto>)e).Detalii.Sectie);
        }

        [Fact]
        public void CreareMaterie()
        {

            var materieDto = new MaterieDto()
            {
                Id=Guid.NewGuid(),
                Nume="PSSC",
                Tip=TipActivitate.Laborator,
                Aprobata=false,
            };

            var materie = new Materie(materieDto, _magistrala);

            Assert.Equal(materie.Id, materieDto.Id);
            Assert.Equal(materie.Nume.Text, materieDto.Nume);
            Assert.Equal(materie.Tip, materieDto.Tip);
            Assert.Equal(materie.Aprobata.Value, materieDto.Aprobata);
        }

        [Fact]
        public void AdaugareMaterieInOrar()
        {
            var orar = new Orar(_orarDto, _magistrala);
            var materieDto = new MaterieDto()
            {
                Id = Guid.NewGuid(),
                Nume = "PSSC",
                Tip = TipActivitate.Laborator,
                Aprobata = false,
            };

            var materie = new Materie(materieDto, _magistrala);

            orar.AdaugareMaterie(materieDto);

            Assert.Equal(1, orar.Materii.Count);
        }
    }
}
