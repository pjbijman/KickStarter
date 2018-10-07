using System;

namespace KickStarter.ServiceLayer.Services.Attributes.Interfaces
{
    public interface IJsonAttribute
    {
        object TryConvert(string modelValue, Type targetType, out bool success);
    }
}