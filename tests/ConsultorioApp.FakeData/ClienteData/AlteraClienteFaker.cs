using Bogus;
using ConsultorioApp.FakeData.EnderecoData;
using ConsultorioApp.FakeData.TelefoneData;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.FakeData.ClienteData
{
    public class AlteraClienteFaker : Faker<AlteraCliente>
    {
        public AlteraClienteFaker()
        {
            var Id = new Faker().Random.Number(1, 100);
            RuleFor(p => p.Id, _ => Id);
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(p => p.Telefones, _ => new NovoTelefoneFaker().Generate(3));
            RuleFor(p => p.Endereco, _ => new NovoEnderecoFaker().Generate());
        }
    }
}
