using KickStarter.ServiceLayer.Attributes;
using KickStarter.ServiceLayer.Attributes.Interfaces;
using KickStarter.ServiceLayer.Services.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace KickStarter.ServiceLayer.Helpers
{
    public class JsonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.Metadata.IsComplexType)
            {
                var propName = context.Metadata.PropertyName;
                var propInfo = context.Metadata.ContainerType?.GetProperty(propName);
                if (propName == null || propInfo == null)
                    return null;
                // Look for FromJson attributes
                var attribute = propInfo.GetCustomAttributes(typeof(FromJsonAttribute), false).FirstOrDefault();
                if (attribute != null)
                    return new JsonModelBinder(context.Metadata.ModelType, attribute as IJsonAttribute);
            }

            return null;
        }
    }
}