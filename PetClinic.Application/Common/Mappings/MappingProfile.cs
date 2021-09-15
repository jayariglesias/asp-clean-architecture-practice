using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace PetClinic.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && 
                    (
                        i.GetGenericTypeDefinition() == typeof(IMapFrom<>) || 
                        i.GetGenericTypeDefinition() == typeof(IMapTo<>)
                    )
                ))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var mapF = type.GetMethod("MapFrom") ??
                         instance!.GetType()
                        .GetInterface("IMapFrom`1")?
                        .GetMethod("MapFrom");

                var mapT = type.GetMethod("MapTo") ??
                         instance!.GetType()
                        .GetInterface("IMapTo`1")?
                        .GetMethod("MapTo");

                mapF?.Invoke(instance, new object[] { this });
                mapT?.Invoke(instance, new object[] { this });
            }
        }
    }
}