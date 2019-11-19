// Decompiled with JetBrains decompiler
// Type: SearchEngineKeyWordCounter.Models.MainPageModel
// Assembly: SearchEngineKeyWordCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E9D6ED4-F37D-45A7-8FCF-62098EDA6852
// Assembly location: C:\Users\tobst\source\repos\New folder\SearchEngineKeyWordCounter.dll

namespace SearchEngineKeyWordCounter.Models
{
  public class MainPageModel
  {
    public string KeyWordList { get; set; }

    public string SearchList { get; set; } = "www.google.co.uk";

    public string WordToSearchOn { get; set; }

    public string OutPutMessage { get; set; } = "Your result will display here";
  }
}
