

    /// <summary>
    /// Class for calling webclient functions behind a interface.
    /// </summary>
namespace SearchEngineWordCount.ExternalCalls
{
    /// <summary>
    /// Class for calling webclient functions behind a interface.
    /// </summary>
    public class WebClientHelper : IWebClientHelper
    {
        /// <summary>
        /// Returns the raw HTML of a webpage so it can be searched.
        /// </summary>
        /// <param name="urlConstructed">The url to call.</param>
        /// <returns>The raw HTML as a string.</returns>
        public string returnWebClientResource(string urlConstructed)
        {
            //TODO Find better way of grabbing the html.
            return new System.Net.WebClient().DownloadString(urlConstructed);
        }
    }
}