using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.ResponsiveSlider.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public ConfigurationModel()
        {
        }
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Picture")]
        [UIHint("Picture")]
        public int Picture1Url { get; set; }
        public bool Picture1Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.PictureThumb")]
        [UIHint("Picture")]
        public int PictureThumb1Url { get; set; }
        public bool PictureThumb1Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Text")]
        [AllowHtml]
        public string Text1 { get; set; }
        public bool Text1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Link")]
        [AllowHtml]
        public string Link1 { get; set; }
        public bool Link1_OverrideForStore { get; set; }

        //--------------------------------------------------------------------
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleText")]
        [AllowHtml]
        public string TitleText1 { get; set; }
        public bool TitleText1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleTextEffects")]
        [AllowHtml]
        public string TitleTextEffects1 { get; set; }
        public bool TitleTextEffects1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleText")]
        [AllowHtml]
        public string SubTitleText1 { get; set; }
        public bool SubTitleText1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleTextEffects")]
        [AllowHtml]
        public string SubTitleTextEffects1 { get; set; }
        public bool SubTitleTextEffects1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TextEffects")]
        [AllowHtml]
        public string TextEffects1 { get; set; }
        public bool TextEffects1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Media")]
        [AllowHtml]
        public string Media1 { get; set; }
        public bool Media1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.MediaEffects")]
        [AllowHtml]
        public string MediaEffects1 { get; set; }
        public bool MediaEffects1_OverrideForStore { get; set; }       
        //--------------------------------------------------------------------

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Picture")]
        [UIHint("Picture")]
        public int Picture2Url { get; set; }
        public bool Picture2Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.PictureThumb")]
        [UIHint("Picture")]
        public int PictureThumb2Url { get; set; }
        public bool PictureThumb2Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Text")]
        [AllowHtml]
        public string Text2 { get; set; }
        public bool Text2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Link")]
        [AllowHtml]
        public string Link2 { get; set; }
        public bool Link2_OverrideForStore { get; set; }
        //--------------------------------------------------------------------
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleText")]
        [AllowHtml]
        public string TitleText2 { get; set; }
        public bool TitleText2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleTextEffects")]
        [AllowHtml]
        public string TitleTextEffects2 { get; set; }
        public bool TitleTextEffects2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleText")]
        [AllowHtml]
        public string SubTitleText2 { get; set; }
        public bool SubTitleText2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleTextEffects")]
        [AllowHtml]
        public string SubTitleTextEffects2 { get; set; }
        public bool SubTitleTextEffects2_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TextEffects")]
        [AllowHtml]
        public string TextEffects2 { get; set; }
        public bool TextEffects2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Media")]
        [AllowHtml]
        public string Media2 { get; set; }
        public bool Media2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.MediaEffects")]
        [AllowHtml]
        public string MediaEffects2 { get; set; }
        public bool MediaEffects2_OverrideForStore { get; set; }
        //--------------------------------------------------------------------

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Picture")]
        [UIHint("Picture")]
        public int Picture3Url { get; set; }
        public bool Picture3Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.PictureThumb")]
        [UIHint("Picture")]
        public int PictureThumb3Url { get; set; }
        public bool PictureThumb3Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Text")]
        [AllowHtml]
        public string Text3 { get; set; }
        public bool Text3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Link")]
        [AllowHtml]
        public string Link3 { get; set; }
        public bool Link3_OverrideForStore { get; set; }
        //--------------------------------------------------------------------
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleText")]
        [AllowHtml]
        public string TitleText3 { get; set; }
        public bool TitleText3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleTextEffects")]
        [AllowHtml]
        public string TitleTextEffects3 { get; set; }
        public bool TitleTextEffects3_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleText")]
        [AllowHtml]
        public string SubTitleText3 { get; set; }
        public bool SubTitleText3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleTextEffects")]
        [AllowHtml]
        public string SubTitleTextEffects3 { get; set; }
        public bool SubTitleTextEffects3_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TextEffects")]
        [AllowHtml]
        public string TextEffects3 { get; set; }
        public bool TextEffects3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Media")]
        [AllowHtml]
        public string Media3 { get; set; }
        public bool Media3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.MediaEffects")]
        [AllowHtml]
        public string MediaEffects3 { get; set; }
        public bool MediaEffects3_OverrideForStore { get; set; }
        //--------------------------------------------------------------------

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Picture")]
        [UIHint("Picture")]
        public int Picture4Url { get; set; }
        public bool Picture4Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.PictureThumb")]
        [UIHint("Picture")]
        public int PictureThumb4Url { get; set; }
        public bool PictureThumb4Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Text")]
        [AllowHtml]
        public string Text4 { get; set; }
        public bool Text4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Link")]
        [AllowHtml]
        public string Link4 { get; set; }
        public bool Link4_OverrideForStore { get; set; }
        //--------------------------------------------------------------------
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleText")]
        [AllowHtml]
        public string TitleText4 { get; set; }
        public bool TitleText4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TitleTextEffects")]
        [AllowHtml]
        public string TitleTextEffects4 { get; set; }
        public bool TitleTextEffects4_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleText")]
        [AllowHtml]
        public string SubTitleText4 { get; set; }
        public bool SubTitleText4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.SubTitleTextEffects")]
        [AllowHtml]
        public string SubTitleTextEffects4 { get; set; }
        public bool SubTitleTextEffects4_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.TextEffects")]
        [AllowHtml]
        public string TextEffects4 { get; set; }
        public bool TextEffects4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Media")]
        [AllowHtml]
        public string Media4 { get; set; }
        public bool Media4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.MediaEffects")]
        [AllowHtml]
        public string MediaEffects4 { get; set; }
        public bool MediaEffects4_OverrideForStore { get; set; }
        //--------------------------------------------------------------------

        //banners
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerPicture")]
        [UIHint("Picture")]
        public int BannerPicture1Url { get; set; }
        public bool BannerPicture1Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerText")]      
        [AllowHtml]
        public string BannerText1 { get; set; }
        public bool BannerText1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerAltText")]
        [AllowHtml]
        public string BannerAltText1 { get; set; }
        public bool BannerAltText1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerLink")]
        [AllowHtml]
        public string BannerLink1 { get; set; }
        public bool BannerLink1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerPicture")]
        [UIHint("Picture")]
        public int BannerPicture2Url { get; set; }
        public bool BannerPicture2Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerText")]
        [AllowHtml]
        public string BannerText2 { get; set; }
        public bool BannerText2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerAltText")]
        [AllowHtml]
        public string BannerAltText2 { get; set; }
        public bool BannerAltText2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerLink")]
        [AllowHtml]
        public string BannerLink2 { get; set; }
        public bool BannerLink2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerPicture")]
        [UIHint("Picture")]
        public int BannerPicture3Url { get; set; }
        public bool BannerPicture3Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerText")]
        [AllowHtml]
        public string BannerText3 { get; set; }
        public bool BannerText3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerAltText")]
        [AllowHtml]
        public string BannerAltText3 { get; set; }
        public bool BannerAltText3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerLink")]
        [AllowHtml]
        public string BannerLink3 { get; set; }
        public bool BannerLink3_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerPicture")]
        [UIHint("Picture")]
        public int BannerPicture4Url { get; set; }
        public bool BannerPicture4Url_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerText")]
        [AllowHtml]
        public string BannerText4 { get; set; }
        public bool BannerText4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerAltText")]
        [AllowHtml]
        public string BannerAltText4 { get; set; }
        public bool BannerAltText4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.BannerLink")]
        [AllowHtml]
        public string BannerLink4 { get; set; }
        public bool BannerLink4_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.MaxWidth")]
        [AllowHtml]
        public int MaxWidth { get; set; }
        public bool MaxWidth_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Nav")]
        [AllowHtml]
        public bool Nav { get; set; }
        public bool Nav_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.Pager")]
        [AllowHtml]
        public bool Pager { get; set; }
        public bool Pager_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.ResponsiveSlider.ManualControls")]
        [AllowHtml]
        public bool ManualControls { get; set; }
        public bool ManualControls_OverrideForStore { get; set; }
    }
}