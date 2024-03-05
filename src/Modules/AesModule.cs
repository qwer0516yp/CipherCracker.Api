using CipherCracker.Api.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CipherCracker.Api;

public static class AesModule
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static void RegisterAesModuleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/aes/gcm/encrypt", (AesGcmEncryptRequest request) =>
        {
            var response = new AesGcmService().ProcessEncryptionResquest(request);
            return Results.Json(response, jsonSerializerOptions);
        }).WithTags("AES");

        app.MapPost("/aes/gcm/decrypt", (AesGcmDecryptRequest request) =>
        {
            var response = new AesGcmService().ProcessDecryptionResquest(request);
            return Results.Json(response, jsonSerializerOptions);
        }).WithTags("AES");
    }
}
