using GeniuseeTestTask.Data;

namespace GeniuseeTestTask.Abstractions
{
    public interface IRainfallServices
    {
        Task<RainfallReadingResponseModel> GetReadingsByStationIdAsync(string stationId, int count);
    }
}
