using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public AgentInfo agentInfo;
    Queue<CoroutineTask> todoTasks = new Queue<CoroutineTask>();
    int counter = 0;
    public bool IsOccupied { get; private set; } = false;

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

    void Start()
    {
        Plan();
    }

    /// <summary>
    /// 感知周围环境，获得信息列表
    /// </summary>
    /// <returns></returns>
    public List<BaseNode> Perceive()
    {
        // TODO
        return new List<BaseNode>();
    }

    /// <summary>
    /// 寻找自己记忆中最相关的记忆片段，拼接成一段prompt，并抽象成新的memory
    /// 每日固定k个时间点，各执行一次
    /// </summary>
    public void Retrieve()
    {

    }

    /// <summary>
    /// 以当前时间为起点，做一个计划表格
    /// 简易起见，
    /// </summary>
    public void Plan()
    {
        CoroutineTask task = new CoroutineTask(Converse());
        todoTasks.Enqueue(task);
    }

    /// <summary>
    /// 抽象的执行方法，可以是计划表中的看书、散步等，也可以是根据当前环境状态，与邻近NPC对话
    /// </summary>
    public IEnumerator Excecute()
    {
        // 执行本agent待执行任务队列
        foreach(var task in todoTasks)
        {
            task.OnStart?.Invoke();
            yield return StartCoroutine(task.Coroutine);
            task.OnCompletion?.Invoke();
            yield return 1; // 等待1帧
        }
        yield return new WaitForSeconds(1f);

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




    #region Action
    /// <summary>
    /// 与其他人物进行对话，需要以协程IEnumerator的方式实现
    /// </summary>
    public IEnumerator Converse(Agent other)
    {
        Debug.Log(new AssistantMessage($"Hi！这是一条开启对话的打桩数据！{other.ToString()}"));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Converse()
    {
        Debug.Log(new AssistantMessage("Hi！这是一条开启对话的打桩数据！"));
        yield return new WaitForSeconds(1f);
    }


    public IEnumerable Converse(Agent other, Message replyMessage)
    {
        Debug.Log(new AssistantMessage("Hi！这是一条回复的打桩数据！"));
        yield return new WaitForSeconds(0.1f);
    }

    /// <summary>
    /// 移动
    /// </summary>
    public void Move()
    {

    }
    #endregion

    public override string ToString()
    {
        return string.Format("\n========Agent Profile========\n-name: {0}\n-innate: {1}", agentInfo.FullName, agentInfo.Innate);
    }
}