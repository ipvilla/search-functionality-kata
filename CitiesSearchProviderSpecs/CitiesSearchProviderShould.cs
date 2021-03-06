using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CitiesSearchProviderSpecs
{
    public class CitiesSearchProviderShould
    {
        private CitiesSearchProvider citiesSearchProvider;

        [SetUp]
        public void SetUp()
        {
            citiesSearchProvider = new CitiesSearchProvider();
        }

        [Test]
        public void return_no_results_if_input_text_has_less_than_2_characters()
        {
            const string inputTextWithOnlyOneCharacter = "a";

            var results = citiesSearchProvider.Search(inputTextWithOnlyOneCharacter);

            Assert.IsTrue(!results.Any());
        }

        [Test]
        public void return_Valencia_and_Vancouver_when_input_text_is_Va()
        {
            const string inputTextWithTwoCharacters = "Va";

            var results = citiesSearchProvider.Search(inputTextWithTwoCharacters);

            Assert.IsTrue(results.Contains("Valencia"));
            Assert.IsTrue(results.Contains("Vancouver"));
        }

        [Test]
        public void return_Rotterdam_and_Rome_when_input_text_is_Ro()
        {
            const string inputTextWithTwoCharacters = "Ro";

            var results = citiesSearchProvider.Search(inputTextWithTwoCharacters);

            Assert.IsTrue(results.Contains("Rotterdam"));
            Assert.IsTrue(results.Contains("Rome"));
        }

        [Test]
        public void return_results_being_case_insensitive()
        {
            const string inputTextInLowerCase = "va";

            var results = citiesSearchProvider.Search(inputTextInLowerCase);

            Assert.IsTrue(results.Contains("Valencia"));
            Assert.IsTrue(results.Contains("Vancouver"));
        }

        [Test]
        public void return_results_that_contain_the_input_text_in_any_position_of_the_city_name()
        {
            const string inputText = "ape";

            var results = citiesSearchProvider.Search(inputText);

            Assert.IsTrue(results.Contains("Budapest"));
        }

        [Test]
        public void return_all_results_when_input_text_is_an_asterisk()
        {
            var expectedCityNames = new List<string>
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
            const string inputText = "*";

            var results = citiesSearchProvider.Search(inputText);

            Assert.AreEqual(expectedCityNames, results);
        }
    }

    public class CitiesSearchProvider
    {
        private readonly List<string> CityNames = new List<string>
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
            if (inputText.Equals("*"))
            {
                return CityNames;
            }
            if (inputText.Length < 2)
            {
                return new List<string>();
            }

            return CityNames.Where(x => x.Contains(inputText, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
    }
}