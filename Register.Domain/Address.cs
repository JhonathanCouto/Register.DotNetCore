using DotNetCore.Domain;

namespace Register.Domain
{
    public sealed class Address : Entity
    {
        public Address
        (
            string street, 
            string number,
            string city, 
            string state, 
            string zipCode
        )
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public Address(long id) => Id = id;

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string ZipCode { get; private set; }

        public void UpdateStreet(string street) => Street = street;

        public void UpdateNumber(string number) => Number = number;

        public void UpdateCity(string city) => City = city;

        public void UpdateState(string state) => State = state;

        public void UpdateZipCode(string zipCode) => ZipCode = zipCode;
    }
}
