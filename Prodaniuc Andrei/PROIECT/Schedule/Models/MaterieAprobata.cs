namespace Models
{
    public class MaterieAprobata
    {
        public int NumarAprobari { get; set; }
        public bool Value { get { return NumarAprobari > 1 ? true : false; } }

        public MaterieAprobata(int numarAprobari)
        {
            NumarAprobari = numarAprobari;
        }
    }
}