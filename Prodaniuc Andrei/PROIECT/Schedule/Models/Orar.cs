using Models.Comenzi;
using Models.DTO_s;
using Models.Evenimente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orar
    {
        public Guid Id { get; set; }
        public PlainText Sectie { get; set; }
        public List<MaterieDto> Materii { get; set; }
        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        private List<Eveniment> listaEvenimente;

        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get { return _evenimenteNoi.AsReadOnly(); } }

        private MagistralaEvenimente _magistralaEvenimente;
        public Orar(OrarDto orarDto, MagistralaEvenimente _magistrala = null)
        {
            _magistralaEvenimente = _magistrala;
            var ev = new EvenimentGeneric<OrarDto>(orarDto.Id, TipEveniment.AdaugareOrar, orarDto);
            Aplica(ev);
            PublicaEveniment(ev);
        }

        private void PublicaEveniment(Eveniment ev)
        {
            _evenimenteNoi.Add(ev);
            MagistralaEvenimente.Instanta.Value.Trimite(ev);
        }

        public void DeleteAddedEvents()
        {
            _evenimenteNoi.Clear();
        }

        public Orar()
        {

        }

        public Orar(List<Eveniment> listaEvenimente)
        {

            foreach (var e in listaEvenimente)
            {
                RedaEveniment(e);
            }
        }

        private void RedaEveniment(Eveniment e)
        {
            switch (e.Tip)
            {
                case TipEveniment.AdaugareOrar:
                    Aplica(e.ToGeneric<OrarDto>());
                    break;
                case TipEveniment.AdaugareMaterie:
                    Aplica(e.ToGeneric<MaterieDto>());
                        break;
            }
        }

        public void AdaugareMaterie(MaterieDto materieDto)
        {
            var materie = new Materie(materieDto);
            var e = new EvenimentGeneric<MaterieDto>(this.Id, TipEveniment.AdaugareMaterie, materieDto);
            Aplica(e);
            PublicaEveniment(e);
        }

        private void Aplica(EvenimentGeneric<MaterieDto> e)
        {
            Materii.Add(e.Detalii);
        }

        private void Aplica(EvenimentGeneric<OrarDto> ev)
        {
            Id = ev.Detalii.Id;
            Sectie = new PlainText(ev.Detalii.Sectie);
            Materii = ev.Detalii.Materii;
        }
    }
}
