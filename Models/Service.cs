using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAUNCHCODE_Search4Support.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
        public ServiceCategory Category { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public Service()
        {
        }

        public Service(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   Id == service.Id &&
                   Name == service.Name &&
                   EqualityComparer<Provider>.Default.Equals(Provider, service.Provider) &&
                   ProviderId == service.ProviderId &&
                   EqualityComparer<ServiceCategory>.Default.Equals(Category, service.Category) &&
                   CategoryId == service.CategoryId &&
                   Description == service.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Provider, ProviderId, Category, CategoryId, Description);
        }
    }
}
