using Newtonsoft.Json;
using System;
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
    /// 外部接口，负责解析基本类型到枚举类、时间类等
    /// </summary>
    /// <param name="taskTypeString"></param>
    /// <param name="dateTimeString"></param>
    /// <param name="taskParams"></param>
    public void Plan(string taskTypeString, string dateTimeString, Dictionary<string, string> taskParams)
    {
        bool isTaskTypeVald = Enum.TryParse(taskTypeString, out TaskType taskType);
        if (!isTaskTypeVald)
        {
            Debug.LogWarning($"任务类型无法解析：{taskTypeString}");
            return;
        }
        bool isTimeValid = DateTime.TryParse(dateTimeString, out DateTime dateTime);
        if (isTimeValid)
        {
            Plan(taskType, dateTime, taskParams);
        }
        else
        {
            Debug.LogWarning($"时间无法解析: {dateTimeString}");
        }
    }

    /// <summary>
    /// 内部实现 TODO
    /// </summary>
    public void Plan(TaskType taskType, DateTime dateTime, Dictionary<string, string> taskParams)
    {
        switch (taskType)
        {
            case TaskType.CHAT:
                CoroutineTask task = new CoroutineTask(Converse(), dateTime);
                todoTasks.Enqueue(task);
                break;
            case TaskType.MOVE:
                Debug.Log("计划：移动");
                break;
            case TaskType.REFLECT:
                Debug.Log("计划：回忆");
                break;
            case TaskType.WAIT:
                Debug.Log("计划：等待");
                break;
        }
    }

    /// <summary>
    /// 通过合适的prompt与gpt交互，获得当天计划表，并提取出结构化数据
    /// </summary>
    public void DailyPlan()
    {

    }

    public void HourlyPlan()
    {

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