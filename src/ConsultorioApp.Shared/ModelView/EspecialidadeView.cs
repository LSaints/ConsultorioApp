namespace ConsultorioApp.Shared.ModelView
{
    public class EspecialidadeView
    {
        public string Descricao { get; set; }
        public ICollection<NovoMedico> Medicos { get; set; }
    }
}
