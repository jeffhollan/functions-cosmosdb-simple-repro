using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Temp.CosmosDb
{
    public static class CosmosDbTest
    {
        [FunctionName("CosmosDbTest")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", "POST")]HttpRequest req,
            [CosmosDB("store", "test", ConnectionStringSetting = "CosmosDbConnection")] IAsyncCollector<object> docs, 
            TraceWriter log)
        {
            log.Info($"Fired");
            await docs.AddAsync(new {foo = "bar"});
        }
    }
}
