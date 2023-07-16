namespace ConsultorioApp.Shared.ModelView
{
    public class NovoCliente
    {
        public string Name { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoView Sexo { get; set; }
        public string Documento { get; set; }
        public NovoEndereco Endereco { get; set; }
        public ICollection<NovoTelefone> Telefones { get; set; }
    }
}
