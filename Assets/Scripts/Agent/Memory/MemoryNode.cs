

/// <summary>
/// 记忆中的事件
/// </summary>
public class MemoryNode : BaseNode
{
    public MemoryNode(string subject, string predicate, string object_, string timeStamp) : base(subject, predicate, object_, timeStamp) { }

    public MemoryNode(string subject, string predicate, string object_) : base(subject, predicate, object_) { }

    public MemoryNode(string subject, string predicate) : base(subject, predicate) { }

    public MemoryNode()
    {
    }
}
