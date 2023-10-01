using Microsoft.EntityFrameworkCore;
using test_EF.Data;
using test_EF.Models.Interfaces;
using test_EF.Models.Services;

namespace test_EF;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        
        string connectionsString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connectionsString));

        builder.Services.AddTransient<ICourse, CourseServices>();
        builder.Services.AddTransient<ITechnology, TechnologyServices>();
        builder.Services.AddTransient<IStudent, StudentServices>();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}

