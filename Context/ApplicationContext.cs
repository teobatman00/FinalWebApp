using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
            });
            return services.BuildServiceProvider().GetService<ILoggerFactory>();
        }
    }
}
