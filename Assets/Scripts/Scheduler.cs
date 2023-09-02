using System;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Collections;

/// <summary>
/// 用于统一记录所有agent行为的时间表类
/// 不干预agent的具体行为，但是需要监控每个时间步中，需要执行动作的agent，是否执行完了动作
/// </summary>
[Serializable]
public class Scheduler : MonoBehaviour
{
    public static Scheduler Instance;
    public string currentTime;
    public event Action OnAllCoroutinesCompleted;

    private readonly string resourcePath = "scheduler.json";

    private int runningCoroutinesCount = 0;

    private Queue<CoroutineTask> taskQueue = new Queue<CoroutineTask>();

    private readonly List<INotifiable> notifiableObjects = new List<INotifiable>();

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if (LoadFromResources())
            {
                Debug.Log($"Existing scheduler: {currentTime}");
                NotifyAll();
                // successful
            }
            else
            {
                DateTime roundedTime = RoundToHour(DateTime.Now);
                currentTime = roundedTime.ToString("yyyy-MM-dd HH:mm");
                Debug.Log($"New scheduler: {currentTime}");
                // test save
                IncrementTime();
                SaveToResources();
            }
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RunScheduledCoroutines();
    }

    /// <summary>
    /// 时间取整
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    private DateTime RoundToHour(DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
    }

    /// <summary>
    /// 时间步进30分钟
    /// </summary>
    public void IncrementTime()
    {
        DateTime dt = DateTime.Parse(currentTime);
        dt = dt.AddMinutes(30);
        currentTime = dt.ToString("yyyy-MM-dd HH:mm");
        NotifyAll();
        RunScheduledCoroutines();
    }

    /// <summary>
    /// 保存到Resources
    /// </summary>
    public void SaveToResources()
    {
        SchedulerData data = new SchedulerData();
        data.currentTime = currentTime;
        string json = JsonConvert.SerializeObject(data);

        string path = Path.Combine(Application.dataPath, "Resources", resourcePath);
        File.WriteAllText(path, json);
        Debug.Log("save successfully!");
    }

    /// <summary>
    /// 从Resources加载
    /// </summary>
    /// <returns></returns>
    public bool LoadFromResources()
    {
        string path = Path.Combine(Application.dataPath, "Resources", resourcePath);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SchedulerData data = JsonConvert.DeserializeObject<SchedulerData>(json);
            currentTime = data.currentTime;
            Debug.Log("成功加载本地Scheduler！");
            return true;
        }
        else
        {
            return false;
        }
    }

    #region 协程执行、注册、添加和删除功能
    /// <summary>
    /// 注册一个新的 CoroutineTask 以供执行。
    /// </summary>
    /// <param name="task">包含协程和可选完成回调的 CoroutineTask 对象。</param>
    // 注册一个新的 CoroutineTask
    public void RegisterCoroutineTask(CoroutineTask task)
    {
        taskQueue.Enqueue(task);
        runningCoroutinesCount++;
        Debug.Log($"新携程任务已添加！当前待执行任务数量：{runningCoroutinesCount}");
    }

    /// <summary>
    /// 开始执行所有排定的协程
    /// </summary>
    public void RunScheduledCoroutines()
    {
        Debug.Log("AAAAAAAAAAAAA");
        StartCoroutine(RunAllScheduledCoroutines());
    }

    /// <summary>
    /// 实际用于执行所有排定的协程的协程
    /// </summary>
    /// <returns></returns>    
    private IEnumerator RunAllScheduledCoroutines()
    {
        yield return new WaitForSeconds(1.5f);
        while (taskQueue.Count > 0)
        {
            var task = taskQueue.Dequeue();
            Debug.Log($"当前剩余任务数： {taskQueue.Count}");
            yield return StartCoroutine(RunAndTrackCoroutine(task));
            Debug.Log(taskQueue.Count);
        }
    }

    /// <summary>
    /// 执行并跟踪给定的 CoroutineTask。
    /// </summary>
    /// <param name="task">需要执行和跟踪的 CoroutineTask 对象。</param>
    /// <returns>IEnumerator 用于 Unity 协程。</returns>
    private IEnumerator RunAndTrackCoroutine(CoroutineTask task)
    {
        yield return StartCoroutine(task.Coroutine);
        Debug.Log($"携程数量: {runningCoroutinesCount}");
        runningCoroutinesCount--;
        task.OnCompletion?.Invoke();  // 如果提供了完成回调，则调用

        CheckAllCoroutinesCompleted();
    }

    /// <summary>
    /// 检查所有已注册的协程是否已完成。如果是，则触发 OnAllCoroutinesCompleted 事件并调用 IncrementTime 方法。
    /// </summary>
    private void CheckAllCoroutinesCompleted()
    {
        if (runningCoroutinesCount == 0)
        {
            OnAllCoroutinesCompleted?.Invoke();
            IncrementTime();
        }
    }
    #endregion


    #region 注册及广播机制
    /// <summary>
    /// 允许对象注册以接收时间点通知
    /// </summary>
    /// <param name="obj"></param>
    public void RegisterNotifiableObject(INotifiable obj)
    {
        if (!notifiableObjects.Contains(obj))
        {
            notifiableObjects.Add(obj);
            Debug.Log($"本AGENT注册成功!{obj.ToString()}");
        }
    }

    /// <summary>
    /// 在时间点到达时通知所有注册的对象
    /// </summary>
    public void NotifyAll()
    {
        StartCoroutine(NotifyAllCoroutine());
    }

    private IEnumerator NotifyAllCoroutine()
    {
        yield return new WaitForSeconds(1.0f);  // 等待一秒
        foreach (var obj in notifiableObjects)
        {
            obj.OnTimePointReached();
            Debug.Log($"通知所有注册的对象执行任务，当前时间: {currentTime}");
            yield return new WaitForSeconds(1.0f);  // 等待一秒
        }
    }
    #endregion


    /// <summary>
    /// 用于读写Scheduler的中间类，可以按需再加字段
    /// </summary>
    [Serializable]
    class SchedulerData
    {
        public string currentTime;
    }
}