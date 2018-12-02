namespace MigrationManager.Episerver.Repository.Store
{
    using System;
    using EPiServer.Data;
    using EPiServer.Data.Dynamic;

    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class MigrationData 
    {
        [EPiServerDataIndex]
        public Identity Id { get; set; }
        public Guid MigrationId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public DateTime ExecutedDateTime { get; set; }
    }
}
