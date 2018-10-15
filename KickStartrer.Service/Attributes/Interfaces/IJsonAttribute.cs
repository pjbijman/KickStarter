using System;

namespace KickStarter.Service.Attributes.Interfaces
{
    public interface IJsonAttribute
    {
        object TryConvert(string modelValue, Type targetType, out bool success);
    }
}
