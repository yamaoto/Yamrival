using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Yamrival.Api.Infrastructure;
using Yamrival.Api.Models;

namespace Yamrival.Api.Services
{
    public class TestMetadataService : ITestMetadataService
    {
        private readonly AppOptions _options;

        public TestMetadataService(IOptions<AppOptions> options)
        {
            _options = options.Value;
        }

        public async Task<TestCollectionModel> GetTestCollectionAsync()
        {
            var result = new TestCollectionModel();
            var files  = Directory.GetFiles(_options.TestCollectionPath, "*.json");
            foreach (var file in files)
            {
                var jsonContent = await File.ReadAllTextAsync(file);
                var test = JsonSerializer.Deserialize<TestModel>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                result.Add(test);
            }
            
            return result;
        }
    }
}