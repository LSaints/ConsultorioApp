﻿namespace ConsultorioApp.Core.Domain
{
    public class Telefone
    {
        public int ClienteId { get; set; }
        public string Numero { get; set;}
        public Cliente cliente { get; set; }
    }
}
