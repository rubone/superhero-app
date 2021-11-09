using SuperHeroApp.Models;
using Xunit;

namespace SuperHeroApp.Tests
{
    public class SearchViewModelTest
    {
        [Fact]
        public void FilterShouldBeEqualToSearchViewModelFilter()
        {
            //Arrange
            var filter = "batman";

            //Act
            SearchViewModel searchViewModel = new SearchViewModel
            {
                Filter = "batman",
                SearchResult = null,
            };
            
            //Assert
            Assert.Equal(filter, searchViewModel.Filter);
        }

    }
}
