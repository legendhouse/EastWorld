using Newtonsoft.Json;

/// <summary>
/// 基础事件
/// </summary>
public class BaseEvent
{ 
    [JsonProperty(PropertyName = "subject")]
    public string Subject { get; set; }

    [JsonProperty(PropertyName = "predicate")]
    public string Predicate { get; set; }

    [JsonProperty(PropertyName = "object")]
    public string Object { get; set; } = "";

    [JsonProperty(PropertyName = "timeStamp")]
    public string TimeStamp { get; set; }

    public BaseEvent(string subject, string predicate, string object_, string timeStamp)
    {
        Subject = subject;
        Predicate = predicate;
        Object = object_;
        TimeStamp = timeStamp;
    }

    public BaseEvent(string subject, string predicate, string object_)
    {
        Subject = subject;
        Predicate = predicate;
        Object = object_;
        TimeStamp = System.DateTime.Now.ToString();
    }

    public BaseEvent(string subject, string predicate)
    {
        Subject = subject;
        Predicate = predicate;
        Object = "";
        TimeStamp = System.DateTime.Now.ToString();
    }

    public override string ToString()
    {
        if (Object!=null)
            return string.Format("{0} {1} {2}", Subject, Predicate, Object);
        else
            return string.Format("{0} {1}", Subject, Predicate);
    }
}
