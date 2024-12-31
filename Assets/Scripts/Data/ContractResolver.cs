using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class ContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (!typeof(string).IsAssignableFrom(property.PropertyType) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
        {
            Predicate<object> newShouldSerialize = delegate(object obj)
            {
                ICollection collection = property.ValueProvider.GetValue(obj) as ICollection;
                return collection == null || collection.Count != 0;
            };
            Predicate<object> oldShouldSerialize = property.ShouldSerialize;
            property.ShouldSerialize = ((oldShouldSerialize != null) ? ((object o) => oldShouldSerialize(o) && newShouldSerialize(o)) : newShouldSerialize);
        }
        return property;
    }
    
    public static readonly ContractResolver Instance = new ();
}