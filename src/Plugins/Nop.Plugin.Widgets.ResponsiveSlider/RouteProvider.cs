using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Widgets.ResponsiveSlider
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Widgets.ResponsiveSlider.Configure",
                 "Plugins/WidgetsResponsiveSlider/Configure",
                 new { controller = "WidgetsResponsiveSlider", action = "Configure" },
                 new[] { "Nop.Plugin.Widgets.ResponsiveSlider.Controllers" }
            );

            routes.MapRoute("Plugin.Widgets.ResponsiveSlider.PublicInfo",
                 "Plugins/WidgetsResponsiveSlider/PublicInfo",
                 new { controller = "WidgetsResponsiveSlider", action = "PublicInfo" },
                 new[] { "Nop.Plugin.Widgets.ResponsiveSlider.Controllers" }
            );
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
