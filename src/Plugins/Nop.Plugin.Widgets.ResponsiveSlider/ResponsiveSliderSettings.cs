using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using System.Collections.Generic;
using Nop.Core.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Widgets.ResponsiveSlider
{
    public class ResponsiveSliderSettings : ISettings
    {
        public int Picture1Url { get; set; }
        public int PictureThumb1Url { get; set; }
        public string Text1 { get; set; }
        public string Link1 { get; set; }
        //----------------------------------------------
        public string TitleText1 { get; set; }
        public string TitleTextEffects1 { get; set; }
        public string SubTitleText1 { get; set; }
        public string SubTitleTextEffects1 { get; set; }
        public string TextEffects1 { get; set; }
        public string Media1 { get; set; }
        public string MediaEffects1 { get; set; }
        //-----------------------------------------------
        public int Picture2Url { get; set; }
        public int PictureThumb2Url { get; set; }
        public string Text2 { get; set; }
        public string Link2 { get; set; }
        //----------------------------------------------
        public string TitleText2 { get; set; }
        public string TitleTextEffects2 { get; set; }
        public string SubTitleText2 { get; set; }
        public string SubTitleTextEffects2 { get; set; }
        public string TextEffects2 { get; set; }
        public string Media2 { get; set; }
        public string MediaEffects2 { get; set; }
        //----------------------------------------------

        public int Picture3Url { get; set; }
        public int PictureThumb3Url { get; set; }
        public string Text3 { get; set; }
        public string Link3 { get; set; }
        //----------------------------------------------
        public string TitleText3 { get; set; }
        public string TitleTextEffects3 { get; set; }
        public string SubTitleText3 { get; set; }
        public string SubTitleTextEffects3 { get; set; }
        public string TextEffects3 { get; set; }
        public string Media3 { get; set; }
        public string MediaEffects3 { get; set; }
        //----------------------------------------------
        public int Picture4Url { get; set; }
        public int PictureThumb4Url { get; set; }
        public string Text4 { get; set; }
        public string Link4 { get; set; }
        //----------------------------------------------
        public string TitleText4 { get; set; }
        public string TitleTextEffects4 { get; set; }
        public string SubTitleText4 { get; set; }
        public string SubTitleTextEffects4 { get; set; }
        public string TextEffects4 { get; set; }
        public string Media4 { get; set; }
        public string MediaEffects4 { get; set; }
        //----------------------------------------------

        //banners
        public int BannerPicture1Url { get; set; }
        public string BannerText1 { get; set; }
        public string BannerAltText1 { get; set; }
        public string BannerLink1 { get; set; }

        public int BannerPicture2Url { get; set; }
        public string BannerText2 { get; set; }
        public string BannerAltText2 { get; set; }
        public string BannerLink2 { get; set; }

        public int BannerPicture3Url { get; set; }
        public string BannerText3 { get; set; }
        public string BannerAltText3 { get; set; }
        public string BannerLink3 { get; set; }

        public int BannerPicture4Url { get; set; }
        public string BannerText4 { get; set; }
        public string BannerAltText4 { get; set; }
        public string BannerLink4 { get; set; }

        //properties
        public int MaxWidth { get; set; }
        public bool Nav { get; set; }
        public bool Pager { get; set; }
        public bool ManualControls { get; set; }
        

    }
}