using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Widgets.MegaMenu
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Widgets.MegaMenu.Configure",
                 "Plugins/WidgetsMegaMenu/Configure",
                 new { controller = "WidgetsMegaMenu", action = "Configure" },
                 new[] { "Nop.Plugin.Widgets.MegaMenu.Controllers" }
            );

            routes.MapRoute("Plugin.Widgets.MegaMenu.PublicInfo",
                 "Plugins/WidgetsMegaMenu/PublicInfo",
                 new { controller = "WidgetsMegaMenu", action = "PublicInfo" },
                 new[] { "Nop.Plugin.Widgets.MegaMenu.Controllers" }
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
