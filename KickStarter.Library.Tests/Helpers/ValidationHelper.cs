using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KickStarter.Library.Tests.Helpers
{
    public static class ValidationHelper
    {
        public static IList<ValidationResult> ValidateEntity(Object entity)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, context, validationResults, true);
            return validationResults;
        }
    }
}
