namespace CipherCracker.Api.Models;

public class StringConvertResponse : ResponseBase
{
    [JsonProperty("result")]
    public string Result { get; set; }
}
