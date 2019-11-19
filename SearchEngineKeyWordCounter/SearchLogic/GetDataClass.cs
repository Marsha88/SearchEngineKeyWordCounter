using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SearchEngineKeyWordCounter.SearchLogic
{
    public class GetDataClass : IGetDataClass
    {
        private const string regExToExtract = "url\\?q=(https?:\\/\\/[^#?\\/]+)";

        private const string NumberOfPages = "100";

        public string fetchSearchResultsandProcess(string searchEngine,string KeyWords, string matchUrl)
        {
            var urlConstructed = UrlConstructor(searchEngine, KeyWords);
            return this.calculateCount(new WebClient().DownloadString(urlConstructed), matchUrl);
        }

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

        private string UrlConstructor(string searchEngine, string constructedKeyWords)
        {
            return searchEngine + "/search?num=" + NumberOfPages + "&q=" + KeyWordToUrlConstructor(constructedKeyWords);
        }

        private string KeyWordToUrlConstructor(string keyWords)
        {
            List<string> stringList = new List<string>();
            string str = "";
            foreach (char keyWord in keyWords)
            {
                if (!char.IsWhiteSpace(keyWord) && keyWord != keyWords.Last<char>())
                    str += keyWord.ToString();
                else if (!char.IsWhiteSpace(keyWord))
                {
                    str += keyWord.ToString();
                    stringList.Add(str);
                }
                else
                {
                    stringList.Add(str);
                    str = "";
                    if (stringList.LastIndexOf("+") != stringList.Count - 1 && stringList.Count > 0U)
                        stringList.Add("+");
                }
            }
            return string.Join("", stringList);
        }
    }
}
