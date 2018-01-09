using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamarin.Models.Enum;

namespace Tamarin.Models
{
    public class Materie
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public TipActivitate Tip { get; set; }
        public Desfasurare Desfasurare { get; set; }
        public bool Aprobata { get; set; }
    }
}
