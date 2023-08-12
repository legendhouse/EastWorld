using Newtonsoft.Json;

public class SystemPrompt : Prompt
{
    [JsonProperty(PropertyName = "role")]
    public override string Role { get; set; } = "system";
}
