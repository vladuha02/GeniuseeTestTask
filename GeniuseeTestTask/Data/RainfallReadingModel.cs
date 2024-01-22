using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace GeniuseeTestTask.Data
{
    [SwaggerSchema(Description = "Details of a rainfall reading", Title = "Rainfall reading")]
    [DisplayName("rainfallReading")]
    public record RainfallReadingModel
    {
        [JsonProperty("dateTime")]
        public DateTime DateMeasured { get; set; }

        [JsonProperty("value")]
        [SwaggerSchema(Format = "decimal")]
        public decimal AmountMeasured { get; set; }
    }
}
