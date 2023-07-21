﻿using Bogus;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.FakeData.EnderecoData
{
    public class NovoEnderecoFaker : Faker<NovoEndereco>
    {
        public NovoEnderecoFaker()
        {
            RuleFor(p => p.Numero, f => f.Address.BuildingNumber());
            RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(p => p.Cidade, f => f.Address.City());
            RuleFor(p => p.Estado, f => f.PickRandom<EstadoView>());
            RuleFor(p => p.Complemento, f => f.Lorem.Sentence(20));
            RuleFor(p => p.Logradouro, f => f.Address.StreetName());
        }
    }
}
