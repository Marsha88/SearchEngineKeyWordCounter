using SearchEngineKeyWordCounter.Models;
using SearchEngineKeyWordCounter.SearchLogic;
using SearchEngineKeyWordCounter.SharedLogic;
using System.Web.Mvc;
using SearchEngineWordCount.Unity;
using Unity;

namespace SearchEngineKeyWordCounter.Controllers
{
  public class HomeController : Controller
  {
        private MainPageModel MainPageModel = new MainPageModel();


        public ActionResult Index()
    {
       UnityRegistration.SetUpUnity();

       return this.View(MainPageModel);
    }

    [HttpPost]
    public ActionResult KeyWordSearch(MainPageModel model)
    {
      try
      {
        this.GuardString(model.KeyWordList);
        this.GuardString(model.KeyWordList);
        var entryLogicForSearch = UnityRegistration.Retrieve<IControllerForSearch>();
         model.OutPutMessage = entryLogicForSearch.MainLogic(model.KeyWordList, model.SearchList, model.WordToSearchOn);
        return this.View("Index", model);
      }
      catch (InputStringIsNullOrEmptyException ex)
      {
        model.OutPutMessage = ex.Message;
        return this.View("Index", model);
      }
    }

    private string GuardString(string stringCheck)
    {
      if (string.IsNullOrWhiteSpace(stringCheck))
        throw new InputStringIsNullOrEmptyException(string.Format("{0} cannot be null or empty, please input a value", stringCheck));
      return stringCheck;
    }
  }
}
