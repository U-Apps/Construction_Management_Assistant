using ConstructionManagementAssistant.API.Controllers;
using ConstructionManagementAssistant.Core.Constants;
using ConstructionManagementAssistant.EF.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;

namespace ConstructionManagementAssistant.API.Startup;

public static class DbSchemaConfig
{
    public static void SetDbSchema(this WebApplication app)
    {
        try
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var schemaQuery = @"
            SELECT t.name AS TableName, c.name AS ColumnName
            FROM sys.tables t
            JOIN sys.columns c ON t.object_id = c.object_id
            ORDER BY t.name, c.column_id";

                // Use raw SQL to get schema rows
                var schemaRows = db.Database.SqlQueryRaw<SchemaRow>(schemaQuery).ToList();

                // Serialize to JSON and store globally
                ReportsController.dbSchema = JsonSerializer.Serialize(schemaRows);
                Log.Information("Database schema loaded and serialized successfully.");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while loading and serializing the database schema.");
        }
    }
}
