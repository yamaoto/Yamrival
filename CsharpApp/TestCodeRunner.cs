using System;
using System.Diagnostics;
using System.Linq;

namespace CsharpApp
{
    public class TestCodeRunner
    {
        private readonly ITestAdapter _testAdapter;

        public TestCodeRunner(ITestAdapter testAdapter)
        {
            _testAdapter = testAdapter;
        }
        public int Run<T>(TestMetadata<T> testMetadata)
        {
            foreach (var test in testMetadata.TestCases)
            {
                bool result;
                string errorDescription = null;
                var testName = test.Name;
                Console.WriteLine("TEST {0} RUN", testName);
                var watch = new Stopwatch();
                try
                {
                    watch.Start();
                    #region TestCodeRunner
                    // this region will be replaced
                    (result, errorDescription) = _testAdapter.Run<T>(test);
                    #endregion

                    watch.Stop();
                }
                catch (Exception exception)
                {
                    watch.Stop();
                    Console.WriteLine("TEST {0} Execution error: {1}", testName, exception.Message);
                    return 1;
                }
                if (!result)
                {
                    Console.WriteLine("TEST {0} FAILED: {1}", testName, errorDescription);
                    return 1;
                }
                var elapsedTime =
                    $"{watch.Elapsed.Hours:00}:{watch.Elapsed.Minutes:00}:{watch.Elapsed.Seconds:00}.{watch.Elapsed.Milliseconds:0000}";
                Console.WriteLine("TEST {0} PASS in {1}", testName, elapsedTime);
            }
            return 0;
        }
    }
}