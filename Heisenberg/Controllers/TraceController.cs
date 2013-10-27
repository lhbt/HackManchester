using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Heisenberg.Domain.Interfaces;
using Newtonsoft.Json;

namespace Heisenberg.Controllers
{
    public class TraceController : ApiController
    {
        private readonly ITracer _tracer;

        public TraceController(ITracer tracer)
        {
            _tracer = tracer;
        }

        public TraceResponse DbTest()
        {
            IEnumerable<string> result = _tracer.DbConnectionCheck();

            return new TraceResponse {TestGuids = result.ToList()};
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TraceResponse
    {
        public TraceResponse()
        {
            TestGuids = new List<string>();
        }

        [JsonProperty("TestGuids")]
        public List<string> TestGuids;
    }
}
