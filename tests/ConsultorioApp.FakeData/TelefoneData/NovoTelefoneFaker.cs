using Bogus;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.FakeData.TelefoneData
{
    public class NovoTelefoneFaker : Faker<NovoTelefone>
    {
        public NovoTelefoneFaker()
        {
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
