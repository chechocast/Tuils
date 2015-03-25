
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.MegaMenu
{
    public class MegaMenuSettings : ISettings
    {
        public bool EnableMenu { get; set; }
        public bool IncludeCategoriesInMenu { get; set; }
        public bool DisplaySubcategories { get; set; }
        public bool DisplayHomePage { get; set; }
        public int ColumnsNumber { get; set; }
        public bool EnableResponsiveMenu { get; set; }
        public string CustomItems { get; set; }

        //background images for Sub menu
        public int BgPicture1Url { get; set; }
        public int BgPicture2Url { get; set; }
        public int BgPicture3Url { get; set; }
        public int BgPicture4Url { get; set; }
        public int BgPicture5Url { get; set; }
        
    }
}