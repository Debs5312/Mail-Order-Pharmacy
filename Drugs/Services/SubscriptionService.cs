using Drugs.Models;
using Drugs.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Drugs.Services
{
    public class SubscriptionService : BaseService, ISubscriptionService
    {
        private readonly IHttpClientFactory _clientFactory;

        public SubscriptionService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetPrescriptionsByIdAsync<T>(string id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SubscriptionAPIBase + "/api/subscription/prescription/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetSubscriptionByIdAsync<T>(string id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SubscriptionAPIBase + "/api/subscription/" + id + "/{xyz}",
                AccessToken = token
            });
        }
        public async Task<T> AddPrescriptionAsync<T>(PrescriptionDto prescriptionDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = prescriptionDto,
                Url = SD.SubscriptionAPIBase + "/api/subscription",
                AccessToken = token
            });
        }

        public async Task<T> AddSubsscriptionAsync<T>(SubscriptionDto subscriptionDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = subscriptionDto,
                Url = SD.SubscriptionAPIBase + "/api/subscription/subscribe",
                AccessToken = token
            });
        }

        //public async Task<T> GetDrugByIdAsync<T>(int id, string token = null)
        //{
        //    return await this.SendAsync<T>(new ApiRequest()
        //    {
        //        ApiType = SD.ApiType.GET,
        //        Url = SD.SubscriptionAPIBase + "api/subscription/" + id,
        //        AccessToken = token
        //    });
        //}
    }
}
