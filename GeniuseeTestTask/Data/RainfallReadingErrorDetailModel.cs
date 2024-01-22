using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace GeniuseeTestTask.Data
{
    [SwaggerSchema(Description = "Details of invalid request property")]
    [DisplayName("errorDetail")]
    public record RainfallReadingErrorDetailModel
    {
        public string PropertyName { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
