using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class OpenAiConfig
{
    public static readonly string OpenAiApiKey;
    public static readonly string HttpProxy;
    public static readonly string HttpsProxy;
    public static readonly string ChatModel;
    public static readonly string EmbeddingModel;
    public static readonly string ChatApiUrl;
    public static readonly string EmbeddingApiUrl;

    static OpenAiConfig()
    {
        TextAsset configFile = Resources.Load<TextAsset>("Configs/OpenAiConfig"); // 无需扩展名，会自动识别
        string json = configFile.text;

        OpenAiConfigModel config = JsonConvert.DeserializeObject<OpenAiConfigModel>(json);

        OpenAiApiKey = config.OpenAiApiKey;
        HttpProxy = config.HttpProxy;
        HttpsProxy = config.HttpsProxy;
        ChatModel = config.ChatModel;
        EmbeddingModel = config.EmbeddingModel;
        ChatApiUrl = config.ChatApiUrl;
        EmbeddingApiUrl = config.EmbeddingApiUrl;
    }
}

public class OpenAiConfigModel
{
    [JsonProperty(PropertyName = "openai_api_key")]
    public string OpenAiApiKey { get; set; }

    [JsonProperty(PropertyName = "http_proxy")]
    public string HttpProxy { get; set; }

    [JsonProperty(PropertyName = "https_proxy")]
    public string HttpsProxy { get; set; }

    [JsonProperty(PropertyName = "chat_model")]
    public string ChatModel { get; set; }

    [JsonProperty(PropertyName = "embedding_model")]
    public string EmbeddingModel { get; set; }

    [JsonProperty(PropertyName = "chat_api_url")]
    public string ChatApiUrl { get; set; }

    [JsonProperty(PropertyName = "embedding_api_url")]
    public string EmbeddingApiUrl { get; set; }
}
