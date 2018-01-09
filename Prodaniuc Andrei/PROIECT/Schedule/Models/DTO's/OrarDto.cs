using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO_s
{
    public class OrarDto
    {
        public Guid Id { get; set; }
        public string Sectie { get; set; }
        public List<Materie> Materii { get; set; }
    }
}
