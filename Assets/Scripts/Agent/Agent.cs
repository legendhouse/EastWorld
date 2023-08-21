using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour, ICognition
{
    public string AgentName { get; protected set; }
    #region MonoBehaviour
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion


    #region ICognition Implements
    /// <summary>
    /// 感知周围环境，获得信息列表
    /// </summary>
    /// <returns></returns>
    public List<BaseNode> Perceive()
    {
        // TODO
        return new List<BaseNode>();
    }

    public void Retrieve()
    {

    }

    public void Plan()
    {

    }

    public void Excecute()
    {

    }

    /// <summary>
    /// 将相关信息抽象成新的记忆
    /// </summary>
    /// <param name="perceivedNodes"></param>
    /// <returns></returns>
    public MemoryNode Reflect(List<BaseNode> perceivedNodes)
    {
        return new MemoryNode();
    }
    #endregion

    #region IO
    /// <summary>
    /// 保存任务当前状态(序列化)
    /// </summary>
    public void Save()
    {

    }

    /// <summary>
    /// 加载人物状态(反序列化)
    /// </summary>
    public void Load()
    {

    }
    #endregion

    #region Action
    /// <summary>
    /// 与其他人物进行对话
    /// </summary>
    public void StartConversationSession()
    {

    }

    /// <summary>
    /// 移动
    /// </summary>
    public void Move()
    {

    }
    #endregion
}
