using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace Blog.Application.Helpers;
public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(
        ActionExecutingContext context,
        ValidationProblemDetails? validationProblemDetails)
    {
        if (validationProblemDetails is null)
            return new BadRequestObjectResult("Wrong something");

        var errors = validationProblemDetails.Errors.ToDictionary();

        var envelope = ResponseFormat.Error(errors);

        return new BadRequestObjectResult(envelope);
    }
}
