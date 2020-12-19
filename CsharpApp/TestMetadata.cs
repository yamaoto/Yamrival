namespace CsharpApp
{
    public class TestMetadata
    {
        public string Name { get; set; }
    }
    public class TestMetadata <T> : TestMetadata
    {
        public TestCaseMetadata<T>[] TestCases { get; set; }
    }
}