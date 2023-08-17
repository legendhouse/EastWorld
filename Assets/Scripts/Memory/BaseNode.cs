using Newtonsoft.Json;

/// <summary>
/// 基础事件
/// </summary>
public class BaseNode
{
    static int EMBEDDING_SIZE = 1536;

    [JsonProperty(PropertyName = "subject")]
    public string Subject { get; set; }

    [JsonProperty(PropertyName = "predicate")]
    public string Predicate { get; set; }

    [JsonProperty(PropertyName = "object")]
    public string Object { get; set; } = "";

    [JsonProperty(PropertyName = "timeStamp")]
    public string TimeStamp { get; set; }

    [JsonProperty(PropertyName = "embedding")]
    public int[] Embedding;

    public BaseNode()
    {

    }

    public BaseNode(string subject, string predicate, string object_, string timeStamp)
    {
        Subject = subject;
        Predicate = predicate;
        Object = object_;
        TimeStamp = timeStamp;
        Embedding = new int[EMBEDDING_SIZE];
    }

    public BaseNode(string subject, string predicate, string object_)
    {
        Subject = subject;
        Predicate = predicate;
        Object = object_;
        TimeStamp = System.DateTime.Now.ToString();
        Embedding = new int[EMBEDDING_SIZE];
    }

    public BaseNode(string subject, string predicate)
    {
        Subject = subject;
        Predicate = predicate;
        Object = "";
        TimeStamp = System.DateTime.Now.ToString();
        Embedding = new int[EMBEDDING_SIZE];
    }

    public override string ToString()
    {
        if (Object!=null)
            return string.Format("{0} {1} {2}", Subject, Predicate, Object);
        else
            return string.Format("{0} {1}", Subject, Predicate);
    }
}
