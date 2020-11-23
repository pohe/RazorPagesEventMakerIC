using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMakerIC.Interfaces;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Services
{
    public class FakeCountryRepository : ICountryRepository
    {
        private List<Country> countries { get; }

        public FakeCountryRepository()
        {
            countries = new List<Country>();
            countries.Add(new Country() { Code = "FR", Name = "France" });
            countries.Add(new Country() { Code = "DK", Name = "Denmark" });
            countries.Add(new Country() { Code = "SP", Name = "Spain" });
        }

        public List<Country> GetAllCountries()
        {
            return countries;
        }

        public string GetCountryName(string code)
        {
            foreach (Country c in countries)
            {
                if (c.Code == code)
                {
                    return c.Name;
                }
            }

            return null;
        }

        public Country GetCountry(string code)
        {
            foreach (Country c in countries)
            {
                if (c.Code == code)
                {
                    return c;
                }
            }

            return null;
        }
        public void AddCountry(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
