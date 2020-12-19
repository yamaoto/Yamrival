using System.Threading.Tasks;
using Yamrival.Api.Models;

namespace Yamrival.Api.Services
{
    public interface ITestMetadataService
    {
        Task<TestCollectionModel> GetTestCollectionAsync();
    }
}