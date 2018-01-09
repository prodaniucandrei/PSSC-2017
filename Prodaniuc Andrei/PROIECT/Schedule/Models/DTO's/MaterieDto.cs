namespace Models.Comenzi
{
    public class MaterieDto
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public TipActivitate Tip { get; set; }
        public string Desfasurare { get; set; }
        public bool Aprobata { get; set; }
    }
}