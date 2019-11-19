using Moq;
using NUnit.Framework;
using SearchEngineKeyWordCounter.SearchLogic;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAValidKeyWordSearchEngineAndUrlWithOutHttpOrHttps_WhenMainLogicIsCalled_ThenShouldReturnTheCountOfTheSearchInTheCorrectFormat()
        {
            //Arrange
            var testKeyWords = "Test Key Words";
            var testSearchEngine = "www.gooogle.com";
            var testSearchWord = "www.TestSearchWord.com";
            var testCount = "3";
            var mockedGetDataClass = new Mock<IGetDataClass>();
            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess( CheckUrl(testSearchEngine), testKeyWords, CheckUrl(testSearchWord))).Returns(testCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object);

            //Act 
            var testResult = testController.MainLogic(testKeyWords,testSearchEngine,testSearchWord);

            //Assert 
            testResult.Should().Be(string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + testSearchWord, "https://" + testSearchEngine, testCount));

        }

        [Test]
        public void GivenAValidKeyWordSearchEngineAndUrlWithHttp_WhenMainLogicIsCalled_ThenShouldReturnTheCountOfTheSearchInTheCorrectFormat()
        {
            //Arrange
            var testKeyWords = "Test Key Words";
            var testSearchEngine = "www.gooogle.com";
            var testSearchWord = "www.TestSearchWord.com";
            var testCount = "3";
            var transportType = "http://";
            var mockedGetDataClass = new Mock<IGetDataClass>();
            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl(transportType + testSearchEngine), testKeyWords, CheckUrl(transportType + testSearchWord))).Returns(testCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object);

            //Act 
            var testResult = testController.MainLogic(testKeyWords, testSearchEngine, testSearchWord);

            //Assert 
            testResult.Should().Be(string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + testSearchWord, "https://" + testSearchEngine, testCount));

        }

        [Test]
        public void GivenAValidKeyWordSearchEngineAndUrlWithHttps_WhenMainLogicIsCalled_ThenShouldReturnTheCountOfTheSearchInTheCorrectFormat()
        {
            //Arrange
            var testKeyWords = "Test Key Words";
            var testSearchEngine = "www.gooogle.com";
            var testSearchWord = "www.TestSearchWord.com";
            var testCount = "3";
            var transportType = "https://";
            var mockedGetDataClass = new Mock<IGetDataClass>();
            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl(transportType + testSearchEngine), testKeyWords, CheckUrl(transportType + testSearchWord))).Returns(testCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object);

            //Act 
            var testResult = testController.MainLogic(testKeyWords, testSearchEngine, testSearchWord);

            //Assert 
            testResult.Should().Be(string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + testSearchWord, "https://" + testSearchEngine, testCount));

        }
        private string CheckUrl(string matchUrl)
        {
            matchUrl = Regex.Replace(matchUrl, @"\s+", "");
            if (matchUrl.Contains("https"))
                return matchUrl;
            if (matchUrl.Contains("http"))
            {
                 matchUrl = matchUrl.Replace("http", "https");
                return matchUrl;
            }
            return  "https://" + matchUrl;
        }
    }
}