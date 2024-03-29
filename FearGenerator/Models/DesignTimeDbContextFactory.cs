using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FearGenerator.Models
{
  public class FearGeneratorContextFactory : IDesignTimeDbContextFactory<FearGeneratorContext>
  {

    FearGeneratorContext IDesignTimeDbContextFactory<FearGeneratorContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<FearGeneratorContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new FearGeneratorContext(builder.Options);
    }
  }
}