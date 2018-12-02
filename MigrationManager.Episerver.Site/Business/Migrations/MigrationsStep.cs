namespace MigrationManager.Episerver.Site.Business.Migrations
{
    using System;
    using Migration;

    internal class MigrationsStep : IMigrationStep
    {
        public Guid Id => new Guid("DA4AC5BB-435C-49D0-AE51-6D3A2B6186BB");
        public int Order => 1;
        public string Name => "First Migration";
        public string Description => "description";

        public void Up()
        {
            //do nothing
        }

        public void Down()
        {
            //do nothing
        }
    }
}