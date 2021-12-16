using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAUNCHCODE_Search4Support.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Provider()
        {
        }
        public Provider(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public override bool Equals(object obj)
        {
            return obj is Provider provider &&
                   Id == provider.Id &&
                   Name == provider.Name &&
                   Location == provider.Location;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Location);
        }
    }
}
