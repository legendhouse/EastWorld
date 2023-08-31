[System.Serializable]
public class Message
{
    public string role;
    public string content;

    public Message(string role, string content)
    {
        this.role = role;
        this.content = content;
    }

    public override string ToString()
    {
        return string.Format("role: {0}\ncontent:{1}", role, content);
    }
}
