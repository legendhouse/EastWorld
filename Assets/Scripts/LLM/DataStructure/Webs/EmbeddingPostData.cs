using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class EmbeddingPostData
{
    [JsonProperty(PropertyName = "input")]
    public string Input { get; set; }

    [JsonProperty(PropertyName = "model")]
    public string Model = OpenAiConfig.EmbeddingModel;
}
