﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TeduMicroservice.IDP.Infra;

public class TeduIdentityContextFactory: IDesignTimeDbContextFactory<TeduIdentityContext>
{
    public TeduIdentityContext CreateDbContext(string[] args)
    {
        // Load cấu hình từ appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TeduIdentityContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new TeduIdentityContext(optionsBuilder.Options);
    }
}