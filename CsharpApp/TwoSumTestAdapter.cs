using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace CsharpApp
{
    public class TwoSumTestAdapter : ITestAdapter
    {
        public Type GetDataTypeArgument() => typeof(TwoSumData);

        public (bool, string) Run<T>(TestCaseMetadata<T> testCase)
        {
            return Run(testCase as TestCaseMetadata<TwoSumData>);
        }
        public (bool, string) Run(TestCaseMetadata<TwoSumData> testCase)
        {
            var testInstance = new TestCode();
            var actual = testInstance.TwoSum(testCase.Data.ArgumentNums, testCase.Data.ArgumentTarget);
            if ((actual[0] != testCase.Data.Result[0] || actual[1] != testCase.Data.Result[1]) && (actual[1] != testCase.Data.Result[0] || actual[0] != testCase.Data.Result[1]))
                return (false, "");
            return (true, null);
        }

        public class TwoSumData
        {
            public int[] ArgumentNums { get; set; }
            public int ArgumentTarget { get; set; }
            public int[] Result { get; set; }
        }
    }
}