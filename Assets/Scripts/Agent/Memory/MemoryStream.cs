using Newtonsoft.Json;
using System.Collections.Generic;

public class MemoryStream
{
    /// <summary>
    /// 从周围observe的或自己身上发生的事件记忆
    /// </summary>
    [JsonProperty(PropertyName = "eventDict")]
    public Dictionary<string, BaseNode> EventDict { get; set; } = new Dictionary<string, BaseNode>();

    /// <summary>
    /// 主要是reflection获得的高层记忆
    /// </summary>
    [JsonProperty(PropertyName = "thoughtDict")]
    public Dictionary<string, BaseNode> ThoughtDict { get; set; } = new Dictionary<string, BaseNode>();

    /// <summary>
    /// 与周围人聊天的记录，key为对方人名，value为聊天内容node
    /// </summary>
    [JsonProperty(PropertyName = "chatDict")]
    public Dictionary<string, string> ChatDict { get; set; } = new Dictionary<string, string>();
}
