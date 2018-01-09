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
        public List<Materie> Materii { get; set; }
        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get { return _evenimenteNoi.AsReadOnly(); } }

        public Orar(OrarDto orarDto)
        {
            var ev = new EvenimentGeneric<OrarDto>(orarDto.Id, TipEveniment.AdaugareOrar, orarDto);
            Aplica(ev);
            PublicaEveniment(ev);
        }

        private void PublicaEveniment(EvenimentGeneric<OrarDto> ev)
        {
            _evenimenteNoi.Add(ev);
        }

        public Orar()
        {

        }

        public void AdaugareMaterie(MaterieDto materieDto)
        {
            var materie = new Materie(materieDto);
            Materii.Add(materie);
        }
        private void Aplica(EvenimentGeneric<OrarDto> ev)
        {
            Id = ev.Detalii.Id;
            Sectie = new PlainText(ev.Detalii.Sectie);
            Materii = ev.Detalii.Materii;
        }
    }
}
