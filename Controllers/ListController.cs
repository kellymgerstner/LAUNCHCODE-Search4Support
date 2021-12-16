using LAUNCHCODE_Search4Support.Data;
using LAUNCHCODE_Search4Support.Models;
using LAUNCHCODE_Search4Support.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAUNCHCODE_Search4Support.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All" },
            {"provider", "Provider" },
            {"category", "Category"},
            {"location", "Location" }
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "provider",
            "category",
            "location"
        };

        private ServiceDbContext context;

        public ListController(ServiceDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.providers = context.Providers.ToList();
            ViewBag.services = context.Services.ToList();
            ViewBag.categories = context.Categories.ToList();
            return View();
        }

        public IActionResult Services(string column, string value)
        {
            List<Service> services;
            List<ServiceListViewModel> displayServices = new List<ServiceListViewModel>();

            if (column.ToLower().Equals("all"))
            {
                services = context.Services
                    .Include(s => s.Name)
                    .ToList();

                ViewBag.title = "All Services";
            }
            else
            {
                if (column == "provider")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Name == value)
                        .ToList();

                    foreach (Service srv in services)
                    {
                        ServiceListViewModel newDisplayService = new ServiceListViewModel(srv);
                        displayServices.Add(newDisplayService);
                    }
                }

                else if (column == "category")
                {
                    services = context.Services
                        .Include(s => s.Category)
                        .Where(s => s.Category.Name == value)
                        .ToList();

                    foreach (Service srv in services)
                    {
                        ServiceListViewModel newDisplayService = new ServiceListViewModel(srv);
                        displayServices.Add(newDisplayService);
                    }
                }

                else if (column == "location")
                {
                    services = context.Services
                        .Include(s => s.Provider.Location)
                        .Where(s => s.Provider.Location == value)
                        .ToList();

                    foreach (Service srv in services)
                    {
                        ServiceListViewModel newDisplayService = new ServiceListViewModel(srv);
                        displayServices.Add(newDisplayService);
                    }
                }

                ViewBag.title = "Services with " + ColumnChoices[column] + ": " + value;
            }
            ViewBag.services = displayServices;

            return View();
        }
    }
}
