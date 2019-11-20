using SearchEngineWordCount.ExternalCalls;
using SearchEngineWordCount.Unity;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

/// <summary>
/// Gets and process data class.
/// </summary>
namespace SearchEngineKeyWordCounter.SearchLogic
{
    /// <summary>
    /// Gets and process data class.
    /// </summary>
    public class GetDataClass : IGetDataClass
    {
        /// <summary>
        /// Extract regex to get only the urls.
        /// </summary>
        private  string regExToExtract = ConfigurationManager.AppSettings["regExToExtract"]?? "url\\?q=(https?:\\/\\/[^#?\\/]+)";

        /// <summary>
        /// Number of pages to search.
        /// </summary>
        private  string NumberOfPages = ConfigurationManager.AppSettings["NumberOfPages"]??"100";

        /// <summary>
        /// The WebClient that is injected.
        /// </summary>
        private readonly IWebClientHelper webClient;

        /// <summary>
        /// The injector for unity.
        /// </summary>
        /// <param name="webClient"></param>
        public GetDataClass(IWebClientHelper webClient)
        {
            this.webClient = webClient;
        }

        /// <summary>
        /// The main controller for fetching the results from a search engine and processes them. 
        /// </summary>
        /// <param name="searchEngine">The search engine.</param>
        /// <param name="KeyWords">The key words to search on.</param>
        /// <param name="matchUrl">What url to look for.</param>
        /// <returns> The count (as a string) of the matchUrl.</returns>
        public string fetchSearchResultsandProcess(string searchEngine,string KeyWords, string matchUrl)
        {
            var urlConstructed = UrlConstructor(searchEngine, KeyWords);

            return this.calculateCount(webClient.returnWebClientResource(urlConstructed), matchUrl);
        }

        /// <summary>
        /// Go through the text and find where it matches the matchurl. TODO make more robust.
        /// </summary>
        /// <param name="text">The text gathered from the search. Raw HTML in string form.</param>
        /// <param name="matchUrl">The url to match on.</param>
        /// <returns>The count of the url in the text.</returns>
        private string calculateCount(string text, string matchUrl)
        {
            MatchCollection matchCollection = Regex.Matches(text, regExToExtract);
            int num = 0;
            foreach (Match match in matchCollection)
            {
                if (matchUrl == match.Groups[1].Value)
                    ++num;
            }
            return num.ToString();
        }

        /// <summary>
        /// Turns the searcheninge into one with the page count and key words.
        /// </summary>
        /// <param name="searchEngine">The search engine.</param>
        /// <param name="constructedKeyWords">the key words to search.</param>
        /// <returns></returns>
        private string UrlConstructor(string searchEngine, string constructedKeyWords)
        {
            return searchEngine + "/search?num=" + NumberOfPages + "&q=" + KeyWordToUrlConstructor(constructedKeyWords);
        }

        /// <summary>
        /// Removes all the bits off the keywords that will not make a valid url.
        /// </summary>
        /// <param name="keyWords">The key words.</param>
        /// <returns>key words with whitespaces removed.</returns>
        private string KeyWordToUrlConstructor(string keyWords)
        {

            var regExRemoveWhiteSpace = new Regex(@"\s+");
            keyWords = regExRemoveWhiteSpace.Replace(keyWords, "+");

            return keyWords;
        }
    }
}
