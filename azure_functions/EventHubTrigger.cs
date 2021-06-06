using System;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace SmartGrowing.Function
{
    public class Plant
    {
        [JsonProperty("id")]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string temperature { get; set; }
        public string humidity { get; set; }
    }

    public static class EventHubTrigger
    {
        [FunctionName("EventHubTrigger")]
        public static void Run([EventHubTrigger("smartgrowingeventhub", Connection = "AzureEventHubConnectionString")] EventData[] events,
            [CosmosDB(
                databaseName: "Tasks",
                collectionName: "Plants",
                ConnectionStringSetting = "CosmosDBConnection",
                PartitionKey = "111")]out Plant item,
            ILogger log)
        {
            string temperature = "";
            string humidity = "";

            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    humidity = eventData.Body[0].ToString();
                    temperature = eventData.Body[1].ToString();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();

            item = new Plant { id = "1", name = "Plant 1", description = "Plant next to me.", humidity = humidity, temperature = temperature };
        }
    }
}
