using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHouse.API.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static void AddProblemDetailsMapping(this IServiceCollection serviceCollection,
                                                    IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = (context, exception) => webHostEnvironment.IsDevelopment();

                options.MapToBadRequestWithDetails<JsonPatchException>();

                options.MapToNotFoundWithDetails<KeyNotFoundException>();

                options.Map<DbUpdateException>(exception =>
                {
                    if (exception.InnerException is PostgresException postgresException &&
                        postgresException.SqlState == PostgresErrorCodes.UniqueViolation)
                    {
                        return new StatusCodeProblemDetails(StatusCodes.Status409Conflict)
                        {
                            Detail = postgresException.Detail
                        };
                    }

                    return new ProblemDetails();
                });

                options.Map<ValidationException>(
                    exception =>
                    {
                        var errors = exception.Errors.Any()
                            ? exception.Errors
                                .GroupBy(failure => failure.PropertyName)
                                .ToDictionary(
                                    group => group.Key,
                                    group => group.Select(failure => failure.ErrorMessage)
                                        .ToArray())
                            : new Dictionary<string, string[]>
                                {{$"{nameof(ValidationException)}", new[] {exception.Message}}};

                        return exception.HResult == StatusCodes.Status409Conflict
                            ? new ValidationProblemDetails(errors) { Status = StatusCodes.Status409Conflict }
                            : new ValidationProblemDetails(errors) { Status = StatusCodes.Status400BadRequest };
                    });
            });
        }
    }

    public static class ProblemDetailsMappingExtensions
    {
        public static void MapToBadRequestWithDetails<TException>(this ProblemDetailsOptions options)
            where TException : Exception
        {
            MapToStatusCodeWithDetailsInternal<TException>(options, StatusCodes.Status400BadRequest);
        }

        public static void MapToNotFoundWithDetails<TException>(this ProblemDetailsOptions options)
            where TException : Exception
        {
            MapToStatusCodeWithDetailsInternal<TException>(options, StatusCodes.Status404NotFound);
        }

        public static void MapToConflictWithDetails<TException>(this ProblemDetailsOptions options)
            where TException : Exception
        {
            MapToStatusCodeWithDetailsInternal<TException>(options, StatusCodes.Status409Conflict);
        }

        private static void MapToStatusCodeWithDetailsInternal<TException>(this ProblemDetailsOptions options, int statusCode)
            where TException : Exception
        {
            options.Map<TException>(exception => new StatusCodeProblemDetails(statusCode)
            {
                Detail = exception.Message
            });
        }
    }
}
