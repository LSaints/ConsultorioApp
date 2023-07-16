namespace ConsultorioApp.Core.Domain
{
    public class Cliente
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
    }
}
