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
            var testKeyWords = "https://www.gov.uk";
            var testSearchEngine = "www.gooogle.com";
            var testSearchWord = "www.TestSearchWord.com";
            var mockWebClientHelper = new Mock<IWebClientHelper>();
            mockWebClientHelper.Setup(m => m.returnWebClientResource(It.IsAny<string>())).Returns(System.IO.File.ReadAllText("Test Data/TestData - 1 match.txt"));

            var testGetDataClass = new GetDataClass(mockWebClientHelper.Object);

            //Act
            var testCount = testGetDataClass.fetchSearchResultsandProcess(testSearchEngine, testSearchWord, testKeyWords);

            //Assert 
            testCount.Should().Be("3");



        }
    }
}
