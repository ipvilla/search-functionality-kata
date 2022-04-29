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
    }

    public class CitiesSearchProvider
    {
        public List<string> Search(string inputText)
        {
            throw new System.NotImplementedException();
        }
    }
}