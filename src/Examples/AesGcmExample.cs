using CipherCracker.Api.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CipherCracker.Api.Examples;

public class AesGcmEncryptExample : IMultipleExamplesProvider<AesGcmEncryptRequest>
{
    public IEnumerable<SwaggerExample<AesGcmEncryptRequest>> GetExamples()
    {
        yield return SwaggerExample.Create("generate a random 16 bytes iv",
            new AesGcmEncryptRequest
            {
                PlainText = "plain text string in utf-8 encoding, aes-256-gcm encrypted with a 32 null bytes AES key and a random 16 bytes iv",
                KeyBase64 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=",
                IsIv12NullBytes = false
            });

        yield return SwaggerExample.Create("fixed 12 null bytes iv",
            new AesGcmEncryptRequest
            {
                PlainText = "plain text string in utf-8 encoding, aes-256-gcm encrypted with a 32 null bytes AES key and a fixed 12 null bytes iv",
                KeyBase64 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=",
                IsIv12NullBytes = true
            });
    }
}

public class AesGcmDecryptExample : IMultipleExamplesProvider<AesGcmDecryptRequest>
{
    public IEnumerable<SwaggerExample<AesGcmDecryptRequest>> GetExamples()
    {
        yield return SwaggerExample.Create("16 bytes iv",
            new AesGcmDecryptRequest
            {
                EncryptedMessageBase64 = "eayzWvOMrICtaeMxhTqqGr4jdDtzOcg0KSulIjZpMony0xMIbhYEZm4uarU4T7a9iDfWzdGbBoyU55qPzXj+PnekNBpMR9MOtiZyECXbe2xai6lrT+aWZHx2V+SlGmRTFiW5+06rc62UfgI/ZHpnqQqbfQbG4853RQ1tRjp07mk=",
                KeyBase64 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=",
                IvBase64 = "NGHJbsGHQEm0f9BijuRSsQ=="
            });

        yield return SwaggerExample.Create("fixed 12 null bytes iv",
            new AesGcmDecryptRequest
            {
                EncryptedMessageBase64 = "vsshVCNAHwt/OuWgzoH0dhVAaqQX014S/JrV6xtlWuq0JNYEbSuECGzabBJqa1WaZySlgvPCD0QEGD2UwnhSP7HkvEEBxlhbDLXOmTX0FID96hqQq6vfDYfSeEY1fnvE058T7V+3+koq3NHlh1WITMkqiN346Y8w02N1opH0qXhKET96",
                KeyBase64 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=",
                IvBase64 = "AAAAAAAAAAAAAAAA"
            });
    }
}