[System.Serializable]
public class SystemMessage : Message
{
    public SystemMessage(string content) : base("system", content) { }
}
