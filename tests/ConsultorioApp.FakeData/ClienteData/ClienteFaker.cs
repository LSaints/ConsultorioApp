using Bogus;
using Bogus.Extensions.Brazil;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.FakeData.EnderecoData;
using ConsultorioApp.FakeData.TelefoneData;

namespace ConsultorioApp.FakeData.ClienteData
{
    public class ClienteFaker : Faker<Cliente>
    {
        public ClienteFaker()
        {
            var id = new Faker().Random.Number(1, 999999);
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Sexo, f => f.PickRandom<Sexo>());
            RuleFor(p => p.Documento, f => f.Person.Cpf());
            RuleFor(p => p.Criacao, f => f.Date.Past());
            RuleFor(p => p.Telefones, f => new TelefoneFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new EnderecoFaker().Generate());
        }
    }
}
