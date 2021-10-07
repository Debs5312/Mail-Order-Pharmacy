using Pharmacy.Services.SubscriptionAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Repository
{
    public interface ISubscriptionRepository
    {
        Task<PrescriptionDto> GetSetPrescriptionDetails(PrescriptionDto prescriptionDto);
        //Task<DrugDto> GetDrugsById(int id);
        Task<SubscriptionDto> Subscribe(SubscriptionDto subscriptionDto);

        Task<IEnumerable<PrescriptionDto>> GetAllPrescription(string id);

        Task<IEnumerable<SubscriptionDto>> GetAllSubscription(string id);
        Task<SubscriptionDto> GetSubscriptionByID(int id);
        //Task<SubscriptionDto> Unsubscribe(DrugDispatchDto drugDispatchDto, int Id);
    }
}
