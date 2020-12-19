using System;
using System.IO;
using System.Text.Json;

namespace CsharpApp
{
    class Program
    {
        static int Main(string[] args)
        {
            var jsonContent = File.ReadAllText(args[0]);
            var adapterTypeName = args[1];
            var adapterType = Type.GetType(adapterTypeName, true);
            var adapter = (ITestAdapter) Activator.CreateInstance(adapterType);
            var runner= new TestCodeRunner(adapter);

            var testDataType = adapter.GetDataTypeArgument();

            var type = typeof(TestMetadata<>).MakeGenericType(testDataType);
            var testMetadata = JsonSerializer.Deserialize(jsonContent, type, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            var result = typeof(TestCodeRunner)
                .GetMethod("Run")
                .MakeGenericMethod(testDataType)
                .Invoke(runner, new[] {testMetadata});
            return (int) result;
        }
    }
}