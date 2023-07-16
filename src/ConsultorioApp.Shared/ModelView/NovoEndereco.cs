namespace ConsultorioApp.Shared.ModelView
{
    public class NovoEndereco
    {
        public int CEP { get; set; }
        public EstadoView Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}