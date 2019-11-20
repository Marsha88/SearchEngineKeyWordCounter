using FluentAssertions;
using Moq;
using NUnit.Framework;
using SearchEngineKeyWordCounter.SearchLogic;
using SearchEngineWordCount.ExternalCalls;

namespace SearchEngineKeyWordUnitTests
{
    class GetDataClassUnitTests
    {

        [Test]
        public void GivenAValidUrl_WhenfetchSearchResultsandProcessIsRan_ThenItShouldReturnTheCorrectCount()
        {
            //Arrange
            var testSearchWord = "https://www.gov.uk";
            var testSearchEngine = "www.gooogle.com";
            var testKeyWords = "TestSearchWord";

            var mockWebClientHelper = new Mock<IWebClientHelper>();
            mockWebClientHelper.Setup(m => m.returnWebClientResource(It.IsAny<string>())).Returns(System.IO.File.ReadAllText("Test Data/TestData - 1 match.txt"));

            var testGetDataClass = new GetDataClass(mockWebClientHelper.Object);

            //Act
            var testCount = testGetDataClass.fetchSearchResultsandProcess(testSearchEngine, testKeyWords, testSearchWord);

            //Assert 
            testCount.Should().Be("3");



        }

        [Test]
        public void GivenAKeyWordWithLotsOfSpecialCharacters_WhenfetchSearchResultsandProcessIsRan_ThenItShouldStillReturnTheCorrectCountAndNoExceptionThrown()
        {
            //Arrange
            var testSearchWord = "https://www.gov.uk";
            var testKeyWords = "@+!£$%^     &* () ' '";
            var testSearchEngine = "www.google.com";

            var mockWebClientHelper = new Mock<IWebClientHelper>();
            mockWebClientHelper.Setup(m => m.returnWebClientResource(testSearchEngine+ "/search?num=100&q=@+!£$%^+&*+()+'+'")).Returns(System.IO.File.ReadAllText("Test Data/TestData - 1 match.txt"));

            var testGetDataClass = new GetDataClass(mockWebClientHelper.Object);

            //Act
            var testCount = testGetDataClass.fetchSearchResultsandProcess(testSearchEngine, testKeyWords, testSearchWord);

            //Assert 
            testCount.Should().Be("3");



        }
    }
}
