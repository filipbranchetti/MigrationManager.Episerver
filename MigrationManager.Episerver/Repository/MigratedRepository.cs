namespace MigrationManager.Episerver.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using EPiServer.Data.Dynamic;
    using Extensions;
    using Migration;
    using MigrationManager.Repository;
    using MigrationManager.Repository.Models;
    using Store;

    public class MigratedRepository : IMigratedRepository
    {
        private static DynamicDataStore MigrationStore => typeof(MigrationData).GetStore();

        public bool HasBeenRun(IMigrationStep migrationStep)
        {
            var items = GetAll();
            return items.Any(x => x.MigrationId == migrationStep.Id && MigrationStatus.HasBeenRunned.Equals(x.Status));
        }

        public void MarkAsRunned(IMigrationStep migrationStep)
        {
            var items = MigrationStore.Items<MigrationData>();
            var item = items.FirstOrDefault(x => x.MigrationId == migrationStep.Id) ?? migrationStep.ConvertToMigrationData();

            item.ExecutedDateTime = DateTime.UtcNow;
            MigrationStore.Save(item);
        }
        public void MarkAsNotRunned(IMigrationStep migrationStep)
        {
            var items = MigrationStore.Items<MigrationData>();
            var item = items.FirstOrDefault(x => x.MigrationId == migrationStep.Id);
            if (item != null)
            {
                MigrationStore.Delete(item);
            }
        }

        public IList<IDiscoveredMigration> GetAll()
        {
            var items = MigrationStore.Items<MigrationData>().ToList();
            return items.Select(MigrationExtensions.ConvertToDiscoveredMigration).OrderByDescending(x => x.Order).ToList();
        }

       
    }
}