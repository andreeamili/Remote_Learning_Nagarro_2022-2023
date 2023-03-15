using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.Terra;

namespace iQuest.TerraPlus
{
    public class ContinentPlus 
    {
        private readonly List<Country> countries = new List<Country>();

        public ContinentPlus()
        {
        }

        public ContinentPlus(IEnumerable<Country> countries)
        {
            if (countries == null) throw new ArgumentNullException(nameof(countries));

            this.countries.AddRange(countries);
        }

        public IEnumerable<Country> EnumerateCountriesByName()
        {
            countries.Sort();
            return countries;
        }

        public IEnumerable<Country> EnumerateCountriesByCapital()
        {
            return countries.OrderBy(c => c?.Capital, StringComparer.OrdinalIgnoreCase);
        }
    }
}

