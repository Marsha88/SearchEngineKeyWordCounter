/// <summary>
/// Deals with the logging of the application.
/// </summary>
namespace SearchEngineWordCount.Logging
{
    /// <summary>
    /// Deals with the logging of the application.
    /// </summary>
    public interface ILogOutToFile
    {
        /// <summary>
        /// Writes the log out to a log file , with a name depending if it's just a normal finished log or an exception had occured.
        /// </summary>
        /// <param name="stringToWriteOut"></param>
        /// <param name="logType"></param>
        void WriteToFile(string stringToWriteOut, string logType);
    }
}