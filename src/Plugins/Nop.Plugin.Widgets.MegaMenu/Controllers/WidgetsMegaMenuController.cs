using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Seo;

using Nop.Web.Framework.Controllers;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain;
using Nop.Core.Domain.Catalog;
using Nop.Web;
using Nop.Web.Infrastructure.Cache;
using Nop.Plugin.Widgets.MegaMenu.Models;
using Nop.Services.Stores;


namespace Nop.Plugin.Widgets.MegaMenu.Controllers
{
    public class WidgetsMegaMenuController : BasePluginController
    {
        private readonly IPictureService _pictureService;
        private readonly MegaMenuSettings _menuSettings;
        private readonly ISettingService _settingService;
        private readonly IWorkContext _workContext;
        private readonly ICacheManager _cacheManager;
        private readonly ICategoryService _categoryService;
        private readonly IStoreService _storeService;
        private readonly IStoreContext _storeContext;


        public WidgetsMegaMenuController(ICategoryService categoryService, IPictureService pictureService,
            MegaMenuSettings menuSettings, ISettingService settingService, IWorkContext workContext, ICacheManager cacheManager, IStoreService storeService, IStoreContext storeContext)
        {
            this._pictureService = pictureService;
            this._menuSettings = menuSettings;
            this._settingService = settingService;
            this._workContext = workContext;
            this._cacheManager = cacheManager;
            this._categoryService = categoryService;
            this._storeService = storeService;
            this._storeContext = storeContext;
        }
        [NonAction]
        protected IList<PublicInfoModel.CategoryModel> PrepareCategoryNavigationModel(IPagedList<Category> categories, int catId = 0)
        {
            var result = new List<PublicInfoModel.CategoryModel>();
            if (categories != null)
            {
                var megaMenuSettings = _settingService.LoadSetting<MegaMenuSettings>(_storeContext.CurrentStore.Id);
                foreach (var category in categories.Where(c => c.ParentCategoryId == catId))
                {
                    if (category.IncludeInTopMenu)
                    {
                        var categoryModel = new PublicInfoModel.CategoryModel()
                        {
                            Id = category.Id,
                            Name = category.GetLocalized(x => x.Name),
                            SeName = category.GetSeName()
                        };

                        #region product number for each category
                        //product number for each category
                        //if (_catalogSettings.ShowCategoryProductNumber)
                        //{
                        //    var categoryIds = new List<int>();
                        //    categoryIds.Add(category.Id);
                        //    //include subcategories
                        //    if (_catalogSettings.ShowCategoryProductNumberIncludingSubcategories)
                        //        categoryIds.AddRange(GetChildCategoryIds(category.Id));
                        //    IList<int> filterableSpecificationAttributeOptionIds = null;
                        //    categoryModel.NumberOfProducts = _productService.SearchProducts(categoryIds,
                        //        0, null, null, null, 0, string.Empty, false, false, 0, null,
                        //        ProductSortingEnum.Position, 0, 1,
                        //        false, out filterableSpecificationAttributeOptionIds).TotalCount;
                        //}
                        #endregion

                        //subcategories
                        if (megaMenuSettings.DisplaySubcategories)
                            categoryModel.SubCategories.AddRange(PrepareCategoryNavigationModel(categories, category.Id));

                        result.Add(categoryModel);
                    }
                }
            }
            return result;
        }
        //protected IList<PublicInfoModel.CategoryModel> PrepareCategoryNavigationModel(IPagedList<Category> categories, int catId = 0)
        //{
        //    var result = new List<PublicInfoModel.CategoryModel>();
        //    if (categories != null)
        //    {
        //        var megaMenuSettings = _settingService.LoadSetting<MegaMenuSettings>(_storeContext.CurrentStore.Id);
        //        foreach (var category in categories.Where(c => c.ParentCategoryId == catId))
        //        {
        //            var categoryModel = new PublicInfoModel.CategoryModel()
        //            {
        //                Id = category.Id,
        //                Name = category.GetLocalized(x => x.Name),
        //                SeName = category.GetSeName()
        //            };

        //            #region product number for each category
        //            //product number for each category
        //            //if (_catalogSettings.ShowCategoryProductNumber)
        //            //{
        //            //    var categoryIds = new List<int>();
        //            //    categoryIds.Add(category.Id);
        //            //    //include subcategories
        //            //    if (_catalogSettings.ShowCategoryProductNumberIncludingSubcategories)
        //            //        categoryIds.AddRange(GetChildCategoryIds(category.Id));
        //            //    IList<int> filterableSpecificationAttributeOptionIds = null;
        //            //    categoryModel.NumberOfProducts = _productService.SearchProducts(categoryIds,
        //            //        0, null, null, null, 0, string.Empty, false, false, 0, null,
        //            //        ProductSortingEnum.Position, 0, 1,
        //            //        false, out filterableSpecificationAttributeOptionIds).TotalCount;
        //            //}
        //            #endregion

        //            //subcategories
        //            if (megaMenuSettings.DisplaySubcategories)
        //                categoryModel.SubCategories.AddRange(PrepareCategoryNavigationModel(categories, category.Id));

        //            result.Add(categoryModel);
        //        }
        //    }
        //    return result;
        //}

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var megaMenuSettings = _settingService.LoadSetting<MegaMenuSettings>(storeScope);

            var model = new ConfigurationModel();
            model.EnableMenu = megaMenuSettings.EnableMenu;
            model.EnableResponsiveMenu = megaMenuSettings.EnableResponsiveMenu;
            model.IncludeCategoriesInMenu = megaMenuSettings.IncludeCategoriesInMenu;
            model.DisplaySubcategories = megaMenuSettings.DisplaySubcategories;
            model.DisplayHomePage = megaMenuSettings.DisplayHomePage;
            model.ColumnsNumber = megaMenuSettings.ColumnsNumber;
            model.CustomItems = megaMenuSettings.CustomItems;

            model.BgPicture1Url = megaMenuSettings.BgPicture1Url;
            model.BgPicture2Url = megaMenuSettings.BgPicture2Url;
            model.BgPicture3Url = megaMenuSettings.BgPicture3Url;
            model.BgPicture4Url = megaMenuSettings.BgPicture4Url;
            model.BgPicture5Url = megaMenuSettings.BgPicture5Url;


            model.ActiveStoreScopeConfiguration = storeScope;
            if (storeScope > 0)
            {
                model.EnableMenu_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.EnableMenu, storeScope);
                model.EnableResponsiveMenu_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.EnableResponsiveMenu, storeScope);
                model.IncludeCategoriesInMenu_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.IncludeCategoriesInMenu, storeScope);
                model.DisplaySubcategories_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.DisplaySubcategories, storeScope);
                model.DisplayHomePage_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.DisplayHomePage, storeScope);

                model.ColumnsNumber_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.ColumnsNumber, storeScope);
                model.CustomItems_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.CustomItems, storeScope);

                model.BgPicture1Url_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.BgPicture1Url, storeScope);
                model.BgPicture2Url_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.BgPicture2Url, storeScope);
                model.BgPicture3Url_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.BgPicture3Url, storeScope);
                model.BgPicture4Url_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.BgPicture4Url, storeScope);
                model.BgPicture5Url_OverrideForStore = _settingService.SettingExists(megaMenuSettings, x => x.BgPicture5Url, storeScope);
            }
            return View("~/Plugins/Widgets.MegaMenu/Views/WidgetsMegaMenu/Configure.cshtml", model);

        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            //save settings
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var megaMenuSettings = _settingService.LoadSetting<MegaMenuSettings>(storeScope);

            megaMenuSettings.EnableMenu = model.EnableMenu;
            megaMenuSettings.EnableResponsiveMenu = model.EnableResponsiveMenu;
            megaMenuSettings.IncludeCategoriesInMenu = model.IncludeCategoriesInMenu;
            megaMenuSettings.DisplaySubcategories = model.DisplaySubcategories;
            megaMenuSettings.DisplayHomePage = model.DisplayHomePage;
            megaMenuSettings.ColumnsNumber = model.ColumnsNumber;
            megaMenuSettings.CustomItems = model.CustomItems;

            megaMenuSettings.BgPicture1Url = model.BgPicture1Url;
            megaMenuSettings.BgPicture2Url = model.BgPicture2Url;
            megaMenuSettings.BgPicture3Url = model.BgPicture3Url;
            megaMenuSettings.BgPicture4Url = model.BgPicture4Url;
            megaMenuSettings.BgPicture5Url = model.BgPicture5Url;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            if (model.EnableMenu_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.EnableMenu, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.EnableMenu, storeScope);
            if (model.EnableResponsiveMenu_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.EnableResponsiveMenu, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.EnableResponsiveMenu, storeScope);
            if (model.IncludeCategoriesInMenu_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.IncludeCategoriesInMenu, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.IncludeCategoriesInMenu, storeScope);
            if (model.DisplaySubcategories_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.DisplaySubcategories, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.DisplaySubcategories, storeScope);
            if (model.DisplayHomePage_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.DisplayHomePage, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.DisplayHomePage, storeScope);

            if (model.ColumnsNumber_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.ColumnsNumber, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.ColumnsNumber, storeScope);
            if (model.CustomItems_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.CustomItems, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.CustomItems, storeScope);


            if (model.BgPicture1Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.BgPicture1Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.BgPicture1Url, storeScope);
            if (model.BgPicture2Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.BgPicture2Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.BgPicture2Url, storeScope);
            if (model.BgPicture3Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.BgPicture3Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.BgPicture3Url, storeScope);
            if (model.BgPicture4Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.BgPicture4Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.BgPicture4Url, storeScope);
            if (model.BgPicture5Url_OverrideForStore || storeScope == 0)
                _settingService.SaveSetting(megaMenuSettings, x => x.BgPicture5Url, storeScope, false);
            else if (storeScope > 0)
                _settingService.DeleteSetting(megaMenuSettings, x => x.BgPicture5Url, storeScope);


            //now clear settings cache
            _settingService.ClearCache();

            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone)
        {
            var megaMenuSettings = _settingService.LoadSetting<MegaMenuSettings>(_storeContext.CurrentStore.Id);
            if (megaMenuSettings.EnableMenu)
            {

                //var customerRolesIds = _workContext.CurrentCustomer.CustomerRoles.Where(cr => cr.Active).Select(cr => cr.Id).ToList();
                //string cacheKey = string.Format(ModelCacheEventConsumer.CATEGORY_NAVIGATION_MODEL_KEY, _workContext.WorkingLanguage.Id, string.Join(",", customerRolesIds), _storeContext.CurrentStore.Id, 0);

                Stopwatch sw = Stopwatch.StartNew();
                IPagedList<Category> categories = null;
                if (megaMenuSettings.IncludeCategoriesInMenu)
                {
                    categories = _categoryService.GetAllCategories();
                }

                var model = new PublicInfoModel()
                {
                    EnableResponsiveMenu = megaMenuSettings.EnableResponsiveMenu,
                    Categories = PrepareCategoryNavigationModel(categories).ToList(),
                    ColumnsNumber = megaMenuSettings.ColumnsNumber,
                    DisplayHomePage = megaMenuSettings.DisplayHomePage,
                    CustomItems = megaMenuSettings.CustomItems,
                    BgPicture1Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture1Url, showDefaultPicture: false),
                    BgPicture2Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture2Url, showDefaultPicture: false),
                    BgPicture3Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture3Url, showDefaultPicture: false),
                    BgPicture4Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture4Url, showDefaultPicture: false),
                    BgPicture5Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture5Url, showDefaultPicture: false)
                };
                //var cachedModel = _cacheManager.Get(cacheKey, () =>
                //    new PublicInfoModel()
                //    {
                //        EnableResponsiveMenu = megaMenuSettings.EnableResponsiveMenu,
                //        Categories = PrepareCategoryNavigationModel(categories).ToList(),
                //        ColumnsNumber = megaMenuSettings.ColumnsNumber,
                //        DisplayHomePage = megaMenuSettings.DisplayHomePage,
                //        CustomItems = megaMenuSettings.CustomItems,
                //        BgPicture1Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture1Url, showDefaultPicture: false),
                //        BgPicture2Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture2Url, showDefaultPicture: false),
                //        BgPicture3Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture3Url, showDefaultPicture: false),
                //        BgPicture4Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture4Url, showDefaultPicture: false),
                //        BgPicture5Url = _pictureService.GetPictureUrl(megaMenuSettings.BgPicture5Url, showDefaultPicture: false)
                //    }
                //);
                //sw.Stop();
                //var test = sw.Elapsed.TotalMilliseconds;

                //"CurrentCategoryId" property of "CategoryNavigationModel" object depends on the current category or product.
                //We need to clone the cached model (the updated one should not be cached)
                //var model = (PublicInfoModel)cachedModel.Clone();

                return View("~/Plugins/Widgets.MegaMenu/Views/WidgetsMegaMenu/PublicInfo.cshtml", model);
            }
            else
            {
                return new EmptyResult();
            }
        }

    }
}