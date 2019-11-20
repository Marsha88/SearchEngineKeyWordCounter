using Moq;
using NUnit.Framework;
using SearchEngineKeyWordCounter.SearchLogic;
using FluentAssertions;
using System.Text.RegularExpressions;
using SearchEngineWordCount.ExternalCalls;
using SearchEngineWordCount.Logging;
using SearchEngineKeyWordUnitTests.Test_Exceptions;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SearchEngineKeyWordUnitTests
{
    public class ControllerForSearchUnitTests
    {
        private const string TestKeyWords = "Test Key Words";
        private const  string TestSearchEngine = "www.gooogle.com";
        private const  string TestSearchWord = "www.TestSearchWord.com";
        private const  string TestCount = "3";


        [Test]
        public void GivenAValidKeyWordSearchEngineAndUrlWithOutHttpOrHttps_WhenMainLogicIsCalled_ThenShouldReturnTheCountOfTheSearchInTheCorrectFormat()
        {
            //Arrange
            var testOutput = string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + TestSearchWord, "https://" + TestSearchEngine, TestCount);
            var mockedGetDataClass = new Mock<IGetDataClass>();
            var mockedILogOutToFile = new Mock<ILogOutToFile>();
            var mockedIWebClientHelper = new Mock<WebClientHelper>();

            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl("https://" + TestSearchEngine), TestKeyWords, CheckUrl("https://" + TestSearchWord))).Returns(TestCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object, mockedIWebClientHelper.Object, mockedILogOutToFile.Object);

            //Act 
            var testResult = testController.MainLogic(TestKeyWords,TestSearchEngine,TestSearchWord);

            //Assert 
            testResult.Should().Be(testOutput);

        }

        [Test]
        public void GivenAValidKeyWordSearchEngineAndUrlWithHttp_WhenMainLogicIsCalled_ThenShouldReturnTheCountOfTheSearchInTheCorrectFormat()
        {
            //Arrange
            var transportType = "http://";
            var testOutput = string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + TestSearchWord, "https://" + TestSearchEngine, TestCount);
            var mockedGetDataClass = new Mock<IGetDataClass>();
            var mockedILogOutToFile = new Mock<ILogOutToFile>();
            var mockedIWebClientHelper = new Mock<WebClientHelper>();

            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl(transportType + TestSearchEngine), TestKeyWords, CheckUrl(transportType + TestSearchWord))).Returns(TestCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object, mockedIWebClientHelper.Object, mockedILogOutToFile.Object);

            //Act 
            var testResult = testController.MainLogic(TestKeyWords, TestSearchEngine, TestSearchWord);

            //Assert 
            testResult.Should().Be(testOutput);

        }

        [Test]
        public void GivenAValidKeyWordSearchEngineAndUrlWithHttps_WhenMainLogicIsCalled_ThenShouldReturnTheCountOfTheSearchInTheCorrectFormat()
        {
            //Arrange
            var transportType = "https://";
            var testOutput = string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + TestSearchWord, "https://" + TestSearchEngine, TestCount);
            var mockedGetDataClass = new Mock<IGetDataClass>();
            var mockedILogOutToFile = new Mock<ILogOutToFile>();
            var mockedIWebClientHelper = new Mock<WebClientHelper>();

            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl(transportType + TestSearchEngine), TestKeyWords, CheckUrl(transportType + TestSearchWord))).Returns(TestCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object, mockedIWebClientHelper.Object, mockedILogOutToFile.Object);

            //Act 
            var testResult = testController.MainLogic(TestKeyWords, TestSearchEngine, TestSearchWord);

            //Assert 
            testResult.Should().Be(testOutput);

        }

        [Test]
        public void GivenAnExceptionInFetchSearchResultsAndProcess_WhenMainLogicCompletes_ThenShouldOutPutTheResultIntoLog()
        {
            //Arrange
            var transportType = "https://";
            var exceptionString = "Test Exception";
            var mockedGetDataClass = new Mock<IGetDataClass>();
            var mockedILogOutToFile = new Mock<ILogOutToFile>();
            var mockedIWebClientHelper = new Mock<IWebClientHelper>();

            var currentTime = DateTime.Now;
            var test = ConfigurationManager.AppSettings["NumberOfPages"];
            var writeLocation = string.Format("{0}\\LogFiles\\{1}{2}", "C:\\Temp", currentTime.Year, currentTime.DayOfYear);

            var fileTestPre = File.ReadLines(writeLocation + "\\Exception Log.txt").Where(m => m.Contains("Test Exception"));
            var preCount = fileTestPre.Count();

            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl(transportType + TestSearchEngine), TestKeyWords, CheckUrl(transportType + TestSearchWord))).Throws(new TestException(exceptionString));
            var testController = new ControllerForSearch(mockedGetDataClass.Object, mockedIWebClientHelper.Object, new LogOutToFile());

            //Act 
            var testResult = testController.MainLogic(TestKeyWords, TestSearchEngine, TestSearchWord);

            //Assert 
            testResult.Should().Be(string.Format("An Exception Has occured While Operating, Exception was : {0} please see the log for more detail",exceptionString));

            //TODO Cleanup test data. 
            var fileTestPost = File.ReadLines(writeLocation + "\\Exception Log.txt").Where(m => m.Contains("Test Exception"));
            var postCount = fileTestPost.Count();
            postCount.Should().Be(preCount + 1);

        }

        [Test]
        public void GivenAnSuccessFulRun_WhenMainLogicCompletes_ThenShouldOutPutTheResultIntoLog()
        {
            //Arrange
            var transportType = "https://";
            var exceptionString = "Test Exception";
            var testOutput = string.Format("The count of {0}, in search engine {1} is : {2}", "https://" + TestSearchWord, "https://" + TestSearchEngine, TestCount);
            var mockedGetDataClass = new Mock<IGetDataClass>();
            var mockedILogOutToFile = new Mock<ILogOutToFile>();
            var mockedIWebClientHelper = new Mock<IWebClientHelper>();

            var currentTime = DateTime.Now;
            var test = ConfigurationManager.AppSettings["NumberOfPages"];
            var writeLocation = string.Format("{0}\\LogFiles\\{1}{2}", "C:\\Temp", currentTime.Year, currentTime.DayOfYear);

            var fileTestPre = File.ReadLines(writeLocation + "\\Output Log.txt").Where(m => m.Contains(testOutput));
            var preCount = fileTestPre.Count();

            mockedGetDataClass.Setup(m => m.fetchSearchResultsandProcess(CheckUrl(transportType + TestSearchEngine), TestKeyWords, CheckUrl(transportType + TestSearchWord))).Returns(TestCount);
            var testController = new ControllerForSearch(mockedGetDataClass.Object, mockedIWebClientHelper.Object, new LogOutToFile());

            //Act 
            var testResult = testController.MainLogic(TestKeyWords, TestSearchEngine, TestSearchWord);

            //Assert 
            testResult.Should().Be(testOutput);

            //TODO Cleanup test data.
            var fileTestPost = File.ReadLines(writeLocation + "\\Output Log.txt").Where(m => m.Contains(testOutput));
            var postCount = fileTestPost.Count();
            postCount.Should().Be(preCount + 1);

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