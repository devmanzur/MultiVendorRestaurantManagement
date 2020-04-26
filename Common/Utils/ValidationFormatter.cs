using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CrossCutting.Utils
{
    public static class ValidationFormatter
    {
        public static string ToBadResponse(this List<FluentValidation.Results.ValidationFailure> failures)
        {
            var errors = failures.Select(x =>
                new
                {
                    x.PropertyName,
                    x.ErrorMessage
                });
            var errorText = JsonSerializer.Serialize(errors);
            return errorText;
        }
    }
}