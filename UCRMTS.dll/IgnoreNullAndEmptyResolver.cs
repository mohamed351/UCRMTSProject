using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace UCRMTS.dll
{
    public class IgnoreNullAndEmptyResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = instance =>
            {
                var value = property.ValueProvider.GetValue(instance);

                // Skip nulls
                if (value == null)
                    return false;

                // Skip empty collections or arrays
                if (value is ICollection collection && collection.Count == 0)
                    return false;

                // Skip empty string
                if (value is string s && string.IsNullOrWhiteSpace(s))
                    return false;

                return true;
            };

            return property;
        }
    }
}
