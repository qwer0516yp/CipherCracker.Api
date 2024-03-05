using CipherCracker.Api.Models;
using CipherCracker.ClassLibrary;
using CommunityToolkit.Diagnostics;
using System.Text;

namespace CipherCracker.Api;

public class StringConvertService
{
    public StringConvertResponse ProcessRequest(StringConvertRequest request)
    {
        var response = new StringConvertResponse();

        try
        {
            RequestValidator.Validate(request);

            var bytes = ConvertToBytes(request.Text, request.From);
            Guard.IsNotNull(bytes);
            var result = ConvertToString(bytes, request.To);

            response.IsSuccess = true;
            response.Result = result;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.ErrorMessage = ex.Message;
        }

        return response;
    }

    private byte[] ConvertToBytes(string text, string format)
    {
        if (format.ToLower() == "hex")
            return text.HexStringToBytes();

        if (format.ToLower() == "base64")
            return text.Base64StringToBytes();

        if (format.ToLower() == "utf-8")
            return Encoding.UTF8.GetBytes(text);

        if (format.ToLower() == "utf-32")
            return Encoding.UTF32.GetBytes(text);

        if (format.ToLower() == "ascii")
            return Encoding.ASCII.GetBytes(text);

        throw new InvalidOperationException($"Invalid Operation convertToBytes, text: {text}, format {format}.");
    }

    private string ConvertToString(byte[] bytes, string format)
    {
        if (format.ToLower() == "hex")
            return bytes.ToHexString();

        if (format.ToLower() == "base64")
            return bytes.ToBase64String();

        if (format.ToLower() == "utf-8")
            return Encoding.UTF8.GetString(bytes);

        if (format.ToLower() == "utf-32")
            return Encoding.UTF32.GetString(bytes);

        if (format.ToLower() == "ascii")
            return Encoding.ASCII.GetString(bytes);

        throw new InvalidOperationException($"Invalid Operation convertToString, format {format}.");
    }
}
