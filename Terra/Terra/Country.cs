using System;
using System.Buffers;
using System.Collections.Generic;

namespace iQuest.Terra
{
    public class Country : IComparable, IEquatable<Country>
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }
        public bool Equals(Country obj)
        {

            if (obj == null)
            {
                return false;
            }

            if (!(obj is Country))
            {
                return false;
            }

            var person = obj as Country;

            return this.Name == person.Name && this.Capital == person.Capital;
        }

        public override bool Equals(Object obj)
        {
            return Equals(obj as Country);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode()^this.Capital.GetHashCode();
        }

        public int CompareTo(object obj)
        {
           if(obj==null)
            {
                return 1;
            }

            Country country=obj as Country;
            if (country == null)
            {
                throw new ArgumentException("This is not a country");
            }

            int result=Name.CompareTo(country.Name);
            if (result == 0)
            {
                result = Capital.CompareTo(country.Capital);
            }
            return result;
        }


    }
}