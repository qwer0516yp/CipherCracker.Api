using CipherCracker.Api.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        }).WithTags("Utilities");
    }
}
