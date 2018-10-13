using AutoMapper;
using System;

namespace KickStarter.ServiceLayer.Tests
{

    public class MapperResolver
    {
        private static MapperResolver instance;
        private static Boolean mapperInitialized = false;
        private static readonly object mapperLock = new object();

        public static MapperResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapperResolver();
                }
                return instance;
            }
        }

        public MapperResolver()
        {
            lock (mapperLock)
            {
                if (!mapperInitialized)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.AddProfile<ClientModelToEntityMappingProfile>();
                    });
                    mapperInitialized = true;
                }
            }
        }
    }
}
