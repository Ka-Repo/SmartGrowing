using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;
using xamarin_app.Helpers;
using xamarin_app.Models;

namespace xamarin_app.Services
{
    public class CosmosDBService
    {
        static DocumentClient docClient = null;

        static readonly string databaseName = "Tasks";
        static readonly string collectionName = "Plants";

        static async Task<bool> Initialize()
        {
            if (docClient != null)
                return true;

            try
            {
                docClient = new DocumentClient(new Uri(Constants.CosmosEndpointUrl), Constants.CosmosAuthKey);

                // Create the database - this can also be done through the portal
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Create the collection - make sure to specify the RUs - has pricing implications
                // This can also be done through the portal

                await docClient.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = collectionName },
                    new RequestOptions { OfferThroughput = 400 }
                );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                docClient = null;

                return false;
            }

            return true;
        }

        public async static Task<List<Plant>> GetPlants()
        {
            var plants = new List<Plant>();

            if (!await Initialize())
                return plants;

            var todoQuery = docClient.CreateDocumentQuery<Plant>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(plant => plant.Id != "12")
                .AsDocumentQuery();

            while (todoQuery.HasMoreResults)
            {
                var queryResults = await todoQuery.ExecuteNextAsync<Plant>();

                plants.AddRange(queryResults);
            }

            return plants;
        }

        public async static Task AddPlant(Plant plant)
        {
            if (!await Initialize())
                return;

            await docClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                plant);
        }

        public async static Task UpdatePlant(Plant plant)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, plant.Id);
            await docClient.ReplaceDocumentAsync(docUri, plant);
        }

        public async static Task DeletePlant(Plant plant)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, plant.Id);
            await docClient.DeleteDocumentAsync(docUri);
        }
    }
}
