using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour, INotifiable
{
    public AgentInfo agentInfo;
    Queue<CoroutineTask> todoTasks = new Queue<CoroutineTask>();

    int counter = 0;

    /// <summary>
    /// 是否被对话等行为占用
    /// </summary>
    public bool IsOccupied { get; private set; } = false;

    #region MonoBehaviour
    void Start()
    {
        Scheduler.Instance.RegisterNotifiableObject(this);
        Plan();
    }

    void Update()
    {

    }
    #endregion



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
    /// 以半小时为时间步，添加一个计划
    /// 不一定每个时间点都要有计划，无计划的时间点，可以自由选择Move或Converse
    /// </summary>
    public void Plan()
    {
        CoroutineTask task = new CoroutineTask(Converse());
        Scheduler.Instance.RegisterCoroutineTask(task);
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
    /// 与其他人物进行对话，需要以协程IEnumerator的方式实现
    /// </summary>
    public IEnumerator Converse()
    {
        Debug.Log(new AssistantMessage("Hi！这是一条打桩数据！"));
        yield return new WaitForSeconds(1f);
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

    public void OnTimePointReached()
    {
        // TODO
        Debug.Log($"+++++++++++++{agentInfo.FirstName}的人物执行完成! {++counter}+++++++++++++" + ToString());
        Plan();
    }
}
