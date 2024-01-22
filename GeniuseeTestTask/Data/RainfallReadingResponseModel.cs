using System.ComponentModel;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace GeniuseeTestTask.Data
{
    [SwaggerSchema(Description = "Details of a rainfall reading", Title = "Rainfall reading response")]
    [DisplayName("rainfallReadingResponse")]
    public record RainfallReadingResponseModel
    {
        [JsonProperty("items")]
        public RainfallReadingModel[] Readings { get; set; } = null!;
    }
}
