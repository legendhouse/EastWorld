
using System.Collections.Generic;

public interface ICognition
{
    List<BaseNode> Perceive();

    /// <summary>
    /// 检索自己的记忆
    /// </summary>
    void Retrieve();

    /// <summary>
    /// 做出行动计划
    /// </summary>
    void Plan();

    /// <summary>
    /// 执行动作
    /// </summary>
    void Excecute();

    /// <summary>
    /// 将已有记忆再抽象提炼成高阶记忆
    /// </summary>
    MemoryNode Reflect(List<BaseNode> perceivedNodes);

}
