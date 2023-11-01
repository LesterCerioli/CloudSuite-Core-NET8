using NetDevPack.Domain;

namespace CloudSuite.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}