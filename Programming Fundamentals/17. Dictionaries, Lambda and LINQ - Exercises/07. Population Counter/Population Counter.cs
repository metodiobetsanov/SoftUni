namespace _07.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var countryPopulation = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var token = Console.ReadLine().Split('|').ToList();

                if (token[0] == "report")
                {
                    break;
                }

                var country = token[1];
                var city = token[0];
                var population = long.Parse(token[2]);

                if (!countryPopulation.ContainsKey(country))
                {
                    countryPopulation[country] = new Dictionary<string, long>();
                }

                if (!countryPopulation[country].ContainsKey(city))
                {
                    countryPopulation[country][city] = 0;
                }

                countryPopulation[country][city] += population;
            }

            var orderedCountries = countryPopulation.OrderByDescending(c => c.Value.Values.Sum());

            foreach (var country in orderedCountries)
            {
                var nat = country.Key;
                var cityPopulation = country.Value;
                var totalPopulation = cityPopulation.Sum(x => x.Value);
                var orderedCities = country.Value.OrderByDescending(c => c.Value);

                Console.WriteLine($"{nat} (total population: {totalPopulation})");

                foreach (var city in orderedCities)
                {
                    var town = city.Key;
                    var population = city.Value;

                    Console.WriteLine($"=>{town}: {population}");
                }
            }
        }
    }
}
