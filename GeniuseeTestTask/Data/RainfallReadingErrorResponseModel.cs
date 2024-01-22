using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace GeniuseeTestTask.Data
{
    [SwaggerSchema(Description = "Details of a rainfall reading", Title = "Error response")]
    [DisplayName("error")]
    public record RainfallReadingErrorResponseModel
    {
        public string Message { get; set; } = null!;

        public RainfallReadingErrorDetailModel[] Detail { get; set; } = null!;
    }
}
