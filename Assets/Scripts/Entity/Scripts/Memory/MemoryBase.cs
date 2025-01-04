using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class MemoryBase<T> where T : IMemorable
{
    [JsonProperty]
    public T value;
    
    [JsonProperty]
    public int priority;
    
    [JsonProperty] 
    public int lifetime;

    public bool IsEternal => lifetime == -1;
    
    public bool IsForgotten => lifetime == 0;

    public MemoryBase(T _value, int _priority = 0, int _lifetime = -1)
    {
        value = _value;
        priority = _priority;
        lifetime = _lifetime;
    }
    
    public virtual void SetLifetime(int _lifetime)
    {
        if (_lifetime < -1)
        {
            Debug.LogWarning("The life time cannot be negative.");
            return;
        }
        this.lifetime = _lifetime;
    }

    public virtual void Update(int time = 1)
    {
        if (IsEternal) return;
        
        lifetime -= time;
        if (lifetime < 0)
        {
            lifetime = 0;
            OnForget();
        }
    }

    public virtual void OnForget()
    {
        
    }
}
