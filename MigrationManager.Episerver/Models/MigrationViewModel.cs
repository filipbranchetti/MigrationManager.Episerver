namespace MigrationManager.Episerver.Models
{
    using System.Collections.Generic;
    using MigrationManager.Repository.Models;

    public class MigrationViewModel
    {
        public List<IDiscoveredMigration> Migrations { get; set; } = new List<IDiscoveredMigration>();
    }
}