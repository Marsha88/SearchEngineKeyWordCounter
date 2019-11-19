using System;
using System.Configuration;
using System.IO;

/// <summary>
/// Deals with the logging of the application.
/// </summary>
namespace SearchEngineWordCount.Logging
{
    /// <summary>
    /// Deals with the logging of the application.
    /// </summary>
    public class LogOutToFile : ILogOutToFile
    {

        /// <summary>
        /// Writes the log out to a log file , with a name depending if it's just a normal finished log or an exception had occured.
        /// </summary>
        /// <param name="stringToWriteOut"></param>
        /// <param name="logType"></param>
        public void WriteToFile(string stringToWriteOut, string logType)
        {

            var currentTime = DateTime.Now;
            var writeLocation = string.Format("{0}\\LogFiles\\{1}{2}", ConfigurationManager.AppSettings["WriteOutLocation"] ?? "C:\\Temp", currentTime.Year, currentTime.DayOfYear);
            Directory.CreateDirectory(writeLocation);

            using (StreamWriter sw = File.AppendText(writeLocation + "\\" + logType + ".txt"))
            {
                sw.WriteLine(stringToWriteOut);
                sw.WriteLine();

            }

        }
    }
}