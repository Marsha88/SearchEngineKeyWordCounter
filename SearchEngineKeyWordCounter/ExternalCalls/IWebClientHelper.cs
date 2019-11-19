/// <summary>
/// This is interfaced out so it can be MOQ
/// </summary>
namespace SearchEngineWordCount.ExternalCalls
{

    /// <summary>
    /// This is interfaced out so it can be MOQ
    /// </summary>
   public interface IWebClientHelper
    {
        /// <summary>
        /// Returns the raw HTML of a webpage so it can be searched.
        /// </summary>
        /// <param name="urlConstructed">The url to call.</param>
        /// <returns>The raw HTML as a string.</returns>
        string returnWebClientResource(string searchUrl);
    }
}