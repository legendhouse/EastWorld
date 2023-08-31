using UnityEngine;

public class OpenAiApiTester : MonoBehaviour
{
    [Header("Input")]
    public string chatInput;
    public string embeddingInput;

    [Header("Output")]
    [TextArea]
    public string chatOutput;
    [TextArea]
    public string embeddingOutput;
}
