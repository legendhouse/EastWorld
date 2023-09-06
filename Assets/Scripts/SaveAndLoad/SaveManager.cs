using UnityEngine;
using System.IO;
using Newtonsoft.Json; // 使用 JSON .NET 库

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    void Awake()
    {
        // 单例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        // 调用各个类的 Save 方法，并将数据保存到文件
        // 示例代码（需要根据你的具体实现来调整）

        // 获取 Agent 的保存数据
        // string agentData = somAgent.Save();
        // 获取 Memory 的保存数据
        //string memoryData = Memory.Instance.Save();
        // ...（其他类）

        // 创建一个包含所有保存数据的对象
        SaveData saveData = new SaveData
        {
            AgentData = "agent",
            MemoryData = "memory",
            // ...（其他数据）
        };

        // 序列化并保存到文件
        string jsonData = JsonConvert.SerializeObject(saveData);
        File.WriteAllText(Application.dataPath + "/save.json", jsonData);
    }

    public void LoadGame()
    {
        // 从文件加载数据，并调用各个类的 Load 方法
        // 示例代码（需要根据你的具体实现来调整）

        // 读取保存的 JSON 数据
        string jsonData = File.ReadAllText(Application.dataPath + "/save.json");
        SaveData saveData = JsonConvert.DeserializeObject<SaveData>(jsonData);

        // 使用保存的数据来加载各个类的状态
        //Agent.Instance.Load(saveData.AgentData);
        //Memory.Instance.Load(saveData.MemoryData);
        // ...（其他类）
    }
}

// 用于保存所有游戏数据的类
public class SaveData
{
    public string AgentData { get; set; }
    public string MemoryData { get; set; }
    // ...（其他数据）
}
