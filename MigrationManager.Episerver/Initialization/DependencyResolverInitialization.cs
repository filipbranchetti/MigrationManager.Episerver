namespace MigrationManager.Episerver.Initialization
{
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    using EPiServer.ServiceLocation;
    using Finder;
    using MigrationManager.Repository;
    using Repository;
    using Services;

    [InitializableModule]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            //Implementations for custom interfaces can be registered here.

            context.ConfigurationComplete += (o, e) =>
            {
                //Register custom implementations that should be used in favour of the default implementations
                context.Services
                    .AddSingleton<IMigrationFinder, MigrationFinder>()
                    .AddTransient<MigrationService, MigrationService>()
                    .AddTransient<IMigratedRepository, MigratedRepository>();
            };
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
