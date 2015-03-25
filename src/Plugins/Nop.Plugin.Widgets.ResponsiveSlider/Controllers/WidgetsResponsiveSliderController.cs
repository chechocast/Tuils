using System.Web;
using System.Web.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.ResponsiveSlider.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.ResponsiveSlider.Controllers
{
    public class WidgetsResponsiveSliderController : BaseController
    {
        private readonly IPictureService _pictureService;
        private readonly ResponsiveSliderSettings _responsiveSliderSettings;
        private readonly ISettingService _settingService;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;

        public WidgetsResponsiveSliderController(IPictureService pictureService, 
            ResponsiveSliderSettings responsiveSliderSettings, ISettingService settingService, IStoreContext storeContext, IStoreService storeService,IWorkContext workContext)
        {
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._storeService = storeService;
            this._pictureService = pictureService;
            this._responsiveSliderSettings = responsiveSliderSettings;
            this._settingService = settingService;
        }
        
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var responsiveSliderSettings = _settingService.LoadSetting<ResponsiveSliderSettings>(storeScope);
            var model = new ConfigurationModel();

            model.Picture1Url = responsiveSliderSettings.Picture1Url;
            model.PictureThumb1Url = responsiveSliderSettings.PictureThumb1Url;
            model.Text1 = responsiveSliderSettings.Text1;
            model.Link1 = responsiveSliderSettings.Link1;

            model.TitleText1 = responsiveSliderSettings.TitleText1;
            model.TitleTextEffects1 = responsiveSliderSettings.TitleTextEffects1;
            model.SubTitleText1 = responsiveSliderSettings.SubTitleText1;
            model.SubTitleTextEffects1 = responsiveSliderSettings.SubTitleTextEffects1;
            model.TextEffects1 = responsiveSliderSettings.TextEffects1;
            model.Media1 = responsiveSliderSettings.Media1;
            model.MediaEffects1 = responsiveSliderSettings.MediaEffects1;
           

            model.Picture2Url = responsiveSliderSettings.Picture2Url;
            model.PictureThumb2Url = responsiveSliderSettings.PictureThumb2Url;
            model.Text2 = responsiveSliderSettings.Text2;
            model.Link2 = responsiveSliderSettings.Link2;

            model.TitleText2 = responsiveSliderSettings.TitleText2;
            model.TitleTextEffects2 = responsiveSliderSettings.TitleTextEffects2;
            model.SubTitleText2 = responsiveSliderSettings.SubTitleText2;
            model.SubTitleTextEffects2 = responsiveSliderSettings.SubTitleTextEffects2;

            model.TextEffects2 = responsiveSliderSettings.TextEffects2;
            model.Media2 = responsiveSliderSettings.Media2;
            model.MediaEffects2 = responsiveSliderSettings.MediaEffects2;

            model.Picture3Url = responsiveSliderSettings.Picture3Url;
            model.PictureThumb3Url = responsiveSliderSettings.PictureThumb3Url;
            model.Text3 = responsiveSliderSettings.Text3;
            model.Link3 = responsiveSliderSettings.Link3;

            model.TitleText3 = responsiveSliderSettings.TitleText3;
            model.TitleTextEffects3 = responsiveSliderSettings.TitleTextEffects3;
            model.SubTitleText3 = responsiveSliderSettings.SubTitleText3;
            model.SubTitleTextEffects3 = responsiveSliderSettings.SubTitleTextEffects3;

            model.TextEffects3 = responsiveSliderSettings.TextEffects3;
            model.Media3 = responsiveSliderSettings.Media3;
            model.MediaEffects3 = responsiveSliderSettings.MediaEffects3;

            model.Picture4Url = responsiveSliderSettings.Picture4Url;
            model.PictureThumb4Url = responsiveSliderSettings.PictureThumb4Url;
            model.Text4 = responsiveSliderSettings.Text4;
            model.Link4 = responsiveSliderSettings.Link4;

            model.TitleText4 = responsiveSliderSettings.TitleText4;
            model.TitleTextEffects4 = responsiveSliderSettings.TitleTextEffects4;
            model.SubTitleText4 = responsiveSliderSettings.SubTitleText4;
            model.SubTitleTextEffects4 = responsiveSliderSettings.SubTitleTextEffects4;

            model.TextEffects4 = responsiveSliderSettings.TextEffects4;
            model.Media4 = responsiveSliderSettings.Media4;
            model.MediaEffects4 = responsiveSliderSettings.MediaEffects4;

            model.BannerPicture1Url = responsiveSliderSettings.BannerPicture1Url;
            model.BannerText1 = responsiveSliderSettings.BannerText1;
            model.BannerAltText1 = responsiveSliderSettings.BannerAltText1;
            model.BannerLink1 = responsiveSliderSettings.BannerLink1;

            model.BannerPicture2Url = responsiveSliderSettings.BannerPicture2Url;
            model.BannerText2 = responsiveSliderSettings.BannerText2;
            model.BannerAltText2 = responsiveSliderSettings.BannerAltText2;
            model.BannerLink2 = responsiveSliderSettings.BannerLink2;

            model.BannerPicture3Url = responsiveSliderSettings.BannerPicture3Url;
            model.BannerText3 = responsiveSliderSettings.BannerText3;
            model.BannerAltText3 = responsiveSliderSettings.BannerAltText3;
            model.BannerLink3 = responsiveSliderSettings.BannerLink3;

            model.BannerPicture4Url = responsiveSliderSettings.BannerPicture4Url;
            model.BannerText4 = responsiveSliderSettings.BannerText4;
            model.BannerAltText4 = responsiveSliderSettings.BannerAltText4;
            model.BannerLink4 = responsiveSliderSettings.BannerLink4;


            //properties
            model.MaxWidth = responsiveSliderSettings.MaxWidth;
            model.Nav = responsiveSliderSettings.Nav;
            model.Pager = responsiveSliderSettings.Pager;
            model.ManualControls = responsiveSliderSettings.ManualControls;

            model.ActiveStoreScopeConfiguration = storeScope;
            if (storeScope > 0)
            {
                model.Picture1Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Picture1Url, storeScope);
                model.PictureThumb1Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.PictureThumb1Url, storeScope);
                model.Text1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Text1, storeScope);
                model.Link1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Link1, storeScope);
                model.TitleText1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleText1, storeScope);
                model.TitleTextEffects1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleTextEffects1, storeScope);
                model.SubTitleText1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleText1, storeScope);
                model.SubTitleTextEffects1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleTextEffects1, storeScope);
                model.TextEffects1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TextEffects1, storeScope);
                model.Media1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Media1, storeScope);
                model.MediaEffects1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.MediaEffects1, storeScope);

                model.Picture2Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Picture2Url, storeScope);
                model.PictureThumb2Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.PictureThumb2Url, storeScope);
                model.Text2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Text2, storeScope);
                model.Link2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Link2, storeScope);
                model.TitleText2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleText2, storeScope);
                model.TitleTextEffects2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleTextEffects2, storeScope);
                model.SubTitleText2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleText2, storeScope);
                model.SubTitleTextEffects2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleTextEffects2, storeScope);
                model.TextEffects2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TextEffects2, storeScope);
                model.Media2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Media2, storeScope);
                model.MediaEffects2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.MediaEffects2, storeScope);


                model.Picture3Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Picture3Url, storeScope);
                model.PictureThumb3Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.PictureThumb3Url, storeScope);
                model.Text3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Text3, storeScope);
                model.Link3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Link3, storeScope);
                model.TitleText3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleText3, storeScope);
                model.TitleTextEffects3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleTextEffects3, storeScope);
                model.SubTitleText3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleText3, storeScope);
                model.SubTitleTextEffects3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleTextEffects3, storeScope);
                model.TextEffects3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TextEffects3, storeScope);
                model.Media3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Media3, storeScope);
                model.MediaEffects3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.MediaEffects3, storeScope);

                model.Picture4Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Picture4Url, storeScope);
                model.PictureThumb4Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.PictureThumb4Url, storeScope);
                model.Text4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Text4, storeScope);
                model.Link4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Link4, storeScope);
                model.TitleText4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleText4, storeScope);
                model.TitleTextEffects4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TitleTextEffects4, storeScope);
                model.SubTitleText4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleText4, storeScope);
                model.SubTitleTextEffects4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.SubTitleTextEffects4, storeScope);

                model.TextEffects4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.TextEffects4, storeScope);
                model.Media4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Media4, storeScope);
                model.MediaEffects4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.MediaEffects4, storeScope);

                model.BannerPicture1Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerPicture1Url, storeScope);
                model.BannerText1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerText1, storeScope);
                model.BannerAltText1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerAltText1, storeScope);
                model.BannerLink1_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerLink1, storeScope);
                
                model.BannerPicture2Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerPicture2Url, storeScope);
                model.BannerText2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerText2, storeScope);
                model.BannerAltText2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerAltText2, storeScope);
                model.BannerLink2_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerLink2, storeScope);
                
                model.BannerPicture3Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerPicture3Url, storeScope);
                model.BannerText3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerText3, storeScope);
                model.BannerAltText3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerAltText3, storeScope);
                model.BannerLink3_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerLink3, storeScope);

                model.BannerPicture4Url_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerPicture4Url, storeScope);
                model.BannerText4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerText4, storeScope);
                model.BannerAltText4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerAltText4, storeScope);
                model.BannerLink4_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.BannerLink4, storeScope);


                model.MaxWidth_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.MaxWidth, storeScope);
                model.Nav_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Nav, storeScope);
                model.Pager_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.Pager, storeScope);
                model.ManualControls_OverrideForStore = _settingService.SettingExists(responsiveSliderSettings, x => x.ManualControls, storeScope);
            }


            return View("~/Plugins/Widgets.ResponsiveSlider/Views/WidgetsResponsiveSlider/Configure.cshtml", model);

        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var responsiveSliderSettings = _settingService.LoadSetting<ResponsiveSliderSettings>(storeScope);
            //save settings
            responsiveSliderSettings.Picture1Url = model.Picture1Url;
            responsiveSliderSettings.PictureThumb1Url = model.PictureThumb1Url;
            responsiveSliderSettings.Text1 = model.Text1;
            responsiveSliderSettings.Link1 = model.Link1;
            //-------------------------------------------
            responsiveSliderSettings.TitleText1 = model.TitleText1;
            responsiveSliderSettings.TitleTextEffects1 = model.TitleTextEffects1;
            responsiveSliderSettings.SubTitleText1 = model.SubTitleText1;
            responsiveSliderSettings.SubTitleTextEffects1 = model.SubTitleTextEffects1;
            responsiveSliderSettings.TextEffects1 = model.TextEffects1;
            responsiveSliderSettings.Media1 = model.Media1;
            responsiveSliderSettings.MediaEffects1 = model.MediaEffects1;
            //-------------------------------------------

            responsiveSliderSettings.Picture2Url = model.Picture2Url;
            responsiveSliderSettings.PictureThumb2Url = model.PictureThumb2Url;
            responsiveSliderSettings.Text2 = model.Text2;
            responsiveSliderSettings.Link2 = model.Link2;
            //-------------------------------------------
            responsiveSliderSettings.TitleText2 = model.TitleText2;
            responsiveSliderSettings.TitleTextEffects2 = model.TitleTextEffects2;
            responsiveSliderSettings.SubTitleText2 = model.SubTitleText2;
            responsiveSliderSettings.SubTitleTextEffects2 = model.SubTitleTextEffects2;
            responsiveSliderSettings.TextEffects2 = model.TextEffects2;
            responsiveSliderSettings.Media2 = model.Media2;
            responsiveSliderSettings.MediaEffects2 = model.MediaEffects2;
            //-------------------------------------------

            responsiveSliderSettings.Picture3Url = model.Picture3Url;
            responsiveSliderSettings.PictureThumb3Url = model.PictureThumb3Url;
            responsiveSliderSettings.Text3 = model.Text3;
            responsiveSliderSettings.Link3 = model.Link3;
            //-------------------------------------------
            responsiveSliderSettings.TitleText3 = model.TitleText3;
            responsiveSliderSettings.TitleTextEffects3 = model.TitleTextEffects3;
            responsiveSliderSettings.SubTitleText3 = model.SubTitleText3;
            responsiveSliderSettings.SubTitleTextEffects3 = model.SubTitleTextEffects3;
            responsiveSliderSettings.TextEffects3 = model.TextEffects3;
            responsiveSliderSettings.Media3 = model.Media3;
            responsiveSliderSettings.MediaEffects3 = model.MediaEffects3;
            //-------------------------------------------

            
            responsiveSliderSettings.Picture4Url = model.Picture4Url;
            responsiveSliderSettings.PictureThumb4Url = model.PictureThumb4Url;
            responsiveSliderSettings.Text4 = model.Text4;
            responsiveSliderSettings.Link4 = model.Link4;
            //-------------------------------------------
            responsiveSliderSettings.TitleText4 = model.TitleText4;
            responsiveSliderSettings.TitleTextEffects4 = model.TitleTextEffects4;
            responsiveSliderSettings.SubTitleText4 = model.SubTitleText4;
            responsiveSliderSettings.SubTitleTextEffects4 = model.SubTitleTextEffects4;
            responsiveSliderSettings.TextEffects4 = model.TextEffects4;
            responsiveSliderSettings.Media4 = model.Media4;
            responsiveSliderSettings.MediaEffects4 = model.MediaEffects4;
            //-------------------------------------------


            responsiveSliderSettings.BannerPicture1Url = model.BannerPicture1Url;
            responsiveSliderSettings.BannerText1 = model.BannerText1;
            responsiveSliderSettings.BannerAltText1 = model.BannerAltText1;
            responsiveSliderSettings.BannerLink1 = model.BannerLink1;

            responsiveSliderSettings.BannerPicture2Url = model.BannerPicture2Url;
            responsiveSliderSettings.BannerText2 = model.BannerText2;
            responsiveSliderSettings.BannerAltText2 = model.BannerAltText2;
            responsiveSliderSettings.BannerLink2 = model.BannerLink2;

            responsiveSliderSettings.BannerPicture3Url = model.BannerPicture3Url;
            responsiveSliderSettings.BannerText3 = model.BannerText3;
            responsiveSliderSettings.BannerAltText3 = model.BannerAltText3;
            responsiveSliderSettings.BannerLink3 = model.BannerLink3;

            responsiveSliderSettings.BannerPicture4Url = model.BannerPicture4Url;
            responsiveSliderSettings.BannerText4 = model.BannerText4;
            responsiveSliderSettings.BannerAltText4 = model.BannerAltText4;
            responsiveSliderSettings.BannerLink4 = model.BannerLink4;


            //properties
            responsiveSliderSettings.MaxWidth = model.MaxWidth;
            responsiveSliderSettings.Nav = model.Nav;
            responsiveSliderSettings.Pager = model.Pager;
            responsiveSliderSettings.ManualControls = model.ManualControls;

            /* We do not clear cache after each setting update.
            * This behavior can increase performance because cached settings will not be cleared 
            * and loaded from database after each update */

            #region first slide
            if (model.Picture1Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Picture1Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Picture1Url, storeScope);
            if (model.PictureThumb1Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.PictureThumb1Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.PictureThumb1Url, storeScope);
            if (model.Text1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Text1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Text1, storeScope);
            if (model.Link1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Link1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Link1, storeScope);
            if (model.TitleText1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleText1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleText1, storeScope);
            if (model.TitleTextEffects1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleTextEffects1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleTextEffects1, storeScope);
            
            if (model.SubTitleText1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleText1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleText1, storeScope);
            if (model.SubTitleTextEffects1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleTextEffects1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleTextEffects1, storeScope);
            if (model.TextEffects1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TextEffects1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TextEffects1, storeScope);
            if (model.Media1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Media1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Media1, storeScope);
            if (model.MediaEffects1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.MediaEffects1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.MediaEffects1, storeScope);

            #endregion

            #region second slide
            if (model.Picture2Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Picture2Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Picture2Url, storeScope);
            if (model.PictureThumb2Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.PictureThumb2Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.PictureThumb2Url, storeScope);
            if (model.Text2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Text2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Text2, storeScope);
            if (model.Link2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Link2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Link2, storeScope);
            if (model.TitleText2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleText2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleText2, storeScope);
            if (model.TitleTextEffects2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleTextEffects2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleTextEffects2, storeScope);
            if (model.SubTitleText2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleText2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleText2, storeScope);
            if (model.SubTitleTextEffects2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleTextEffects2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleTextEffects2, storeScope);
            if (model.TextEffects2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TextEffects2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TextEffects2, storeScope);
            if (model.Media2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Media2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Media2, storeScope);
            if (model.MediaEffects2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.MediaEffects2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.MediaEffects2, storeScope);
            #endregion

            #region third slide
            if (model.Picture3Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Picture3Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Picture3Url, storeScope);

            if (model.PictureThumb3Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.PictureThumb3Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.PictureThumb3Url, storeScope);

            if (model.Text3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Text3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Text3, storeScope);

            if (model.Link3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Link3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Link3, storeScope);

            if (model.TitleText3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleText3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleText3, storeScope);

            if (model.TitleTextEffects3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleTextEffects3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleTextEffects3, storeScope);

            if (model.SubTitleText3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleText3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleText3, storeScope);
            if (model.SubTitleTextEffects3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleTextEffects3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleTextEffects3, storeScope);

            if (model.TextEffects3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TextEffects3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TextEffects3, storeScope);

            if (model.Media3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Media3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Media3, storeScope);

            if (model.MediaEffects3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.MediaEffects3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.MediaEffects3, storeScope);
            #endregion

            #region four slide
            if (model.Picture4Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Picture4Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Picture4Url, storeScope);
            if (model.PictureThumb4Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.PictureThumb4Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.PictureThumb4Url, storeScope);
            if (model.Text4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Text4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Text4, storeScope);
            if (model.Link4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Link4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Link4, storeScope);
            if (model.TitleText4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleText4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleText4, storeScope);
            if (model.TitleTextEffects4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TitleTextEffects4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TitleTextEffects4, storeScope);

            if (model.SubTitleText4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleText4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleText4, storeScope);
            if (model.SubTitleTextEffects4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.SubTitleTextEffects4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.SubTitleTextEffects4, storeScope);

            if (model.TextEffects4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.TextEffects4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.TextEffects4, storeScope);
            if (model.Media4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Media4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Media4, storeScope);
            if (model.MediaEffects4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.MediaEffects4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.MediaEffects4, storeScope);
            #endregion

            if (model.BannerPicture1Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerPicture1Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerPicture1Url, storeScope);
            if (model.BannerText1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerText1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerText1, storeScope);
            if (model.BannerAltText1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerAltText1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerAltText1, storeScope);
            if (model.BannerLink1_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerLink1, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerLink1, storeScope);

            if (model.BannerPicture2Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerPicture2Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerPicture2Url, storeScope);
            if (model.BannerText2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerText2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerText2, storeScope);
            if (model.BannerAltText2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerAltText2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerAltText2, storeScope);
            if (model.BannerLink2_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerLink2, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerLink2, storeScope);

            if (model.BannerPicture3Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerPicture3Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerPicture3Url, storeScope);
            if (model.BannerText3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerText3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerText3, storeScope);
            if (model.BannerAltText3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerAltText3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerAltText3, storeScope);
            if (model.BannerLink3_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerLink3, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerLink3, storeScope);

            if (model.BannerPicture4Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerPicture4Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerPicture4Url, storeScope);
            if (model.BannerText4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerText4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerText4, storeScope);
            if (model.BannerAltText4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerAltText4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerAltText4, storeScope);
            if (model.BannerLink4_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.BannerLink4, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.BannerLink4, storeScope);

            //properties
            if (model.MaxWidth_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.MaxWidth, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.MaxWidth, storeScope);
            if (model.Nav_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Nav, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Nav, storeScope);
            if (model.Pager_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.Pager, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.Pager, storeScope);
            if (model.ManualControls_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(responsiveSliderSettings, x => x.ManualControls, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(responsiveSliderSettings, x => x.ManualControls, storeScope);

            //now clear settings cache
            _settingService.ClearCache();
                  

            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone)
        {
            var responsiveSliderSettings = _settingService.LoadSetting<ResponsiveSliderSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel();
            model.Picture1Url = _pictureService.GetPictureUrl(responsiveSliderSettings.Picture1Url, showDefaultPicture: false);
            model.PictureThumb1Url = _pictureService.GetPictureUrl(responsiveSliderSettings.PictureThumb1Url, showDefaultPicture: false);
            model.Text1 = responsiveSliderSettings.Text1;
            model.Link1 = responsiveSliderSettings.Link1;
            model.TitleText1 = responsiveSliderSettings.TitleText1;
            model.TitleTextEffects1 = responsiveSliderSettings.TitleTextEffects1;
            model.SubTitleText1 = responsiveSliderSettings.SubTitleText1;
            model.SubTitleTextEffects1 = responsiveSliderSettings.SubTitleTextEffects1;

            model.TextEffects1 = responsiveSliderSettings.TextEffects1;
            model.Media1 = responsiveSliderSettings.Media1;
            model.MediaEffects1 = responsiveSliderSettings.MediaEffects1;


            model.Picture2Url = _pictureService.GetPictureUrl(responsiveSliderSettings.Picture2Url, showDefaultPicture: false);
            model.PictureThumb2Url = _pictureService.GetPictureUrl(responsiveSliderSettings.PictureThumb2Url, showDefaultPicture: false);
            model.Text2 = responsiveSliderSettings.Text2;
            model.Link2 = responsiveSliderSettings.Link2;
            model.TitleText2 = responsiveSliderSettings.TitleText2;
            model.TitleTextEffects2 = responsiveSliderSettings.TitleTextEffects2;
            model.SubTitleText2 = responsiveSliderSettings.SubTitleText2;
            model.SubTitleTextEffects2 = responsiveSliderSettings.SubTitleTextEffects2;

            model.TextEffects2 = responsiveSliderSettings.TextEffects2;
            model.Media2 = responsiveSliderSettings.Media2;
            model.MediaEffects2 = responsiveSliderSettings.MediaEffects2;

            model.Picture3Url = _pictureService.GetPictureUrl(responsiveSliderSettings.Picture3Url, showDefaultPicture: false);
            model.PictureThumb3Url = _pictureService.GetPictureUrl(responsiveSliderSettings.PictureThumb3Url, showDefaultPicture: false);
            model.Text3 = responsiveSliderSettings.Text3;
            model.Link3 = responsiveSliderSettings.Link3;
            model.TitleText3 = responsiveSliderSettings.TitleText3;
            model.TitleTextEffects3 = responsiveSliderSettings.TitleTextEffects3;
            model.SubTitleText3 = responsiveSliderSettings.SubTitleText3;
            model.SubTitleTextEffects3 = responsiveSliderSettings.SubTitleTextEffects3;

            model.TextEffects3 = responsiveSliderSettings.TextEffects3;
            model.Media3 = responsiveSliderSettings.Media3;
            model.MediaEffects3 = responsiveSliderSettings.MediaEffects3;

            model.Picture4Url = _pictureService.GetPictureUrl(responsiveSliderSettings.Picture4Url, showDefaultPicture: false);
            model.PictureThumb4Url = _pictureService.GetPictureUrl(responsiveSliderSettings.PictureThumb4Url, showDefaultPicture: false);
            model.Text4 = responsiveSliderSettings.Text4;
            model.Link4 = responsiveSliderSettings.Link4;
            model.TitleText4 = responsiveSliderSettings.TitleText4;
            model.TitleTextEffects4 = responsiveSliderSettings.TitleTextEffects4;
            model.SubTitleText4 = responsiveSliderSettings.SubTitleText4;
            model.SubTitleTextEffects4 = responsiveSliderSettings.SubTitleTextEffects4;

            model.TextEffects4 = responsiveSliderSettings.TextEffects4;
            model.Media4 = responsiveSliderSettings.Media4;
            model.MediaEffects4 = responsiveSliderSettings.MediaEffects4;

            model.BannerPicture1Url = _pictureService.GetPictureUrl(responsiveSliderSettings.BannerPicture1Url, showDefaultPicture: false);
            model.BannerText1 = responsiveSliderSettings.BannerText1;
            model.BannerAltText1 = responsiveSliderSettings.BannerAltText1;
            model.BannerLink1 = responsiveSliderSettings.BannerLink1;

            model.BannerPicture2Url = _pictureService.GetPictureUrl(responsiveSliderSettings.BannerPicture2Url, showDefaultPicture: false);
            model.BannerText2 = responsiveSliderSettings.BannerText2;
            model.BannerAltText2 = responsiveSliderSettings.BannerAltText2;
            model.BannerLink2 = responsiveSliderSettings.BannerLink2;

            model.BannerPicture3Url = _pictureService.GetPictureUrl(responsiveSliderSettings.BannerPicture3Url, showDefaultPicture: false);
            model.BannerText3 = responsiveSliderSettings.BannerText3;
            model.BannerAltText3 = responsiveSliderSettings.BannerAltText3;
            model.BannerLink3 = responsiveSliderSettings.BannerLink3;

            model.BannerPicture4Url = _pictureService.GetPictureUrl(responsiveSliderSettings.BannerPicture4Url, showDefaultPicture: false);
            model.BannerText4 = responsiveSliderSettings.BannerText4;
            model.BannerAltText4 = responsiveSliderSettings.BannerAltText4;
            model.BannerLink4 = responsiveSliderSettings.BannerLink4;


            //properties
            model.MaxWidth = responsiveSliderSettings.MaxWidth;
            model.Nav = responsiveSliderSettings.Nav;
            model.Pager = responsiveSliderSettings.Pager;
            model.ManualControls = responsiveSliderSettings.ManualControls;

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url))
                //no pictures uploaded
                return Content("");


            return View("~/Plugins/Widgets.ResponsiveSlider/Views/WidgetsResponsiveSlider/PublicInfo.cshtml", model);
        }
    }
}