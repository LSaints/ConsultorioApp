using Bogus;
using Bogus.Extensions.Brazil;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.FakeData.EnderecoData;
using ConsultorioApp.FakeData.TelefoneData;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.FakeData.ClienteData
{
    public class NovoClienteFaker : Faker<NovoCliente>
    {
        public NovoClienteFaker()
        {
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(p => p.Documento, f => f.Person.Cpf());
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
            RuleFor(p => p.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new NovoEnderecoFaker().Generate());

        }
    }
}
