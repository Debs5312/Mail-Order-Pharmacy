using Drugs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Services.IServices
{
    public interface ISubscriptionService
    {
        //Task<T> GetDrugByIdAsync<T>(int id, string token = null);
        Task<T> AddPrescriptionAsync<T>(PrescriptionDto prescriptionDto, string token = null);
        Task<T> AddSubsscriptionAsync<T>(SubscriptionDto subscriptionDto, string token = null);
        Task<T> GetPrescriptionsByIdAsync<T>(string id, string token);
        Task<T> GetSubscriptionByIdAsync<T>(string id, string token);
        Task<T> GetSubscriptionIdAsync<T>(int id, string token);
    }
}
