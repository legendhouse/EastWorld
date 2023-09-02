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
    public Dictionary<string, Agent> agentDict = new Dictionary<string, Agent>();

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
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
        agentInfoDir = "AgentProfiles/en";
        agentMemoryDir = "";
        LoadAllAgents();
    }

    /// <summary>
    /// 从Resources/AgentProfiles下加载所有agent
    /// </summary>
    void LoadAllAgents()
    {
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>(agentInfoDir);

        foreach (TextAsset textAsset in textAssets)
        {
            if (textAsset.name.StartsWith("agent_"))
            {
                AgentInfo agentInfo = JsonConvert.DeserializeObject<AgentInfo>(textAsset.text);
                Agent agent = new GameObject(agentInfo.FullName).AddComponent<Agent>();
                agent.agentInfo = agentInfo;
                agentDict[agentInfo.FullName] = agent;
                Debug.Log(agent);
            }
        }
    }

}
