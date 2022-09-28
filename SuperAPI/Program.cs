//https://code-maze.com/aspnetcore-webapi-best-practices/

namespace SuperAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddSuper();
            var app = builder.Build();
            app.UseSuper();
            app.Run();
        }
    }
}