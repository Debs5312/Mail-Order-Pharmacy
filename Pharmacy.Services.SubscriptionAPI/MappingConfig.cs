using AutoMapper;
using Pharmacy.Services.SubscriptionAPI.Models;
using Pharmacy.Services.SubscriptionAPI.Models.Dto;
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
                config.CreateMap<PrescriptionDto, Prescription>().ReverseMap();
                config.CreateMap<SubscriptionDto, Subscription>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
