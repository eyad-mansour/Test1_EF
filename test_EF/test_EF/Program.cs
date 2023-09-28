using Microsoft.EntityFrameworkCore;
using test_EF.Data;

namespace test_EF;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        
        string connectionsString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connectionsString));

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}

