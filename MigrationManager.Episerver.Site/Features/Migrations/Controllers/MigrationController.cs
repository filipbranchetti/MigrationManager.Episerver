namespace MigrationManager.Episerver.Site.Features.Migrations.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.SessionState;
    using EPiServer.PlugIn;
    using MigrationManager.Repository.Models;
    using Models;
    using Services;

    [SessionState(SessionStateBehavior.ReadOnly)]
    [GuiPlugIn(
        Area = PlugInArea.AdminMenu, 
        Url = "/Migration/Index", 
        DisplayName = "Migration manager", 
        SortIndex = 1)]
    [Authorize(Roles = "CmsAdmins")]
    public class MigrationController : Controller
    {
        private readonly MigrationService _migrationService;

        public MigrationController(MigrationService migrationService)
        {
            _migrationService = migrationService;
        }

        public ActionResult Index()
        {
            var model = new MigrationViewModel {Migrations = GetMigrations()};
            return View("/Features/Migrations/Views/Index.cshtml",model);
        }

        [HttpPost]
        public ActionResult Down(string id)
        {
            var guid = Guid.Parse(id);
            var migration = _migrationService.GetMigration(guid);
            if (migration != null)
            {
                _migrationService.Down(migration);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Up(string id)
        {
            var guid = Guid.Parse(id);
            var migration = _migrationService.GetMigration(guid);
            if (migration != null)
            {
                _migrationService.Up(migration);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RunAll()
        {
            _migrationService.UpAll();
            return RedirectToAction("Index");
        }

        private List<IDiscoveredMigration> GetMigrations()
        {
            return _migrationService.GetAllMigrationSteps().ToList();
        }
    }
}
