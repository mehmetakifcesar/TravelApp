using FluentValidation;
using FluentValidation.Results;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Validation.FluentValidation
{
    public static class Validator
    {

        public static void Validate(Type type, object[] items)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Hata: Validator tipi geçersiz!");
            }
               

            var validator = (IValidator)Activator.CreateInstance(type);

            foreach (var item in items)
            {
                if (validator.CanValidateInstancesOfType(item.GetType()))
                {
                    var result = validator.Validate(new ValidationContext<object>(item));

                    List<string> ValidationMessages = new List<string>();
                    foreach (var error in result.Errors)
                    {
                        ValidationMessages.Add(error.ErrorMessage);
                    }

                    if (!result.IsValid)
                    {
                        throw new FieldValidationException(ValidationMessages);
                    }
                       
                }
            }
        }

        public static ValidationResult Validate(Type type, Object item)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Hata: Validator tipi geçersiz!");
            }
            var validator = (IValidator)Activator.CreateInstance(type);

            return validator.Validate(new ValidationContext<object>(item));
        }
    }
}
