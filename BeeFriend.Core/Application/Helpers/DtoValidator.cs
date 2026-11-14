using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.Helpers
{
    internal static  class DtoValidator
    {
        public static bool TryValidate<T>(
        T instance,
        out List<ValidationResult> validationResults)
        {
            validationResults = [];

            var context = new ValidationContext(instance!);

            return Validator.TryValidateObject(
                instance!,
                context,
                validationResults,
                validateAllProperties: true);
        }
    }
}
