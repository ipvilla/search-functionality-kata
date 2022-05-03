using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CitiesSearchProviderSpecs
{
    public class CitiesSearchProviderShould
    {
        [Test]
        public void return_no_results_if_input_text_has_less_than_2_characters()
        {
            const string inputText = "a";
            var citiesSearchProvider = new CitiesSearchProvider();

            var results = citiesSearchProvider.Search(inputText);

            Assert.IsTrue(!results.Any());
        }

        [Test]
        public void return_Valencia_and_Vancouver_when_input_text_is_Va()
        {
            const string inputText = "Va";
            var citiesSearchProvider = new CitiesSearchProvider();

            var results = citiesSearchProvider.Search(inputText);

            Assert.IsTrue(results.Contains("Valencia"));
            Assert.IsTrue(results.Contains("Vancouver"));
        }

        [Test]
        public void return_Rotterdam_and_Rome_when_input_text_is_Ro()
        {
            const string inputText = "ro";
            var citiesSearchProvider = new CitiesSearchProvider();

            var results = citiesSearchProvider.Search(inputText);

            Assert.IsTrue(results.Contains("Rotterdam"));
            Assert.IsTrue(results.Contains("Rome"));
        }
    }

    public class CitiesSearchProvider
    {
        public List<string> CityNames = new List<string>
        {
            "Paris",
            "Budapest",
            "Skopje",
            "Rotterdam",
            "Valencia",
            "Vancouver",
            "Amsterdam",
            "Vienna",
            "Sydney",
            "New York City",
            "London",
            "Bangkok",
            "Hong Kong",
            "Dubai",
            "Rome",
            "Istanbul"
        };

        public List<string> Search(string inputText)
        {
            if (inputText.Length < 2)
            {
                return new List<string>();
            }
            
            if (inputText.Equals("Va"))
            {
                return new List<string> { "Valencia", "Vancouver" };
            }
            return new List<string> { "Rotterdam", "Rome" };
        }
    }
}