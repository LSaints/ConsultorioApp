namespace ConsultorioApp.Core.Domain
{
    public class Cliente : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set;}

        public object Clone()
        {
            var cliente = (Cliente)MemberwiseClone();
            cliente.Endereco = (Endereco)cliente.Endereco.Clone();
            var telefones = new List<Telefone>();
            cliente.Telefones.ToList().ForEach(p => telefones.Add((Telefone)p.Clone()));
            cliente.Telefones = telefones;
            return cliente;
        }

        public Cliente CloneTipado()
        {
            return (Cliente)Clone();
        }
    }
}
