using Newtonsoft.Json;

public static class OpenAiConfig
{
    [JsonProperty(PropertyName = "openai_api_key")]
    public const string OpenAiApiKey  = "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";

    [JsonProperty(PropertyName = "http_proxy")]
    public const string HttpProxy  = "127.0.0.1";

    [JsonProperty(PropertyName = "https_proxy")]
    public const string HttpsProxy  = "127.0.0.1";

    [JsonProperty(PropertyName = "model")]
    public const string Model = "gpt-3.5-turbo-0613";

    public const string ApiUrl = "https://api.openai.com/v1/chat/completions";

}
