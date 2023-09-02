using System;
using System.Collections;
using UnityEngine;

public class CoroutineTask
{
    public IEnumerator Coroutine { get; private set; }
    public Action OnCompletion { get; private set; }

    public CoroutineTask(IEnumerator coroutine, Action onCompletion = null)
    {
        this.Coroutine = coroutine;
        this.OnCompletion = onCompletion;
    }
}
