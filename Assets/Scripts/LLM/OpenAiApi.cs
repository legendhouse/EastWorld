using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class OpenAiApi : MonoBehaviour
{
    public static OpenAiApi Instance { get; private set; }


    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Environment.SetEnvironmentVariable("http_proxy", OpenAiConfig.HttpProxy);
            Environment.SetEnvironmentVariable("https_proxy", OpenAiConfig.HttpsProxy);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        UnitTest();
    }

    void UnitTest()
    {
        Debug.Log("===========开始单元测试===========");
        List<Message> messages = new List<Message>()
        {
            new SystemMessage("你是一个中文对话AI，无论对方说什么，请用中文回复"),
            new UserMessage("hi, how are you?")
        };
        CallChat(messages, null);
        CallEmbedding("用户旅程");
    }

    /// <summary>
    /// 调用聊天的接口
    /// </summary>
    /// <param name="messages"></param>
    public void CallChat(List<Message> messages, Action<Message> callback = null, List<Action<Message>> callbacks = null)
    {
        StartCoroutine(Chat(messages, callback, callbacks));
    }

    /// <summary>
    /// 调用聊天的接口，简化测试时的化外部操作，只需要传入单一string
    /// </summary>
    /// <param name="content"></param>
    public void CallChat(string content, Action<Message> callback = null, List<Action<Message>> callbacks = null)
    {
        StartCoroutine(Chat(content, callback, callbacks));
    }

    /// <summary>
    /// 调用Embedding的接口
    /// 这里需要用协程方式调用，否则不生效
    /// </summary>
    /// <param name="text"></param>
    public void CallEmbedding(string text, Action<Embedding> callback = null, List<Action<Embedding>> callbacks = null)
    {
        StartCoroutine(GetEmbedding(text, callback, callbacks));
    }

    /// <summary>
    /// 简化测试时的化外部操作，只需要传入单一string
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public IEnumerator Chat(string content, Action<Message> callback, List<Action<Message>> callbacks)
    {
        List<Message> messages = new List<Message>()
        {
            new UserMessage(content)
        };
        yield return Chat(messages, callback, callbacks);
    }

    public IEnumerator Chat(Message message, Action<Message> callback = null, List<Action<Message>> callbacks = null)
    {
        List<Message> messages = new List<Message>()
        {
            message
        };
        yield return Chat(messages, callback, callbacks);
    }

    public IEnumerator Chat(List<Message> messages, Action<Message> callback = null, List<Action<Message>> callbacks = null)
    {
        UnityWebRequest request = UnityWebRequest.Post(OpenAiConfig.ChatApiUrl, "");
        request.SetRequestHeader("Content-Type", PostHeaders.ContentType);
        request.SetRequestHeader("Authorization", PostHeaders.Authorization);

        ChatPostData postData = new ChatPostData
        {
            Messages = messages
        };
        string jsonRequestBody = JsonConvert.SerializeObject(postData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequestBody);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseJson = request.downloadHandler.text;
            ChatResponseData responseData = JsonConvert.DeserializeObject<ChatResponseData>(responseJson);
            Message message = responseData.choices[0].message;
            Debug.Log("return message: " + message);
            yield return message;
            callback?.Invoke(message);  // 执行回调
            if (callbacks != null)
            {
                foreach (var cb in callbacks)
                {
                    cb?.Invoke(message);
                }
            }
            yield return null;
        }
        else
        {
            Debug.LogError("OpenAI Chat API Error: " + request.error);
            yield return null;
        }
    }

    public IEnumerator GetEmbedding(string input, Action<Embedding> callback = null, List<Action<Embedding>> callbacks = null)
    {
        UnityWebRequest request = UnityWebRequest.Post(OpenAiConfig.EmbeddingApiUrl, input);
        request.SetRequestHeader("Content-Type", PostHeaders.ContentType);
        request.SetRequestHeader("Authorization", PostHeaders.Authorization);

        EmbeddingPostData postData = new EmbeddingPostData
        {
            Input = input
        };
        string jsonRequestBody = JsonConvert.SerializeObject(postData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequestBody);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseJson = request.downloadHandler.text;
            EmbeddingResponseData responseData = JsonConvert.DeserializeObject<EmbeddingResponseData>(responseJson);
            Embedding embedding = responseData.data[0];
            Debug.Log("embedding: " + embedding);
            yield return embedding;
            callback?.Invoke(embedding);
            if (callbacks != null)
            {
                foreach (var cb in callbacks)
                {
                    cb?.Invoke(embedding);
                }
            }
        }
        else
        {
            Debug.LogError("OpenAI Embedding API Error: " + request.error);
            yield return null;
        }
    }
}
