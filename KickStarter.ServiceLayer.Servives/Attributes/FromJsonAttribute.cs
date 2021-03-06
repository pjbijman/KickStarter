﻿using System;
using Newtonsoft.Json;
using KickStarter.ServiceLayer.Attributes.Interfaces;

namespace KickStarter.ServiceLayer.Attributes
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