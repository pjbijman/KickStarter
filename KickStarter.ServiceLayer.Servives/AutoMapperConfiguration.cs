using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace KickStarter.ServiceLayer
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ClientModelToEntityMappingProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
