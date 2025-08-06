using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Shared.Domain;

namespace ProperTea.Company.Domain.Company
{
    public class Company : AggregateRootBase, IAggregateRoot
    {
        public const int MaxNameLength = 200;
        public const int MinNameLength = 1;
    
        private string _name = null!;
        public string Name 
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Company.NameRequired");

                _name = value.Length switch
                {
                    > MaxNameLength => throw new Exception("Company.NameTooLong"),
                    < MinNameLength => throw new Exception("Company.NameTooShort"),
                    _ => value
                };
            }
        }
        
        private Company()
        {
            this._name = "";
        }

        private Company(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Company Create(string name)
        {
            var company = new Company(Guid.NewGuid(), name);
            company.AddDomainEvent(new CompanyCreatedDomainEvent(company.Id, company.Name));
            return company;
        }

        public void ChangeName(string newName)
        {
            if (Name == newName) 
                return;
            
            Name = newName;
            AddDomainEvent(new CompanyNameChangedDomainEvent(Id, newName));
        }

        public bool AllowDelete()
        {
            return true;
        }
    }
}
