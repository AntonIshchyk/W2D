using AutoMapper;
using Backend.Data;
using Backend.Contracts.Posts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests.Services;

internal static class ServiceTestHelpers
{
    internal static AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"w2d-tests-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    internal static (AppDbContext Context, SqliteConnection Connection) CreateSqliteContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new AppDbContext(options);
        context.Database.EnsureCreated();

        return (context, connection);
    }

    internal static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(UpdatePostRequest).Assembly);
        });

        return config.CreateMapper();
    }
}
