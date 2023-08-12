using System.Collections.Generic;

/// <summary>
/// 返回的信息
/// </summary>
[System.Serializable]
public class Response
{
    public string id;
    public string created;
    public string model;
    public List<Choice> choices;

    [System.Serializable]
    public class Choice
    {
        public string text;
        public string index;
        public string finish_reason;
    }

}