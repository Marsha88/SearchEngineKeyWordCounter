using SearchEngineKeyWordCounter.SearchLogic;
using SearchEngineWordCount.ExternalCalls;
using SearchEngineWordCount.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

/// <summary>
/// Unity initialiser 
/// </summary>
namespace SearchEngineWordCount.Unity
{

    /// <summary>
    /// Unity initialiser 
    /// </summary>
    public static class UnityRegistration
    {
        /// <summary>
        /// The unity container
        /// </summary>
        public static UnityContainer unityContainer;

        /// <summary>
        /// Sets upp all the registers.
        /// </summary>
        public static void SetUpUnity()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IGetDataClass, GetDataClass>();
            unityContainer.RegisterType<IControllerForSearch, ControllerForSearch>();
            unityContainer.RegisterType<IWebClientHelper, WebClientHelper>();
            unityContainer.RegisterType<ILogOutToFile, LogOutToFile>();
            
        }

        /// <summary>
        /// Resolves a given interface.
        /// </summary>
        /// <typeparam name="T">interface type</typeparam>
        /// <returns>The resolved interface.</returns>
        public static T Retrieve<T>()
        {
            return unityContainer.Resolve<T>();
        }

    }
}