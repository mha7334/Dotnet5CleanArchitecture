using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Xunit;

namespace CleanArchitecutre.Api.Tests
{
    public class ApTests
    {
        private readonly IConfiguration _configuration;

        public ApTests()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();


        }
        [Fact]
        public void Test1()
        {
            var conf = _configuration.GetConnectionString("MyDbConnection");

            Assert.True(conf.Contains("localdb"));
        }
    }
}
