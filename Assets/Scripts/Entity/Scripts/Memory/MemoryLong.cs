
public class MemoryLong<T> : MemoryBase<T> where T : IMemorable
{
    public MemoryLong(T _value, int _priority = 0, int _lifetime = -1): base(_value, _priority, _lifetime)
    { 
    }
}
