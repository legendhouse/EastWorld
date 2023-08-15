using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona : MonoBehaviour, ICognition
{
    #region MonoBehaviour
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion


    #region ICognition Implements
    public void Perceive()
    {

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

    public void Reflect()
    {

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
