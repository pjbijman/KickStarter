using KickStarter.Service.Attributes.Interfaces;
using Newtonsoft.Json;
using System;

namespace KickStartrer.Service.Attributes
{
    public class FromJsonAttribute : Attribute, IJsonAttribute
    {
        public object TryConvert(string modelValue, Type targetType, out bool success)
        {
            var value = JsonConvert.DeserializeObject(modelValue, targetType);
            success = value != null;
            return value;
        }
    }
}