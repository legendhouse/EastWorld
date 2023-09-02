using System.Collections.Generic;

[System.Serializable]
public class ChatResponseData
{
    public List<Choice> choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
    public string finish_reason;
    public int index;
}
