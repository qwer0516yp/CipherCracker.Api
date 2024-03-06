using CipherCracker.Api.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CipherCracker.Api;

public static class UtilityModule
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static void RegisterUtilityModuleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/utility/string/convert", (StringConvertRequest request) =>
        {
            var response = new StringConvertService().ProcessRequest(request);
            return Results.Json(response, jsonSerializerOptions);
        }).WithTags("Utilities")
        .WithOpenApi(op => new(op) 
        {
            Summary = "Convert String from one format/encoding to another",
            Description = "Supported formats: Base64, Hex, UTF-8, UTF-32, ASCII"
        });
    }
}
