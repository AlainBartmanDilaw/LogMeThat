using System;
using Serilog;

namespace LogMeThat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            try
            {
                // Your program here...
                const string name = "Serilog";
                Log.Information("Hello, {Name}!", name);
                throw new InvalidOperationException("Oops...");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception");
            }
            finally
            {
                Log.CloseAndFlush(); // ensure all logs written before app exits
            }
        }
    }
}
