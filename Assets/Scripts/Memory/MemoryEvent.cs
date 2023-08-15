

/// <summary>
/// 记忆中的事件
/// </summary>
public class MemoryEvent : BaseEvent
{
    public MemoryEvent(string subject, string predicate, string object_) : base(subject, predicate, object_) { }

    public MemoryEvent(string subject, string predicate) : base(subject, predicate) { }
}
