using System;
using System.Collections.Generic;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.MegaMenu.Models
{
    public class PublicInfoModel : BaseNopModel, ICloneable
    {
        public PublicInfoModel()
        {
            Categories = new List<CategoryModel>();
        }
        public bool IncludeCategoriesInMenu { get; set; }
        public bool DisplaySubcategories { get; set; }
        public bool DisplayHomePage { get; set; }
        public bool EnableResponsiveMenu { get; set; }
        public int ColumnsNumber { get; set; }
        public string CustomItems { get; set; }
        public int CurrentCategoryId { get; set; }
        public List<CategoryModel> Categories { get; set; }

        //background images for Sub menu
        public string BgPicture1Url { get; set; }
        public string BgPicture2Url { get; set; }
        public string BgPicture3Url { get; set; }
        public string BgPicture4Url { get; set; }
        public string BgPicture5Url { get; set; }

        public object Clone()
        {
            //we use a shallow copy (deep clone is not required here)
            return this.MemberwiseClone();
        }

        public class CategoryModel : BaseNopEntityModel
        {
            public CategoryModel()
            {
                SubCategories = new List<CategoryModel>();
            }

            public string Name { get; set; }

            public string SeName { get; set; }

            public int? NumberOfProducts { get; set; }

            public List<CategoryModel> SubCategories { get; set; }
        }
    }
}