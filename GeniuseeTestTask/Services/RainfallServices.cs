using GeniuseeTestTask.Abstractions;
using GeniuseeTestTask.Data;
using Newtonsoft.Json;

namespace GeniuseeTestTask.Services
{
    public class RainfallServices : IRainfallServices
    {
        private static readonly HttpClient HttpClient = new()
        {
            BaseAddress = new Uri("https://environment.data.gov.uk/flood-monitoring/id/stations/")
        };

        public async Task<RainfallReadingResponseModel> GetReadingsByStationIdAsync(string stationId, int count)
        {
            var response = await HttpClient.GetAsync($"{stationId}/readings?_limit={count}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RainfallReadingResponseModel>(content)!;
            }
            return new RainfallReadingResponseModel();
        }
    }
}
