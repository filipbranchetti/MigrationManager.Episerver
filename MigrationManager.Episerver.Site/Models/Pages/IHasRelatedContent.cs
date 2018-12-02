using EPiServer.Core;

namespace MigrationManager.Episerver.Site.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
