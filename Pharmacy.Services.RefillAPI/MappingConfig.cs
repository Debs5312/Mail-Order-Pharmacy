using AutoMapper;
using Pharmacy.Services.RefillAPI.Models;
using Pharmacy.Services.RefillAPI.Models.Dto;
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
                config.CreateMap<RefillStatusDto, RefillStatus>().ReverseMap();
                config.CreateMap<AdhokRefillDto, AdhokRefill>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
