 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace TourInfo.Infrastracture.Repository.EFCore
{
    internal class TourInfoDesignTimeDbContextFactory : IDesignTimeDbContextFactory< TourInfoDbContext>
    {
         
        public TourInfoDbContext CreateDbContext(string[] args)
        {
            
            var builder = new DbContextOptionsBuilder<TourInfoDbContext>();
           // builder.UseSqlServer("server = (localdb)\\mssqllocaldb; database = yf; Integrated Security = SSPI; ");
            //builder.UseSqlite("Data Source=tourinfodb_backend.db3;");
            builder.UseSqlServer("server = 111.230.100.241; database = yf; uid=sa;pwd=!!Hn@nsn123; ");


            var context = new TourInfoDbContext(builder.Options);
            return context;
        }
    }
}
