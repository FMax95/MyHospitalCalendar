using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using MyHospitalCalendar.Core.Repositories;
using System.Reflection;
using System.Threading.Tasks;
using MyHospitalCalendar.Core.Services.Interfaces;

namespace MyHospitalCalendar.API
{

    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllTypes(this IServiceCollection services, IConfiguration Configuration)
        {
            var repositoryInterfaces = Assembly.Load("MyHospitalCalendar.Core").DefinedTypes
                .Where(x => x.IsInterface && x.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))).ToList();
            var repositoryImplementations = Assembly.Load("MyHospitalCalendar.Infrastructure").DefinedTypes
                .Where(x => x.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))).ToList();
            foreach (var intefaceType in repositoryInterfaces)
                services.Add(new ServiceDescriptor(intefaceType,
                    repositoryImplementations.First(x => x.GetInterfaces().Contains(intefaceType)),
                    ServiceLifetime.Scoped));

            var serviceInterfaces = Assembly.Load("MyHospitalCalendar.Core").DefinedTypes
                .Where(x => x.IsInterface && x.GetInterfaces()
                    .Any(i => i == typeof(IBaseService))).ToList();
            var serviceImplementation = Assembly.Load("MyHospitalCalendar.Core")
                .DefinedTypes
                .Where(x => x.GetInterfaces()
                    .Any(i => i == typeof(IBaseService)))
                .Where(x => x.IsClass).ToList();
            foreach (var intefaceType in serviceInterfaces)
                services.Add(new ServiceDescriptor(intefaceType,
                    serviceImplementation.First(x => x.GetInterfaces().Contains(intefaceType)),
                    ServiceLifetime.Scoped));

        }
    }
}
