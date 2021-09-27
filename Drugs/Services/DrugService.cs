using Drugs.Models;
using Drugs.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Drugs.Services
{
    public class DrugService : BaseService, IDrugService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DrugService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateDrugAsync<T>(DrugDto drugDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = drugDto,
                Url = SD.DrugAPIBase + "/api/drugs",
                AccessToken = token
            }) ;
        }

        public async Task<T> DeleteDrugAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.DrugAPIBase + "/api/drugs/" + id,
                AccessToken = token
            }) ;
        }

        public async Task<T> GetAllDrugsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DrugAPIBase + "/api/drugs",
                AccessToken = token
            });
        }

        public async Task<T> GetDrugByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DrugAPIBase + "/api/drugs/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetDrugByNameAsync<T>(string name, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DrugAPIBase + "/api/drugs/" +name + "/{id}",
                AccessToken = token
            });
        }

        public async Task<T> GetDispatchableDrugStockAsync<T>(int id, string location, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.DrugAPIBase + "/api/drugs/" + id.ToString() + "/" +  location,
                AccessToken = token
            });
        }

        public async Task<T> UpdateDrugAsync<T>(DrugDto drugDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = drugDto,
                Url = SD.DrugAPIBase + "/api/drugs",
                AccessToken = token
            });
        }
    }
}
