using NetDevPack.Domain;

namespace CloudSuite.Domain.ValueObjects
{
    public class Customer : ValueObject
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
        
    }
}