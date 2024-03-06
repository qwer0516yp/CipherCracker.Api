using CipherCracker.Api.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CipherCracker.Api.Examples;

public class StringConvertExample : IMultipleExamplesProvider<StringConvertRequest>
{
    public IEnumerable<SwaggerExample<StringConvertRequest>> GetExamples()
    {
        yield return SwaggerExample.Create("hex to base64", 
            new StringConvertRequest
            {
                From = "hex",
                To = "base64",
                Text = "1234567890abcdefABCDEF"
            });

        yield return SwaggerExample.Create("base64 to hex",
            new StringConvertRequest
            {
                From = "base64",
                To = "hex",
                Text = "EjRWeJCrze+rze8="
            });
    }
}
