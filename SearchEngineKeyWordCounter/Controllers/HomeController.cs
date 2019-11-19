// Decompiled with JetBrains decompiler
// Type: SearchEngineKeyWordCounter.Controllers.HomeController
// Assembly: SearchEngineKeyWordCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E9D6ED4-F37D-45A7-8FCF-62098EDA6852
// Assembly location: C:\Users\tobst\source\repos\New folder\SearchEngineKeyWordCounter.dll

using SearchEngineKeyWordCounter.Models;
using SearchEngineKeyWordCounter.SearchLogic;
using SearchEngineKeyWordCounter.SharedLogic;
using System.Web.Mvc;

namespace SearchEngineKeyWordCounter.Controllers
{
  public class HomeController : Controller
  {
    private MainPageModel MainPageModel = new MainPageModel();

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.MainPageModel);
    }

    [HttpPost]
    public ActionResult KeyWordSearch(MainPageModel model)
    {
      try
      {
        this.GuardString(model.KeyWordList);
        this.GuardString(model.KeyWordList);
        if (!this.ModelState.IsValid)
          ;
        MainEntryLogicForSearch entryLogicForSearch = new MainEntryLogicForSearch();
        model.OutPutMessage = entryLogicForSearch.MainLogic(model.KeyWordList, model.SearchList, model.WordToSearchOn);
        return (ActionResult) this.View("Index", (object) model);
      }
      catch (InputStringIsNullOrEmptyException ex)
      {
        model.OutPutMessage = ex.Message;
        return (ActionResult) this.View("Index", (object) model);
      }
    }

    private string GuardString(string stringCheck)
    {
      if (string.IsNullOrWhiteSpace(stringCheck))
        throw new InputStringIsNullOrEmptyException(string.Format("{0} cannot be null or empty, please input a value", (object) stringCheck));
      return stringCheck;
    }
  }
}
