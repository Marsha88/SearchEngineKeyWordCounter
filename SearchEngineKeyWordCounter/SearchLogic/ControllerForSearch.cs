using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchEngineKeyWordCounter.SearchLogic
{
    public class ControllerForSearch : IControllerForSearch
    {

        private readonly IGetDataClass getDataClass;

        public ControllerForSearch(IGetDataClass getDataClass)
        {
            this.getDataClass = getDataClass;
        }

        public string MainLogic(string keyWords, string searchEngine, string matchUrl)
        {
            matchUrl = this.CheckUrl(matchUrl);
            searchEngine = this.CheckUrl(searchEngine);
            return string.Format("The count of {0}, in search engine {1} is : {2}", matchUrl, searchEngine, getDataClass.fetchSearchResultsandProcess(searchEngine, keyWords, matchUrl));
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
            return "https://" + matchUrl;
        }
    }
}
