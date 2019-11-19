// Decompiled with JetBrains decompiler
// Type: SearchEngineKeyWordCounter.SearchLogic.MainEntryLogicForSearch
// Assembly: SearchEngineKeyWordCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E9D6ED4-F37D-45A7-8FCF-62098EDA6852
// Assembly location: C:\Users\tobst\source\repos\New folder\SearchEngineKeyWordCounter.dll

using System.Collections.Generic;
using System.Linq;

namespace SearchEngineKeyWordCounter.SearchLogic
{
  public class MainEntryLogicForSearch
  {
    private GetDataClass getDataFromSearchEngine = new GetDataClass();
    private const string NumberOfPages = "100";

    public string MainLogic(string keyWords, string searchEngine, string searchWord)
    {
      string urlConstructor = this.KeyWordToUrlConstructor(keyWords);
      string requestURL = this.UrlConstructor(searchEngine, urlConstructor);
      searchWord = this.CheckSearchWord(searchWord);
      return string.Format("The count of {0}, in search engine {1} is : {2}", (object) searchWord, (object) searchEngine, (object) this.getDataFromSearchEngine.fetchSearchResultsandProcess(requestURL, searchWord));
    }

    private string UrlConstructor(string searchEngine, string constructedKeyWords)
    {
      return "https://" + searchEngine + "/search?num=100&q=" + constructedKeyWords;
    }

    private string KeyWordToUrlConstructor(string keyWords)
    {
      List<string> stringList = new List<string>();
      string str = "";
      foreach (char keyWord in keyWords)
      {
        if (!char.IsWhiteSpace(keyWord) && (int) keyWord != (int) keyWords.Last<char>())
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
          if (stringList.LastIndexOf("+") != stringList.Count - 1 && (uint) stringList.Count > 0U)
            stringList.Add("+");
        }
      }
      return string.Join("", (IEnumerable<string>) stringList);
    }

    private string CheckSearchWord(string searchWord)
    {
      if (searchWord.Contains("Https") || searchWord.Contains("Http"))
        return searchWord;
      return searchWord = "https://" + searchWord;
    }
  }
}
