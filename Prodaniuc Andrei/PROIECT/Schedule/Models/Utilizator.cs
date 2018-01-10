using Models.DTO_s;
using Models.Evenimente;
using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Utilizator
    {
        public Guid Id { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public bool IsSetUp { get; set; }

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();

        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get { return _evenimenteNoi.AsReadOnly(); } }
        private MagistralaEvenimente _magistralaEveniment;
        public Utilizator(UtilizatorDto utilizatorDto, MagistralaEvenimente _magistrala=null)
        {
            _magistralaEveniment = _magistrala;
            var ev = new EvenimentGeneric<UtilizatorDto>(utilizatorDto.Id, TipEveniment.AdaugareUtilizator, utilizatorDto);
            Aplica(ev);
            PublicaEveniment(ev);
        }

        public Utilizator(IEnumerable<Eveniment> evenimenteUtilizator)
        {
            foreach (var e in evenimenteUtilizator)
            {
                RedaEvenimente(e);
            }
        }

        public Utilizator(List<Eveniment> evenimenteUtilizator)
        {
            foreach (var e in evenimenteUtilizator)
            {
                RedaEvenimente(e);
            }
        }

        private void RedaEvenimente(Eveniment e)
        {
            switch (e.Tip)
            {
                case TipEveniment.AdaugareUtilizator:
                    Aplica(e.ToGeneric<UtilizatorDto>());
                    break;
                case TipEveniment.SetareUtilizator:
                    Aplica(e.ToGeneric<UtilizatorDto>());
                    break;
                    default: break;
            }
        }

        public void DeleteSavedEvents()
        {
            _evenimenteNoi.Clear();
        }



        private void PublicaEveniment(Eveniment e)
        {
            _evenimenteNoi.Add(e);

            MagistralaEvenimente.Instanta.Value.Trimite(e);
        }

        private void Aplica(EvenimentGeneric<UtilizatorDto> ev)
        {
            if (ev.Detalii.Id == Guid.Empty)
                throw new EmptyGuidException();
            Id = ev.Detalii.Id;
            Email = new Email(new PlainText(ev.Detalii.Email));
            Password = new Password(new PlainText(ev.Detalii.Password));
            IsSetUp = ev.Detalii.IsSetUp;
        }

        public void SetareUtilizator(UtilizatorDto setDto)
        {
            var ev = new EvenimentGeneric<UtilizatorDto>(setDto.Id, TipEveniment.SetareUtilizator, setDto);
            Aplica(ev);
            PublicaEveniment(ev);
        }

        private void Aplica(EvenimentGeneric<SetareUtilizatorDto> ev)
        {
           IsSetUp = true;
        }
    }
}