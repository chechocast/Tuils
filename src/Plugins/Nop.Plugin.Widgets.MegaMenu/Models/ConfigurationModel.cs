using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.MegaMenu.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.EnableMenu")]
        public bool EnableMenu { get; set; }
        public bool EnableMenu_OverrideForStore { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.EnableResponsiveMenu")]
        public bool EnableResponsiveMenu { get; set; }
        public bool EnableResponsiveMenu_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.DisplaySubcategories")]
        public bool DisplaySubcategories { get; set; }
        public bool DisplaySubcategories_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.DisplayHomePage")]
        public bool DisplayHomePage { get; set; }
        public bool DisplayHomePage_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.IncludeCategoriesInMenu")]
        public bool IncludeCategoriesInMenu { get; set; }
        public bool IncludeCategoriesInMenu_OverrideForStore { get; set; }
       
        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.ColumnsNumber")]
        public int ColumnsNumber { get; set; }
        public bool ColumnsNumber_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.CustomItems")]
        [AllowHtml]
        public string CustomItems { get; set; }
        public bool CustomItems_OverrideForStore { get; set; }

        //background images for Sub menu
        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.BgPicture1")]
        [UIHint("Picture")]
        public int BgPicture1Url { get; set; }
        public bool BgPicture1Url_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.BgPicture2")]
        [UIHint("Picture")]
        public int BgPicture2Url { get; set; }
        public bool BgPicture2Url_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.BgPicture3")]
        [UIHint("Picture")]
        public int BgPicture3Url { get; set; }
        public bool BgPicture3Url_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.BgPicture4")]
        [UIHint("Picture")]
        public int BgPicture4Url { get; set; }
        public bool BgPicture4Url_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.MegaMenu.BgPicture5")]
        [UIHint("Picture")]
        public int BgPicture5Url { get; set; }
        public bool BgPicture5Url_OverrideForStore { get; set; }
    }
}