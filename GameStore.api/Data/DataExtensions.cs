using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data;

public static class DataExtensions
{

    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        context.Database.Migrate();
    }
}