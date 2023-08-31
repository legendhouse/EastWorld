using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;
using Newtonsoft.Json;

// TODO: DEPRECATED
public class ChatGptApi : MonoBehaviour
{

    //[Header("OpenAI API Requirements : ")]
    //[Space(5)]
    //public const string API_KEY = OpenAiConfig.OpenAiApiKey;
    //public const string API_URL = OpenAiConfig.ChatApiUrl;
    //public const string Model = OpenAiConfig.ChatModel;
    //[SerializeField]
    //private string promptContent = "hi!";
    //public int MaxTokens;
    //public float Temperature;

    //[Space(10)]
    //[Header("UI : ")]
    //[Space(5)]

    //public Text ErrorText;
    //public Text UserResponseText;
    //public Text BotResponseText;
    //public InputField MessageInput;

    //[Space(10)]
    //[Header("Request Time : ")]
    //[Space(5)]
    //public int timeBetweenRequests; //time in seconds
    //private float lastRequestTime;

    //private void Start()
    //{
    //    lastRequestTime = Time.time;
    //    ErrorText.enabled = false;
    //    Environment.SetEnvironmentVariable("http_proxy", OpenAiConfig.HttpProxy);
    //    Environment.SetEnvironmentVariable("https_proxy", OpenAiConfig.HttpsProxy);
    //    Debug.Log(Environment.GetEnvironmentVariable("http_proxy"));
    //    Debug.Log(Environment.GetEnvironmentVariable("https_proxy"));
    //    SendRequest();
    //}

    //public void SendRequest()
    //{

    //    //prompt = MessageInput.text;
    //    promptContent = "hi";
    //    //play animation
    //    StartCoroutine(SendRequestToChatGpt());
    //    //wait for response
    //    //stop animation

    //}
    //private IEnumerator SendRequestToChatGpt()
    //{

    //    // Wait for the time between requests to pass
    //    if (Time.time - lastRequestTime < timeBetweenRequests)
    //    {
    //        yield return new WaitForSeconds(timeBetweenRequests);
    //    }

    //    // Create the request
    //    UnityWebRequest request = new UnityWebRequest(API_URL, "POST");
    //    request.SetRequestHeader("Content-Type", PostHeaders.ContentType);
    //    request.SetRequestHeader("Authorization", PostHeaders.Authorization);

    //    // Create the request body
    //    ChatPostData postData = new ChatPostData
    //    {
    //        Model = Model,
    //        Messages = new List<Message>() { new UserMessage(promptContent) }
    //    };
    //    string jsonRequestBody = JsonConvert.SerializeObject(postData);
    //    byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequestBody);


    //    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    //    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

    //    // Send the request and wait for the response
    //    yield return request.SendWebRequest();

    //    // Check for errors
    //    if (request.result == UnityWebRequest.Result.ConnectionError ||
    //        request.result == UnityWebRequest.Result.ProtocolError ||
    //        request.result == UnityWebRequest.Result.DataProcessingError)
    //    {
    //        Debug.LogError(request.error);
    //        Debug.LogError(request);
    //        ErrorText.text = request.error;
    //        ErrorText.enabled = true;
    //    }
    //    else
    //    {
    //        // Parse the response to get the text
    //        string responseJson = request.downloadHandler.text;
    //        ChatResponseData responseData = JsonConvert.DeserializeObject<ChatResponseData>(responseJson);
    //        string text = responseData.choices[0].message.content;

    //        // Update the UI
    //        UserResponseText.text = promptContent;
    //        BotResponseText.text = text;

    //        // Create a JSON object with the "role" and "content" keys
    //        string json = "{ \"messages\": [";
    //        json += "{\"role\": \"user\", \"content\": \"" + promptContent + "\"},";
    //        json += "{\"role\": \"bot\", \"content\": \"" + text + "\"}";
    //        json += "] }";

    //        // Print the JSON object
    //        Debug.Log(json);
    //        Debug.Log("Response JSON: " + responseJson);

    //    }

    //    lastRequestTime = Time.time;
    //}


}