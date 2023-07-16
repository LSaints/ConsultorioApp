using Bogus;
using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.FakeData.EnderecoData
{
    public class EnderecoFaker : Faker<Endereco>
    {
        public EnderecoFaker()
        {
            RuleFor(p => p.Numero, f => f.Address.BuildingNumber());
            RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(p => p.Cidade, f => f.Address.City());
            RuleFor(p => p.Estado, f => f.PickRandom<Estado>());
            RuleFor(p => p.Complemento, f => f.Lorem.Sentence(20));
        }
    }
}
