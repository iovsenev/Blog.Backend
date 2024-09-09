using Blog.Domain.Common;
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

        var validationErrors = validationProblemDetails.Errors.ToDictionary();
        var message = "";
        foreach (var error in validationErrors)
        {
            var key = error.Key;
            var value = error.Value;
            message += key + ":[";
            foreach (var item in value)
            {
                message += item + " ";
            }
            message += "]\n";
        }

        var envelope = ResponseFormat.Error(Error.NotValid(validationErrors));

        return new BadRequestObjectResult(envelope);
    }
}
