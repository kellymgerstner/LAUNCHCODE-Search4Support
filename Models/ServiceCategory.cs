using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAUNCHCODE_Search4Support.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Service> Services { get; set; }


        public ServiceCategory()
        {
        }

        public ServiceCategory(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is ServiceCategory category &&
                   Id == category.Id &&
                   Name == category.Name &&
                   EqualityComparer<List<Service>>.Default.Equals(Services, category.Services);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Services);
        }
    }
}
