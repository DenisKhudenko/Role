using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RoleWeb.DAL.Extensions;

public static class ApplicationExtensions
{
    public static IApplicationBuilder UseRoleWeb(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        scope.ServiceProvider.GetRequiredService<AppDBContext>().Database.Migrate();

        return app;
    }
}