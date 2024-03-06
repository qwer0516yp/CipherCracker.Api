using CipherCracker.Api.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CipherCracker.Api.Examples;

public class StringConvertExample : IExamplesProvider<StringConvertRequest>
{
    public StringConvertRequest GetExamples()
    {
        return new StringConvertRequest 
        {
            From = "hex",
            To = "base64",
            Text = "1234567890abcdefABCDEF"
        };
    }
}
