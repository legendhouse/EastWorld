using Newtonsoft.Json;

[System.Serializable]
public abstract class Prompt
{
    [JsonProperty(PropertyName = "role")]
    public abstract string Role { get; set; }
    [JsonProperty(PropertyName = "content")]
    public virtual string Content { get; set; }
}
