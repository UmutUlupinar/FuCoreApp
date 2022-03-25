using FuCoreApp.Api.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace FuCoreApp.Api.Extensions
{
    //500 hataları için. 500 hatalarına sql server'ın drop-çalışmıyor olması örnektir.
    public static class UseCustomExceptionHandler
    {
        //Extension'lar static yapıdadır. static'ler new'lenmeye gerek duymaz. hızlıdır ama çok yer kaplar işi bitince kapatılmalı.
       // çaışması için middleware eklenmeli. program.cs
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();


                    if (error != null)
                    {
                        var ex = error.Error;
                        if(ex != null)
                        {
                            ErrorDto errorDto = new ErrorDto();
                            errorDto.Status = 500;
                            errorDto.Errors.Add(ex.Message);
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                        }

                    }
                });
            });
        }
    }
}
