using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Yamrival.Api.Models;
using Yamrival.Api.Services;

namespace Yamrival.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RivalController : ControllerBase
    {
        private readonly ILogger<RivalController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly ITestMetadataService _testMetadataService;

        public RivalController(
            ILogger<RivalController> logger,
            IMemoryCache memoryCache,
            ITestMetadataService testMetadataService)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _testMetadataService = testMetadataService;
        }

        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<TestCollectionModel> Get()
        {
            var tests = _memoryCache.Get<TestCollectionModel>(nameof(TestCollectionModel));
            if (tests == null)
            {
                tests = await _testMetadataService.GetTestCollectionAsync();
                _memoryCache.Set(nameof(TestCollectionModel), tests);
            }
            return tests;
        }
    }
}