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
    }

    public class CitiesSearchProvider
    {
        public List<string> Search(string inputText)
        {
            return new List<string>();
        }
    }
}