using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Pharmacy.Services.DrugsAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.DrugsAPI.Repository
{
    public interface IDrugRepository
    {
        Task<IEnumerable<DrugDto>> GetDrugs();
        Task<DrugDto> GetDrugById(int Id);
        Task<DrugDto> CreateUpdateDrug(DrugDto product);
        Task<bool> DeleteDrug(int Id);
        Task<DrugDto> GetDrugByName(string Name);
        Task<DrugDto> GetDrugByID_Location(int ID,string Location,bool choice);
    }
}
