﻿using Models.Comenzi;
using Models.Evenimente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Materie
    {
        public Guid Id { get; set; }
        public PlainText Nume { get; set; }
        public TipActivitate Tip { get; set; }
        public Desfasurare Desfasurare { get; set; }
        public MaterieAprobata Aprobata { get; set; }
        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        private IEnumerable<Eveniment> evenimenteMaterie;

        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get { return _evenimenteNoi.AsReadOnly(); } }

        private MagistralaEvenimente _magistralaEvenimente;
        public Materie(MaterieDto materieDto, MagistralaEvenimente _magistrala = null)
        {
            _magistralaEvenimente = _magistrala;
            var ev = new EvenimentGeneric<MaterieDto>(materieDto.Id, TipEveniment.AdaugareMaterie, materieDto);
            Aplica(ev);
            PublicaEveniment(ev);
        }

        public Materie(IEnumerable<Eveniment> evenimenteMaterie)
        {
            this.evenimenteMaterie = evenimenteMaterie;
        }

        private void PublicaEveniment(EvenimentGeneric<MaterieDto> ev)
        {
            _evenimenteNoi.Add(ev);
        }

        private void Aplica(EvenimentGeneric<MaterieDto> ev)
        {
            Id = Guid.NewGuid();
            Nume = new PlainText(ev.Detalii.Nume);
            Tip = ev.Detalii.Tip;
            Desfasurare = new Desfasurare();
            Aprobata = new MaterieAprobata(0);
        }
        public void AprobareMaterie()
        {
            Aprobata = new MaterieAprobata(Aprobata.NumarAprobari + 1);
        }
    }
}
