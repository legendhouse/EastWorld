using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 认知模块
/// 
/// 涉及跟LLM交互的方法，由于有一定交互时间，均使用协程；其余接口为普通的void即可
/// </summary>
public interface ICognition
{
    List<BaseNode> Perceive();

    /// <summary>
    /// 检索自己的记忆
    /// </summary>
    void Retrieve();

    /// <summary>
    /// 安排行动计划
    /// </summary>
    void Plan();

    /// <summary>
    /// 执行动作
    /// </summary>
    IEnumerator Excecute();

    /// <summary>
    /// 将已有记忆再抽象提炼成高阶记忆
    /// </summary>
    MemoryNode Reflect(List<BaseNode> perceivedNodes);

    /// <summary>
    /// 对话
    /// </summary>
    /// <returns></returns>
    IEnumerator Converse(ICognition other);
}
