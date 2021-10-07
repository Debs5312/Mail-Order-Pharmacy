using Drugs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Services.IServices
{
    public interface IRefillService
    {
        Task<T> GetRefillByIdAsync<T>(string id, string token);
        Task<T> GetRefillIdAsync<T>(int id, string token);
        Task<T> GetRefillBySubsIdAsync<T>(int id, string token);
        Task<T> CreateAdhocAsync<T>(AdhokRefillDto adhokRefillDto, string token);
        Task<T> CreateRefillAsync<T>(RefillStatusDto refillStatusDto, string token);
        Task<T> UpdateRefillAsync<T>(RefillStatusDto refillStatusDto, string token);
        Task<T> DeleteAdhocAsync<T>(int id, string token);
        Task<T> DeleteRefillAsync<T>(int id, string token);
    }
}
