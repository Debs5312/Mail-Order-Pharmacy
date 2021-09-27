using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<DrugDto, Drug>();
                //config.CreateMap<Drug, DrugDto>();
                //config.CreateMap<DrugDispatchDto, DrugDispatch>();
                //config.CreateMap<DrugDispatch, DrugDispatchDto>();
            });

            return mappingConfig;
        }
    }
}
