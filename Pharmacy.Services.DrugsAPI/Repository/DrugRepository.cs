using AutoMapper;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Services.DrugsAPI.DbContexts;
using Pharmacy.Services.DrugsAPI.Models;
using Pharmacy.Services.DrugsAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.DrugsAPI.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public DrugRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<DrugDto> CreateUpdateDrug(DrugDto drugDto)
        {
            Drug drug = _mapper.Map<DrugDto, Drug>(drugDto);
            if (drug.Id > 0)
            {
                _db.Drugs.Update(drug);
            }
            else
            {
                _db.Drugs.Add(drug);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Drug, DrugDto>(drug);
        }

        public async Task<bool> DeleteDrug(int Id)
        {
            try
            {
                Drug product = await _db.Drugs.FirstOrDefaultAsync(u => u.Id == Id);
                if (product == null)
                {
                    return false;
                }
                _db.Drugs.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DrugDto> GetDrugById(int Id)
        {
            Drug product = await _db.Drugs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<DrugDto>(product);
        }

        public async Task<DrugDto> GetDrugByID_Location(int ID, string Location,bool choice)
        {
            Drug product = await _db.Drugs.Where(x => x.Id == ID && x.Location == Location).FirstOrDefaultAsync();
            DrugDispatch drugDispatch = new DrugDispatch();
            drugDispatch.Drug = product;
            drugDispatch.DrugId = product.Id;
            drugDispatch.Time = DateTime.Now;
            drugDispatch.IsDispatched = true;
            drugDispatch.IsPayment = choice;

            _db.DrugDispatches.Add(drugDispatch);
            await _db.SaveChangesAsync();
            return _mapper.Map<DrugDto>(product);

        }

        public async Task<DrugDto> GetDrugByName(string Name)
        {
            Drug product = await _db.Drugs.Where(x => x.Name == Name).FirstOrDefaultAsync();
            return _mapper.Map<DrugDto>(product);
        }

        public async Task<IEnumerable<DrugDto>> GetDrugs()
        {
            List<Drug> drugList = await _db.Drugs.ToListAsync();
            return _mapper.Map<List<DrugDto>>(drugList);
        }
    }
}
