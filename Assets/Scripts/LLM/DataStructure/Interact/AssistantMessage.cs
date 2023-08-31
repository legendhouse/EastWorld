[System.Serializable]
public class AssistantMessage : Message
{
    public AssistantMessage(string content) : base("assistant", content) { }
}
