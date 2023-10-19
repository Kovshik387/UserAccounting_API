using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccounting.DAL.EF
{
    internal sealed class UserModuleFactory : IDesignTimeDbContextFactory<UserModuleContext>
    {
        public UserModuleFactory() : base() { }
        public UserModuleContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<UserModuleContext>();
            optionBuilder.UseNpgsql("Host=localhost;Database=vgtucontest;Username=postgres;Password=prolodgy778");

            return new UserModuleContext(optionBuilder.Options);
        }
    }
}
