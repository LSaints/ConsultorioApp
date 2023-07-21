using Bogus;
using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.FakeData.TelefoneData
{
    public class TelefoneFaker : Faker<Telefone>
    {
        public TelefoneFaker(int id)
        {
            RuleFor(p => p.ClienteId, _ => id);
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
