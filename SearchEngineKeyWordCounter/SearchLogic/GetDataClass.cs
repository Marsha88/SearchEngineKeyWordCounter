// Decompiled with JetBrains decompiler
// Type: SearchEngineKeyWordCounter.SearchLogic.GetDataClass
// Assembly: SearchEngineKeyWordCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E9D6ED4-F37D-45A7-8FCF-62098EDA6852
// Assembly location: C:\Users\tobst\source\repos\New folder\SearchEngineKeyWordCounter.dll

using System.Net;
using System.Text.RegularExpressions;

namespace SearchEngineKeyWordCounter.SearchLogic
{
  public class GetDataClass
  {
    private const string regExToExtract = "url\\?q=(https?:\\/\\/[^#?\\/]+)";

    public string fetchSearchResultsandProcess(string requestURL, string matchUrl)
    {
      return this.calculateCount(new WebClient().DownloadString(requestURL), matchUrl);
    }

    private string calculateCount(string text, string matchUrl)
    {
      MatchCollection matchCollection = Regex.Matches(text, "url\\?q=(https?:\\/\\/[^#?\\/]+)");
      int num = 0;
      foreach (Match match in matchCollection)
      {
        if (matchUrl == match.Groups[1].Value)
          ++num;
      }
      return num.ToString();
    }
  }
}
