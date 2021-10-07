using Drugs.Models;
using Drugs.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Drugs.Services
{
    public class RefillService : BaseService, IRefillService
    {
        private readonly IHttpClientFactory _clientFactory;
        public RefillService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateAdhocAsync<T>(AdhokRefillDto adhokRefillDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = adhokRefillDto,
                Url = SD.RefillAPIBase + "/api/refill/adhocRefill",
                AccessToken = token
            });
        }

        public async Task<T> CreateRefillAsync<T>(RefillStatusDto refillStatusDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = refillStatusDto,
                Url = SD.RefillAPIBase + "/api/refill/refillstatus",
                AccessToken = token
            });
        }

        public async Task<T> DeleteAdhocAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RefillAPIBase + "/api/refill/deleteAdhoc/" + id,
                AccessToken = token
            });
        }

        public async Task<T> DeleteRefillAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RefillAPIBase + "/api/refill/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetRefillByIdAsync<T>(string id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RefillAPIBase + "/api/refill/refillst/" + id,
                AccessToken = token
            });
        }
        public async Task<T> GetRefillIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RefillAPIBase + "/api/refill/refillst/single/" + id,
                AccessToken = token
            });
        }
        public async Task<T> GetRefillBySubsIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RefillAPIBase + "/api/refill/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateRefillAsync<T>(RefillStatusDto refillStatusDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = refillStatusDto,
                Url = SD.RefillAPIBase + "/api/refill/refillstatus",
                AccessToken = token
            });
        }
    }
}
