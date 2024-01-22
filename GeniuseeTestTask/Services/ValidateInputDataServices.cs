using System.Text.RegularExpressions;
using GeniuseeTestTask.Abstractions;

namespace GeniuseeTestTask.Services
{
    public class ValidateInputDataServices: IValidateInputDataServices
    {
        public bool Validate(string input)
        {
            var pattern = new Regex("^[A-Za-z0-9]+$");
            return pattern.IsMatch(input);
        }
    }
}
