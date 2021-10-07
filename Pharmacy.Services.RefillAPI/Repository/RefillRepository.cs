using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Services.RefillAPI.Models;
using Pharmacy.Services.RefillAPI.Models.Dto;
using Pharmacy.Services.SubscriptionAPI.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.RefillAPI.Repository
{
    public class RefillRepository : IRefillRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public RefillRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAdhocRefill(int id)
        {
            try
            {
                AdhokRefill refillStatus = await _db.AdhokRefills.FirstOrDefaultAsync(u => u.Id == id);
                if (refillStatus == null)
                {
                    return false;
                }
                _db.AdhokRefills.Remove(refillStatus);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRefill(int id)
        {
            try
            {
                RefillStatus refillStatus = await _db.RefillStatuses.FirstOrDefaultAsync(u => u.Id == id);
                AdhokRefill refillStatus1 = await _db.AdhokRefills.FirstOrDefaultAsync(u => u.Id == refillStatus.AdhocRefillId);
                if (refillStatus == null || refillStatus1 == null)
                {
                    return false;
                }
                _db.RefillStatuses.Remove(refillStatus);
                _db.AdhokRefills.Remove(refillStatus1);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RefillStatusDto>> GetAllRefillStatus(string id)
        {
            List<RefillStatus> subsList = await _db.RefillStatuses.Where(x => x.UserId == id).ToListAsync();
            return _mapper.Map<List<RefillStatusDto>>(subsList);
            //throw new NotImplementedException();
        }

        public async Task<AdhokRefillDto> Refill(AdhokRefillDto adhokRefillDto)
        {
            AdhokRefill adhokRefill = _mapper.Map<AdhokRefillDto, AdhokRefill>(adhokRefillDto);
            _db.AdhokRefills.Add(adhokRefill);
            await _db.SaveChangesAsync();
            return _mapper.Map<AdhokRefill, AdhokRefillDto>(adhokRefill);
        }

        public async Task<IEnumerable<RefillStatusDto>> RefillStatusBySubsID(int subsID)
        {
            List<RefillStatus> subsList = await _db.RefillStatuses.Where(x => x.Subscription_ID == subsID).ToListAsync();
            return _mapper.Map<List<RefillStatusDto>>(subsList);
        }

        public async Task<RefillStatusDto> RefillStatusById(int id)
        {
            RefillStatus refillStatus = await _db.RefillStatuses.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<RefillStatusDto>(refillStatus);
        }

        public async Task<RefillStatusDto> UpsertRefillStatus(RefillStatusDto refillStatusDto)
        {
            RefillStatus refillStatus = _mapper.Map<RefillStatusDto, RefillStatus>(refillStatusDto);
            if (refillStatus.Id > 0)
            {
                _db.RefillStatuses.Update(refillStatus);
            }
            else
            {
                _db.RefillStatuses.Add(refillStatus);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<RefillStatus, RefillStatusDto>(refillStatus);
        }

    }
}
