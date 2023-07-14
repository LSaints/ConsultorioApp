namespace ConsultorioApp.Shared.ModelView
{
    public class NovoMedico
    {
        public string Name { get; set; }
        public int CRM { get; set; }
        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}
