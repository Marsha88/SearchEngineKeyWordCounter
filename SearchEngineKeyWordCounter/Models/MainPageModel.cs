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
