using LAUNCHCODE_Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAUNCHCODE_Search4Support.ViewModels
{
    public class ServiceDetailViewModel
    {
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string CategoryName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public ServiceDetailViewModel(Service theService)
        {
            Name = theService.Name;
            ProviderName = theService.Provider.Name;
            CategoryName = theService.Category.Name;
            Location = theService.Provider.Location;
            Description = theService.Description;
        }
    }
}
