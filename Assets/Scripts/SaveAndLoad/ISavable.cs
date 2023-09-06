public interface ISaveable
{
    /// <summary>
    /// 序列化成一个json string，具体存放由SaveLoadManager实现
    /// </summary>
    /// <returns></returns>
    string Save();

    /// <summary>
    /// 由外部提供json string，具体加载由各类自行实现
    /// </summary>
    /// <param name="saveData"></param>
    void Load(string saveData);
}
