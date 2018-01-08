using System;
using System.Collections.Generic;
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

        internal void Adaugare()
        {
            throw new NotImplementedException();
        }
    }
}
