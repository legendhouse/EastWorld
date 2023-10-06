using Newtonsoft.Json;

/// <summary>
/// agent基本信息
/// </summary>
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

    
    public override string ToString()
    {
        return string.Format("\n========Agent Profile========\n- name:\t{0}\n- innate:\t{1}", FullName, Innate);
    }
}
