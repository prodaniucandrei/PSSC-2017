using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public PlainText Nume { get; set; }
        public PlainText Facultate { get; set; }
        public PlainText An { get; set; }
        public PlainText Grupa { get; set; }
        public PlainText Subgrupa { get; set; }
        public PlainText DateContact { get; set; }
        public Orar Orar { get; set; }
    }
}
