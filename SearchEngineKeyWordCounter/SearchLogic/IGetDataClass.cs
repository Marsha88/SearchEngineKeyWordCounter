namespace SearchEngineKeyWordCounter.SearchLogic
{
    public interface IGetDataClass 
    {
        string fetchSearchResultsandProcess(string searchEngine, string KeyWords, string matchUrl);
    }
}