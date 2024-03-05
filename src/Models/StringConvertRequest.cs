using System.ComponentModel.DataAnnotations;

namespace CipherCracker.Api.Models;

public class StringConvertRequest
{
    [JsonProperty("text"), Required]
    public string Text { get; set; }

    [JsonProperty("from"), Required]
    public string From { get; set; }
    
    [JsonProperty("to"), Required]
    public string To { get; set; }
}