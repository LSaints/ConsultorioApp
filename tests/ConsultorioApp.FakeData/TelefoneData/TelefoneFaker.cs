using Bogus;
using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.FakeData.TelefoneData
{
    public class TelefoneFaker : Faker<Telefone>
    {
        public TelefoneFaker()
        {
            RuleFor(p => p.ClienteId, f => f.Random.Number(1, 10));
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
