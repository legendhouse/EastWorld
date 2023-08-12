using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class PostData
{
    [JsonProperty(PropertyName = "messages")]
    public List<Prompt> Messages;

    [JsonProperty(PropertyName = "model")]
    public string Model = OpenAiConfig.Model;

    [JsonProperty(PropertyName = "temperature")]
    public float Temperature = 1;
}
