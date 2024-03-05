using CipherCracker.Api.Models;
using CommunityToolkit.Diagnostics;

namespace CipherCracker.Api;

public static class RequestValidator
{
    public static void Validate(AesGcmEncryptRequest request)
    {
        Guard.IsNotNull(request);
        Guard.IsNotNullOrWhiteSpace(request.KeyBase64);
        Guard.IsNotNull(request.PlainText);
    }

    public static void Validate(AesGcmDecryptRequest request)
    {
        Guard.IsNotNull(request);
        Guard.IsNotNullOrWhiteSpace(request.KeyBase64);
        Guard.IsNotNullOrWhiteSpace(request.IvBase64);
        Guard.IsNotNullOrWhiteSpace(request.EncryptedMessageBase64);
    }

    private static readonly string[] _validStringFormats = { "hex", "base64", "ascii", "utf-8", "utf-32" };
    public static void Validate(StringConvertRequest request)
    {
        Guard.IsNotNull(request);
        Guard.IsNotNullOrWhiteSpace(request.Text);
        Guard.IsNotNullOrWhiteSpace(request.From);
        Guard.IsNotNullOrWhiteSpace(request.To);

        if(!_validStringFormats.Contains(request.From))
            throw new ArgumentException("Invalid 'from' string format");
        if(!_validStringFormats.Contains(request.To))
            throw new ArgumentException("Invalid 'to' string format");
    }
}
