using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class ChatPostData
{
    [JsonProperty(PropertyName = "messages")]
    public List<Message> Messages;

    [JsonProperty(PropertyName = "model")]
    public string Model = OpenAiConfig.ChatModel;

    [JsonProperty(PropertyName = "temperature")]
    public float Temperature = 1;
}
