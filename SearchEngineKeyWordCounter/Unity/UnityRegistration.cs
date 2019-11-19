using SearchEngineKeyWordCounter.SearchLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace SearchEngineWordCount.Unity
{

    public static class UnityRegistration
    {
        public static UnityContainer unityContainer;

        public static void SetUpUnity()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IGetDataClass, GetDataClass>();
            unityContainer.RegisterType<IControllerForSearch, ControllerForSearch>();
            
        }

        public static T Retrieve<T>()
        {
            return unityContainer.Resolve<T>();
        }

    }
}