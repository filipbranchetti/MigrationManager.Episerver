namespace MigrationManager.Episerver.Site.Features.Migrations.Initialization
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;

    [InitializableModule]
    public class MigrationManagerRouteInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapRoute(
                null,
                "Migration/Index",
                new { controller = "Migration", action = "Index" });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}