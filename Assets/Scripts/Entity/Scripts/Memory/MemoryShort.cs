public class MemoryShort<T> : MemoryBase<T> where T : IMemorable
{
    public MemoryShort(T _value, int _priority = 0, int _lifetime = -1): base(_value, _priority, _lifetime)
    { 
    }
}