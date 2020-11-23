using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
        public string GetCountryName(string code);
        void AddCountry(Country country);
        public Country GetCountry(string code);
    }

}
