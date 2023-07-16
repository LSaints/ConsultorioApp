namespace ConsultorioApp.Core.Domain
{
    public class Telefone : ICloneable
    {
        public int ClienteId { get; set; }
        public string Numero { get; set;}
        public Cliente cliente { get; set; }

        public Object Clone()
        {
            return MemberwiseClone();
        }
    }
}
