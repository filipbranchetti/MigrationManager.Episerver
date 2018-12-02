namespace MigrationManager.Episerver.Extensions
{
    using Enums;
    using Migration;
    using MigrationManager.Repository.Models;
    using Repository.Store;

    public static class MigrationExtensions
    {
        public static IDiscoveredMigration ConvertToDiscoveredMigration(this MigrationData migrationData)
        {
            return new DiscoveredMigration
            {
                MigrationId = migrationData.MigrationId,
                Name = migrationData.Name,
                Order = migrationData.Order,
                Description = migrationData.Description,
                ExecutedDateTime = migrationData.ExecutedDateTime,
                Status = MigrationStatus.HasBeenRunned
            };
        }

        public static MigrationData ConvertToMigrationData(this IMigrationStep migrationStep)
        {
            return new MigrationData
            {
                MigrationId = migrationStep.Id,
                Name = migrationStep.Name,
                Order = migrationStep.Order,
                Description = migrationStep.Description
            };
        }
    }
}