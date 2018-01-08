using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO_s
{
    public class StudentDto
    {
        public Guid Id { get; set}
        public string Nume{ get; set; }
        public string Facultate { get; set; }
        public string An { get; set; }
        public string Grupa { get; set; }
        public string Subgrupa { get; set; }
        public string DateContact { get; set; }
        public Orar Orar { get; set; }
    }
}
