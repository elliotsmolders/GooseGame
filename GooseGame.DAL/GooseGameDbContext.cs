using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL
{
    internal class GooseGameDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            ILoggerFactory fakeFactory = new ILoggerProvider();
            options.UseLoggerFactory(fakeFactory);
        }
    }
}