using System.Collections.Generic;

namespace Yamrival.Api.Models
{
    public class TestCollectionModel : List<TestModel>
    {
        
    }
    public class TestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TestCaseModel[] TestCases { get; set; }
    }
    public class TestCaseModel
    {
        public string Name { get;set; }
        public bool IsPublic { get; set; }
        public object Data { get; set; }
    }
}