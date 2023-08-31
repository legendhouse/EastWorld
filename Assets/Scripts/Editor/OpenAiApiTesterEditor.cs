using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections;

[CustomEditor(typeof(OpenAiApiTester))]
public class OpenAiApiTesterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        OpenAiApiTester tester = (OpenAiApiTester)target;
        DrawDefaultInspector(); // Draws the default UI elements of the inspector

        if (GUILayout.Button("Chat"))
        {
            // Calls the Chat API
            tester.StartCoroutine(CallChat(tester));
        }

        if (GUILayout.Button("Embedding"))
        {
            // Calls the Embedding API
            tester.StartCoroutine(CallEmbedding(tester));
        }
    }

    private IEnumerator CallChat(OpenAiApiTester tester)
    {
        Message message = new Message("user", tester.chatInput);
        yield return tester.StartCoroutine(OpenAiApi.Instance.Chat(message, (result) => { tester.chatOutput = result.content; }));  // 使用了callback
    }

    private IEnumerator CallEmbedding(OpenAiApiTester tester)
    {
        Embedding embedding = new Embedding();  // Create a new Embedding object
        yield return tester.StartCoroutine(OpenAiApi.Instance.GetEmbedding(tester.embeddingInput, (result) => { tester.embeddingOutput = result.ToString(); }));
    }
}
