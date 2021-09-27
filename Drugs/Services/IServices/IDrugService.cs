using Drugs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Services.IServices
{
    public interface IDrugService : IBaseService
    {
        Task<T> GetAllDrugsAsync<T>(string token);
        Task<T> GetDrugByIdAsync<T>(int id, string token);
        Task<T> CreateDrugAsync<T>(DrugDto drugDto, string token);
        Task<T> UpdateDrugAsync<T>(DrugDto drugDto, string token);
        Task<T> DeleteDrugAsync<T>(int id, string token);
        Task<T> GetDrugByNameAsync<T>(string name, string token);
        Task<T> GetDispatchableDrugStockAsync<T>(int id, string location, bool choice, string token);

    }
}
