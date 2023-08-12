using Newtonsoft.Json;

public class AssistantPrompt : Prompt
{
    [JsonProperty(PropertyName = "role")]
    public override string Role { get; set; } = "assistant";
}
