namespace CsharpApp
{
    public class TestCaseMetadata<T>
    {
        public string Name { get;set; }
        public bool IsPublic { get; set; }
        public T Data { get; set; }
    }
}