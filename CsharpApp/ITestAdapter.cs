using System;

namespace CsharpApp
{
    public interface ITestAdapter
    {
        Type GetDataTypeArgument();
        (bool, string) Run<T>(TestCaseMetadata<T> testCase);
    }
}