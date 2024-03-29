﻿using FuCoreApp.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FuCoreApp.Api.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(s => s.Errors);
                modelErrors.ToList().ForEach(s =>
                {
                    errorDto.Errors.Add(s.ErrorMessage);
                });
                context.Result = new BadRequestObjectResult(errorDto);
            }
        }

    }
}
