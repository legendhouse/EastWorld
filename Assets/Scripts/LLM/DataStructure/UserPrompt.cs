using Newtonsoft.Json;

public class UserPrompt : Prompt
{
    [JsonProperty(PropertyName = "role")]
    public override string Role { get; set; } = "user";

    public UserPrompt(string content)
    {
        Content = content;
    }
}
