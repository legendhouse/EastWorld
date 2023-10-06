using System;
using System.Collections;

public class CoroutineTask
{
    public IEnumerator Coroutine { get; private set; }
    public DateTime TaskTime { get; private set; }
    public Action OnStart { get; private set; }
    public Action OnCompletion { get; private set; }

    /// <summary>
    /// 协程任务类构造函数
    /// </summary>
    /// <param name="coroutine">协程任务具体内容</param>
    /// <param name="onStart">回调方法，可以为空</param>
    /// <param name="onCompletion">回调方法，可以为空</param>
    public CoroutineTask(IEnumerator coroutine, DateTime taskTime, Action onStart = null, Action onCompletion = null)
    {
        Coroutine = coroutine;
        TaskTime = taskTime;
        OnStart = onStart;
        OnCompletion = onCompletion;
    }
}
