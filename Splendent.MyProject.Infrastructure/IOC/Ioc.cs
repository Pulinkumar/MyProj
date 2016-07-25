using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.Web;

namespace Splendent.MyProject.Infrastructure.IOC
{
    public static class IoC
    {
        #region constants

        private const string IOC_CONFIG_PATH = "~/App_Config/EnterpriseLibrary/unity.config";

        #endregion

        #region Private

        private static Lazy<IUnityContainer> _unityContainer = new Lazy<IUnityContainer>(() =>
        {
            try
            {
                string configPath = IOC_CONFIG_PATH;

                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = HttpContext.Current.Server.MapPath(configPath)
                };

                Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection cfgSection = (UnityConfigurationSection)cfg.GetSection("unity");

                IUnityContainer container = new UnityContainer().LoadConfiguration(cfgSection);

                return container;
            }
            catch (Exception ex)
            {
                throw;
            }
        });

        #endregion

        #region Public

        /// <summary>
        /// Gets the unity container
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Container
        {
            get
            {
                return _unityContainer.Value;
            }
        }

        #endregion

    }
}
