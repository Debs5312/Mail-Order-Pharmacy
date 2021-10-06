using Pharmacy.Services.RefillAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.RefillAPI.Repository
{
    public interface IRefillRepository
    {
        Task<AdhokRefillDto> Refill(AdhokRefillDto adhokRefillDto);
        Task<bool> DeleteAdhocRefill(int id);
        Task<bool> DeleteRefill(int id);
        //Task<DrugDto> GetDrugsById(int id);
        Task<RefillStatusDto> RefillStatusById(int id);
        Task<IEnumerable<RefillStatusDto>> GetAllRefillStatus(string id);
        Task<RefillStatusDto> UpsertRefillStatus(RefillStatusDto refillStatusDto);
    }
}
