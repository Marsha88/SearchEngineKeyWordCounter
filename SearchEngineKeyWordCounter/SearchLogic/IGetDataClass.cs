    /// <summary>
    /// Gets and process data class.
    /// </summary>
namespace SearchEngineKeyWordCounter.SearchLogic
{
    /// <summary>
    /// Gets and process data class.
    /// </summary>
    public interface IGetDataClass 
    {
        /// <summary>
        /// The main controller for fetching the results from a search engine and processes them. 
        /// </summary>
        /// <param name="searchEngine">The search engine.</param>
        /// <param name="KeyWords">The key words to search on.</param>
        /// <param name="matchUrl">What url to look for.</param>
        /// <returns> The count (as a string) of the matchUrl.</returns>
        string fetchSearchResultsandProcess(string searchEngine, string KeyWords, string matchUrl);
    }
}