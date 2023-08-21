using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Agent管理器，单例类，在awake阶段实现
/// 这里写好读入的agent配置路径，记忆读写路径等
/// </summary>
public class AgentManager : MonoBehaviour
{
    public static AgentManager Instance { get; private set; }
    public static string agentInfoDir;
    public static string agentMemoryDir;
    public List<Agent> agents = new List<Agent>();

    private void Awake()
    {
        CreateOrGetSingleton();
    }

    private void CreateOrGetSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        agentInfoDir = "";
        agentMemoryDir = "";
    }

    /// <summary>
    /// TODO!!!!!!!!!!!!!!!!!!!!
    /// </summary>
    void LoadAllAgents()
    {
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>("PathToYourJSONFiles");

        foreach (TextAsset textAsset in textAssets)
        {
            if (textAsset.name.StartsWith("agent_"))
            {
                AgentInfo agentInfo = JsonConvert.DeserializeObject<AgentInfo>(textAsset.text);
                Agent agent = JsonUtility.FromJson<Agent>(textAsset.text);
                agents.Add(agent);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
