using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

public class MemoryStream
{
    [JsonProperty(PropertyName ="stream")]
    public List<MemoryEvent> Stream { get; set; } = new List<MemoryEvent>();
}
