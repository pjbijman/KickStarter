using KickStarter.Library.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace KickStartrer.Service.Helpers
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddValidationResults(this ModelStateDictionary modelStateDictionary,
            BaseEntity businessEntity)
        {
            if (businessEntity == null) return;
            foreach (var propertyErrors in businessEntity.ValidationResults)
            foreach (var error in propertyErrors.Value)
                modelStateDictionary.AddModelError(propertyErrors.Key, error);
        }

        public static void AddValidationResults(this ModelStateDictionary modelStateDictionary,
            BaseEntity businessEntity, string complexObjectprefix)
        {
            if (businessEntity == null) return;
            foreach (var propertyErrors in businessEntity.ValidationResults)
            foreach (var error in propertyErrors.Value)
                modelStateDictionary.AddModelError(
                    complexObjectprefix + (string.IsNullOrEmpty(complexObjectprefix) ? string.Empty : ".") +
                    propertyErrors.Key, error);
        }

        public static void AddValidationResults(this ModelStateDictionary modelStateDictionary,
            HashSet<string> validationDictionary)
        {
            foreach (var error in validationDictionary) modelStateDictionary.AddModelError(string.Empty, error);
        }
    }
}