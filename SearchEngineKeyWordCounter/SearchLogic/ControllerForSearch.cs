using SearchEngineWordCount.ExternalCalls;
using SearchEngineWordCount.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// The controller for the applications backend logic.
/// </summary>
namespace SearchEngineKeyWordCounter.SearchLogic
{
    /// <summary>
    /// The controller for the applications backend logic.
    /// </summary>
    public class ControllerForSearch : IControllerForSearch
    {

        /// <summary>
        /// These are Interfaces injected by unity.
        /// </summary>
        private readonly IGetDataClass getDataClass;
        private readonly IWebClientHelper webClient;
        private readonly ILogOutToFile logOutToFile;

        //The Unity injector.
        public ControllerForSearch(IGetDataClass getDataClass, IWebClientHelper webClient, ILogOutToFile logOutToFile)
        {
            this.getDataClass = getDataClass;
            this.webClient = webClient;
            this.logOutToFile = logOutToFile;
        }

        /// <summary>
        /// The main run logic for the back end
        /// </summary>
        /// <param name="keyWords">The key words to search in teh search engine.</param>
        /// <param name="searchEngine">The search Engine.</param>
        /// <param name="matchUrl">What url to find in the results.</param>
        /// <returns>An output message.</returns>
        public string MainLogic(string keyWords, string searchEngine, string matchUrl)
        {
            try
            {
                matchUrl = this.CheckUrl(matchUrl);
                searchEngine = this.CheckUrl(searchEngine);
                var countString = string.Format("The count of {0}, in search engine {1} is : {2}", matchUrl, searchEngine, getDataClass.fetchSearchResultsandProcess(searchEngine, keyWords, matchUrl));
                logOutToFile.WriteToFile(countString, "Output Log");
                return countString;
            }
            catch (Exception e)
            {
                var exceptionString = string.Format("An Exception Has occured While Operating, Exception was : {0}", e.Message);
                logOutToFile.WriteToFile(exceptionString+e, "Exception Log");
                return exceptionString + " please see the log for more detail";
            }
        }

        /// <summary>
        /// Checks the URL is https form. TODO: need some more robust checking.
        /// </summary>
        /// <param name="matchUrl">The url to check.</param>
        /// <returns>A url with https:// in it.</returns>
        private string CheckUrl(string matchUrl)
        {
            // make sure there are no white spaces first.
            matchUrl = Regex.Replace(matchUrl, @"\s+", "");

            if (matchUrl.Contains("https"))
                return matchUrl;

            if (matchUrl.Contains("http"))
            {
                matchUrl = matchUrl.Replace("http", "https");
                return matchUrl;
            }
            return "https://" + matchUrl;
        }
    }
}
