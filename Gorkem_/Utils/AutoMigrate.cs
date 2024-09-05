using Gorkem_.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gorkem_.Utils
{
    public static class AutoMigrate
    {
      public  static void ApplyMigration(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _Db = scope.ServiceProvider.GetRequiredService<GorkemDbContext>();
                if (_Db != null)
                {
                    if (_Db.Database.GetPendingMigrations().Any())
                    {
                        _Db.Database.Migrate();
                    }
                }
            }
        }

    }
}
