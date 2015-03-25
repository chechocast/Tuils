using System.Collections.Generic;
using System.IO;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;

namespace Nop.Plugin.Widgets.ResponsiveSlider
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class ResponsiveSliderPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public ResponsiveSliderPlugin(IPictureService pictureService,
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
            return new List<string>() { "home_page_top" };
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
            controllerName = "WidgetsResponsiveSlider";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Widgets.ResponsiveSlider.Controllers" }, { "area", null } };
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
            controllerName = "WidgetsResponsiveSlider";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "Nop.Plugin.Widgets.ResponsiveSlider.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //pictures
            var sampleImagesPath = _webHelper.MapPath("~/Plugins/Widgets.ResponsiveSlider/Content/images/");


            //settings
            var settings = new ResponsiveSliderSettings()
            {
                //------------------------------------------------Fashion/Shoes preload
                Picture1Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "slide_1.jpg"), "image/jpeg", "slide_1", true).Id,
                Picture2Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "slide_2.jpg"), "image/jpeg", "slide_2", true).Id,
                //Picture3Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "slide_3.jpg"), "image/jpeg", "slide_3", true).Id,

                //------------------------------------------------PhotoVideo preload
                //Picture1Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "bg.png"), "image/png", "bg_1", true).Id,
                //TitleText1 = "Introducing Samsung ATIV",
                //TitleTextEffects1 = "data-x=\"600\" data-y=\"120\" data-width=\"250\" data-transition=\"wipeRight\"",
                //Text1 = "Discover a New Era of Computing",
                //TextEffects1 = "data-x=\"600\" data-y=\"200\" data-width=\"250\" data-transition=\"wipeLeft\"",
                //Link1 = _webHelper.GetStoreLocation(false),
                //Media1 = "<img src=\"/Themes/Photovideo/Content/slider/product_1.png\" />",
                //MediaEffects1 = "data-x=\"50\" data-y=\"50\" data-transition=\"wipeUp\"",

                //Picture2Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "bg.png"), "image/png", "bg_2", true).Id,
                //TitleText2 = "The Next Big Thing Is Coming Soon",
                //TitleTextEffects2 = "data-x=\"600\" data-y=\"100\" data-width=\"250\" data-transition=\"wipeRight\"",
                //Text2 = "Register Now for More Information",
                //TextEffects2 = "data-x=\"600\" data-y=\"220\" data-width=\"250\" data-transition=\"wipeLeft\"",
                //Link2 = _webHelper.GetStoreLocation(false),
                //Media2 = "<img src=\"/Themes/Photovideo/Content/slider/product_2.png\" />",
                //MediaEffects2 = "data-x=\"50\" data-y=\"20\" data-transition=\"wipeUp\"",

                //BannerLink2 = _webHelper.GetStoreLocation(false),
                //BannerPicture2Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "banner2.png"), "image/png", "banner_2", true).Id,
                //BannerText2 = "<h2>Make it yours</h2><h3>More details</h3>",
                //BannerAltText2 = "Make it yours",
                //------------------------------------------------------------------------------
                //BannerLink3 = _webHelper.GetStoreLocation(false),
                //BannerPicture3Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "banner3.jpg"), "image/pjpeg", "banner_3", true).Id,
                //BannerText3 = "",
                //BannerAltText3 = "",

                BannerLink1 = _webHelper.GetStoreLocation(false),
                BannerPicture1Url = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "banner.png"), "image/png", "banner_1", true).Id,
                //BannerText1 = "<h2>Baby Bath & Skin Care</h2><h3>More details</h3>",
                BannerAltText1 = "Discount Vitamins, Supplements, Health Foods and Sports Nutrition",



                MaxWidth = 540,
                Nav = true,
                Pager = true,
                ManualControls = false
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.General", "General Options");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Slides", "Slides");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banners", "Banners");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.SaveSettings", "Save settings");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture1", "Slide 1");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture2", "Slide 2");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture3", "Slide 3");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture4", "Slide 4");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banner1", "Banner 1");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banner2", "Banner 2");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banner3", "Banner 3");


            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.SliderProperties", "Slider Properties");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture", "Picture");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.PictureThumb", "Thumb");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.ValidBannerSizes", "You can display on home page 2 variants of banners: 2 banners with height 180px or 1 banner with height 375px.");//TODO: calculate sizes
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerPicture", "Banner Picture");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerText", "Banner Text");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerAltText", "Banner Tooltip");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerLink", "Banner Link");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerPicture.Hint", "Select a banner");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerText.Hint", "Enter text for banner");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerAltText.Hint", "Enter tooltip for banner");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerLink.Hint", "Enter a link URL");


            //properties
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MaxWidth", "Max-width");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MaxWidth.Hint", "Max-width of the slideshow, in pixels");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Nav", "Show navigation");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Nav.Hint", "Show navigation, true or false");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Pager", "Show pager");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Pager.Hint", "Show pager, true or false");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.ManualControls", "Thumbnails pager navigation");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.ManualControls.Hint", "Thumbnails pager navigation");


            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture.Hint", "Upload picture");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.PictureThumb.Hint", "Upload a thumb for picture");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleText", "Title");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleText.Hint", "Enter a title for slide");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleTextEffects", "Title effects");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleTextEffects.Hint", "Enter in format (data-x=\"50\" data-y=\"50\"). Please read documentations for details");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Text", "Short description");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Text.Hint", "Enter comment for picture, leave empty if you don't want display any text.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TextEffects", "Short description effects");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TextEffects.Hint", "Enter html attributes in format (data-x=\"50\" data-y=\"50\"). Please read documentations for details");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Media", "Media");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Media.Hint", "Enter iframe for video or <img> html tag with absolute source URL.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MediaEffects", "Media effects");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MediaEffects.Hint", "Enter in format (data-x=\"50\" data-y=\"50\"). Please read documentations for details");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Link", "URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Link.Hint", "Enter URL, leave empty if you don't want this picture to be clickable");



            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ResponsiveSliderSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.General");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Slides");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banners");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.SaveSettings");

            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.ValidBannerSizes");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerPicture");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerText");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerAltText");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerLink");

            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerPicture.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerText.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerAltText.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.BannerLink.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture1");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture2");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture3");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture4");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.PictureThumb");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Picture.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.PictureThumb.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banner1");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banner2");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Banner3");

            //properties 
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.SliderProperties");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MaxWidth");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MaxWidth.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Nav");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Nav.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Pager");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Pager.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.ManualControls");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.ManualControls.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleText");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleText.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleTextEffects");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TitleTextEffects.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Text");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Text.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TextEffects");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.TextEffects.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Media");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Media.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MediaEffects");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.MediaEffects.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Link");
            this.DeletePluginLocaleResource("Plugins.Widgets.ResponsiveSlider.Link.Hint");

            base.Uninstall();
        }
    }
}
