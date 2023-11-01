using NetDevPack.Domain;

namespace CloudSuite.Domain.ValueObjects
{
    public class Cnpj : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}