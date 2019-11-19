/// <summary>
/// Model for the main page.
/// </summary>
namespace SearchEngineKeyWordCounter.Models
{
    /// <summary>
    /// Model for the main page.
    /// </summary>
    public class MainPageModel
  {

    /// <summary>
    /// Key Words to search in the search engine.
    /// </summary>
    public string SearchKeyWords { get; set; }

    /// <summary>
    /// The search engine to use, only allows for google right now but would like to expand.
    /// </summary>    
    public string SearchEngine { get; set; } = "www.google.co.uk";

    /// <summary>
    /// What url to look up in the results..
    /// </summary>  
    public string SearchURL { get; set; }

    /// <summary>
    /// The Output message.
    /// </summary>
    public string OutPutMessage { get; set; } = "Your result will display here";
  }
}
