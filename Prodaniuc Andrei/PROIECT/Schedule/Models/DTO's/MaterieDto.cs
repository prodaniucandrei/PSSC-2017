using Models.DTO_s;
using System;

namespace Models.Comenzi
{
    public class MaterieDto
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public TipActivitate Tip { get; set; }
        public Desfasurare Desfasurare { get; set; }
        public bool Aprobata { get; set; }
    }
}