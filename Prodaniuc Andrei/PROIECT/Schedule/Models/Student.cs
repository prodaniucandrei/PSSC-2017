using Models.DTO_s;
using Models.Evenimente;
using Models.Exceptions;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public Email Email { get; set; }
        public PlainText Nume { get; set; }
        public PlainText Facultate { get; set; }
        public PlainText Sectie { get; set; }
        public PlainText An { get; set; }
        public PlainText Grupa { get; set; }

        public void Setare()
        {
          
        }

        public PlainText Subgrupa { get; set; }
        public PlainText DateContact { get; set; }

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        private IEnumerable<Eveniment> evenimenteStudent;
        private MagistralaEvenimente _magistralaEveniment;
        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get { return _evenimenteNoi.AsReadOnly(); } }

        public Student(StudentDto studentDto, MagistralaEvenimente _magistrala = null)
        {
            _magistralaEveniment = _magistrala;
            var ev = new EvenimentGeneric<StudentDto>(studentDto.Id, TipEveniment.AdaugareStudent, studentDto);
            Aplica(ev);
            PublicaEveniment(ev);
        }

        public Student(IEnumerable<Eveniment> evenimenteStudent)
        {
            foreach (var e in evenimenteStudent)
            {
                RedaEvenimente(e);
            }
        }

        private void RedaEvenimente(Eveniment e)
        {
            switch (e.Tip)
            {
                case TipEveniment.AdaugareStudent:
                    Aplica(e.ToGeneric<StudentDto>());
                    break;
                
            }
        }

        private void PublicaEveniment(EvenimentGeneric<StudentDto> ev)
        {
            _evenimenteNoi.Add(ev);
        }

        private void Aplica(EvenimentGeneric<StudentDto> ev)
        {
            if (ev.Detalii.Id == Guid.Empty)
                throw new EmptyGuidException();
            Id = ev.Detalii.Id;
            Email = new Email(new PlainText(ev.Detalii.Email));
            Nume = new PlainText(ev.Detalii.Nume);
            Facultate = new PlainText(ev.Detalii.Facultate);
            Sectie = new PlainText(ev.Detalii.Sectie);
            An = new PlainText(ev.Detalii.An);
            Grupa = new PlainText(ev.Detalii.Grupa);
            Subgrupa = new PlainText(ev.Detalii.Subgrupa);
            DateContact = new PlainText(ev.Detalii.DateContact);
        }
    }
}
