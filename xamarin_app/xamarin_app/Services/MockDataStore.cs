using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xamarin_app.Models;

namespace xamarin_app.Services
{
    public class MockDataStore : IDataStore<Plant>
    {
        readonly List<Plant> plants;

        public MockDataStore()
        {
            plants = new List<Plant>()
            {
                new Plant { Id = Guid.NewGuid().ToString(), Name="Plant1", Description="This is an description for plant 1." , Humidity="12", Temperature="33" },
                new Plant { Id = Guid.NewGuid().ToString(), Name="Plant2", Description="This is an description for plant 2." , Humidity="132", Temperature="55" },
                new Plant { Id = Guid.NewGuid().ToString(), Name="Plant3", Description="This is an description for plant 3." , Humidity="22", Temperature="15" },
                new Plant { Id = Guid.NewGuid().ToString(), Name="Plant4", Description="This is an description for plant 4." , Humidity="92", Temperature="90" },
                new Plant { Id = Guid.NewGuid().ToString(), Name="Plant5", Description="This is an description for plant 5." , Humidity="133", Temperature="120" },
                new Plant { Id = Guid.NewGuid().ToString(), Name="Plant6", Description="This is an description for plant 6." , Humidity="100", Temperature="200" },
            };
        }

        public async Task<bool> AddItemAsync(Plant plant)
        {
            plants.Add(plant);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Plant plant)
        {
            var oldItem = plants.Where((Plant arg) => arg.Id == plant.Id).FirstOrDefault();
            plants.Remove(oldItem);
            plants.Add(plant);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = plants.Where((Plant arg) => arg.Id == id).FirstOrDefault();
            plants.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Plant> GetItemAsync(string id)
        {
            return await Task.FromResult(plants.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Plant>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(plants);
        }
    }
}