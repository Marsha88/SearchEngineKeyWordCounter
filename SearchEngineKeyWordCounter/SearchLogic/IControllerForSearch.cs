
/// <summary>
/// The controller for the applications backend logic.
/// </summary>
namespace SearchEngineKeyWordCounter.SearchLogic
{
    /// <summary>
    /// The controller for the applications backend logic.
    /// </summary>
    public interface IControllerForSearch
    {
        /// <summary>
        /// The main run logic for the back end
        /// </summary>
        /// <param name="keyWords">The key words to search in teh search engine.</param>
        /// <param name="searchEngine">The search Engine.</param>
        /// <param name="matchUrl">What url to find in the results.</param>
        /// <returns>An output message.</returns>
        string MainLogic(string keyWords, string searchEngine, string searchWord);
    }
}