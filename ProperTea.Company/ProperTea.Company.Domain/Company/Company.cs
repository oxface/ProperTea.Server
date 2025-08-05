using System;
using System.Collections.Generic;

using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Domain.Company
{
    public class Company : AggregateRootBase, IAggregateRoot
    {
        public const int MaxNameLength = 200;
        public const int MinNameLength = 1;
    
        private string _name;
        public string Name 
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Company.NameRequired");
                
                if (value.Length > MaxNameLength)
                    throw new Exception("Company.NameTooLong");
                
                if (value.Length < MinNameLength)
                    throw new Exception("Company.NameTooShort");
                
                _name = value;
            }
        }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private Company()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
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
            if (Name != newName)
            {
                Name = newName;
                AddDomainEvent(new CompanyNameChangedDomainEvent(Id, newName));
            }
        }

        public bool AllowDelete()
        {
            return true;
        }
    }
}
