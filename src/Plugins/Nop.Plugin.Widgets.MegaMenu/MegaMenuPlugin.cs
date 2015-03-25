using System.Collections.Generic;
using System.IO;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;

namespace Nop.Plugin.Widgets.MegaMenu
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class MegaMenuPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public MegaMenuPlugin(IPictureService pictureService, 
            ISettingService settingService, IWebHelper webHelper)
        {
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._webHelper = webHelper;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string>() { "content_before" };
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsMegaMenu";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Widgets.MegaMenu.Controllers" }, { "area", null } };
        }

        /// <summary>
        /// Gets a route for displaying widget
        /// </summary>
        /// <param name="widgetZone">Widget zone where it's displayed</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsMegaMenu";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "Nop.Plugin.Widgets.MegaMenu.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            //pictures
            var sampleImagesPath = _webHelper.MapPath("~/Plugins/Widgets.MegaMenu/Content/images/");

            var settings = new MegaMenuSettings()
            {
                EnableMenu = true,
                EnableResponsiveMenu = true,
                IncludeCategoriesInMenu = true,
                DisplaySubcategories = true,
                DisplayHomePage = true,
                ColumnsNumber = 4,
                CustomItems = string.Format(@"                
                <li><a href=""/"">Custom Item 1</a>
                  <ul>
                <li><a href=""/"">Custom Item 1</a>

                <ul>
                <li><a href=""/"">Custom Sub Item 1</a></li> 
                <li><a href=""/"">Custom Sub Item 2</a></li>
                <li><a href=""/"">Custom Sub Item 3</a></li> </ul>

                </li> 
                <li><a href=""/"">Custom Item 2</a>

                <ul>
                <li><a href=""/"">Custom Sub Item 1</a></li> 
                <li><a href=""/"">Custom Sub Item 2</a></li>
                <li><a href=""/"">Custom Sub Item 3</a></li> </ul>

                </li>
                <li><a href=""/"">Custom Item 3</a>

                <ul>
                <li><a href=""/"">Custom Sub Item 1</a></li> 
                <li><a href=""/"">Custom Sub Item 2</a></li>
                <li><a href=""/"">Custom Sub Item 3</a></li> </ul>

                </li> </ul>
                </li>
                <li><a href=""/"">Custom Item 2</a></li>
                "),

                //BgPicture1Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "bg_1.png"), "image/png", "bg_1", true).Id,
                //BgPicture2Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "bg_2.png"), "image/png", "bg_2", true).Id
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableMenu", "Enable Menu");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableResponsiveMenu", "Enable Responsive Menu");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableMenu.Hint", "Select a checkbox if you want enable menu");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableResponsiveMenu.Hint", "Select a checkbox if you want enable responsive menu");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.IncludeCategoriesInMenu", "Include categories");            
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.IncludeCategoriesInMenu.Hint", "Select a checkbox if you want include categories in menu");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplayHomePage", "Include Home Page");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplayHomePage.Hint", "Include home page link in mega menu");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplaySubcategories", "Display Subcategories");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.ColumnsNumber", "Columns Number");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.CustomItems", "Custom Menu Items (optional)");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.CustomItems.Hint", "Enter free HTML code which start with <li>. You can use <li> - simple menu item, <li><ul><li> - dropdown or <li><ul><li><ul><li> - mega menu item");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplaySubcategories.Hint", "Select a checkbox if you want display subcategories");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.ColumnsNumber.Hint", "Enter a columns number for mega menu (in order to use more than 1 column, you should map your categories as parent - > child)");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.Configuration", "Mega Menu Configuration");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.BgConfiguration", "Mega Menu Background Configuration");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture1", "Mega Menu 1 Picture URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture2", "Mega Menu 2 Picture URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture3", "Mega Menu 3 Picture URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture4", "Mega Menu 4 Picture URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture5", "Mega Menu 5 Picture URL");
            
            
            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<MegaMenuSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableMenu");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableResponsiveMenu");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableMenu.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.EnableResponsiveMenu.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplaySubcategories");
            
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplaySubcategories.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplayHomePage");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.DisplayHomePage.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.ColumnsNumber");
            
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.ColumnsNumber.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.CustomItems");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.CustomItems.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.IncludeCategoriesInMenu");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.IncludeCategoriesInMenu.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.Configuration");

            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.BgConfiguration");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture1");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture2");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture3");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture4");
            this.DeletePluginLocaleResource("Plugins.Widgets.MegaMenu.BgPicture5");
                               
            base.Uninstall();
        }
    }
}
