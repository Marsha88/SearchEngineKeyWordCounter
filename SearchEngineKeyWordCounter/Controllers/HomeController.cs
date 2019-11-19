using SearchEngineKeyWordCounter.Models;
using SearchEngineKeyWordCounter.SearchLogic;
using SearchEngineKeyWordCounter.SharedLogic;
using System.Web.Mvc;
using SearchEngineWordCount.Unity;
using Unity;

/// <summary>
/// The controller for the main page.
/// </summary>
namespace SearchEngineKeyWordCounter.Controllers
{
    /// <summary>
    /// The controller for the main page.
    /// </summary>
  public class HomeController : Controller
  {
        private MainPageModel MainPageModel = new MainPageModel();

        /// <summary>
        /// Creates main page on set up and sets up unity
        /// </summary>
        /// <returns>The main page view</returns>
        public ActionResult Index()
    {
       UnityRegistration.SetUpUnity();

       return this.View(MainPageModel);
    }

        /// <summary>
        /// On button click, this will search for a inputted keyword.
        /// </summary>
        /// <param name="model">The model for the current view</param>
        /// <returns>An updated view with the output.</returns>
    [HttpPost]
    public ActionResult KeyWordSearch(MainPageModel model)
    {
      try
      {
        this.GuardString(model.SearchKeyWords);
        this.GuardString(model.SearchKeyWords);
        var entryLogicForSearch = UnityRegistration.Retrieve<IControllerForSearch>();
         model.OutPutMessage = entryLogicForSearch.MainLogic(model.SearchKeyWords, model.SearchEngine, model.SearchURL);
        return this.View("Index", model);
      }
      catch (InputStringIsNullOrEmptyException ex)
      {
        model.OutPutMessage = ex.Message;
        return this.View("Index", model);
      }
    }

        /// <summary>
        /// Checks the string isn't null or empty, and if it is, it responds with a message to the user.
        /// </summary>
        /// <param name="stringCheck">String to check<./param>
        /// <returnsThe string if it is populated, else throws a custom exception.></returns>
    private string GuardString(string stringCheck)
    {
      if (string.IsNullOrWhiteSpace(stringCheck))
        throw new InputStringIsNullOrEmptyException(string.Format("{0} cannot be null or empty, please input a value", stringCheck));
      return stringCheck;
    }
  }
}
