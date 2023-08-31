[System.Serializable]
public class UserMessage: Message
{
    public UserMessage(string content) : base("user", content) { }
}
