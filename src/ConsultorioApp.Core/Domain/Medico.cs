﻿namespace ConsultorioApp.Core.Domain
{
    public class Medico
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CRM { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }
    }
}
