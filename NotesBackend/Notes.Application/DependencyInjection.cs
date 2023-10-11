using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behaviors;

namespace Notes.Application;

public class DependencyInjection
{
    public static IServiceCollection AddApplication(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        return services;
    }
}