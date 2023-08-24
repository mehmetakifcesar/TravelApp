using Microsoft.AspNetCore.Mvc.Filters;
using TravelApp.Api.Validation.FluentValidation;

namespace TravelApp.Api.Aspects
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private Type _validatorType;
        public ValidationFilter(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public async Task  OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Validator.Validate(_validatorType, context.ActionArguments.Values.ToArray());
            var executedContext = await next();
        }
    }
}
