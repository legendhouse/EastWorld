using Newtonsoft.Json;
public class AgentInfo
{
    [JsonProperty(PropertyName = "innate")]
    public string Innate { get; private set; }
    [JsonProperty(PropertyName = "fullName")]
    public string FullName { get; private set; }
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; private set; }
    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; private set; }
}
