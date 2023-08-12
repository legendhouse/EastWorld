using Newtonsoft.Json;

[System.Serializable]
public class PostHeaders
{
    [JsonProperty(PropertyName = "Content-Type")]
    public static string ContentType;

    public static string Authorization;

    static PostHeaders()
    {
        ContentType = "application/json";
        Authorization = string.Format("Bearer {0}", OpenAiConfig.OpenAiApiKey);
    }
}
