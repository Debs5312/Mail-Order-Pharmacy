using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Services.SubscriptionAPI.DbContexts;
using Pharmacy.Services.SubscriptionAPI.Models;
using Pharmacy.Services.SubscriptionAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public SubscriptionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        //public async Task<DrugDto> GetDrugsById(int id)
        //{
        //    Drug product = await _db.Drugs.Where(x => x.Id == id).FirstOrDefaultAsync();
        //    return _mapper.Map<DrugDto>(product);
        //}

        public async Task<SubscriptionDto> GetSubscriptionByID(int id)
        {
            Subscription subs = await _db.Subscriptions.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<SubscriptionDto>(subs);
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscription(string id)
        {
            List<Subscription> subsList = await _db.Subscriptions.Where(x => x.UserId == id).ToListAsync();
            return _mapper.Map<List<SubscriptionDto>>(subsList);
        }
        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescription(string id)
        {
            List<Prescription> subsList = await _db.Prescriptions.Where(x => x.UserId == id).ToListAsync();
            return _mapper.Map<List<PrescriptionDto>>(subsList);
        }


        public async Task<PrescriptionDto> GetSetPrescriptionDetails(PrescriptionDto prescriptionDto)
        {
            //Drug drug = await _db.Drugs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            Prescription prescription = _mapper.Map<PrescriptionDto, Prescription>(prescriptionDto);
            _db.Prescriptions.Add(prescription);
            await _db.SaveChangesAsync();
            return _mapper.Map<Prescription, PrescriptionDto>(prescription);
        }

        public async Task<SubscriptionDto> Subscribe(SubscriptionDto subscriptionDto)
        {
            Subscription subscription = _mapper.Map<SubscriptionDto, Subscription>(subscriptionDto);
            _db.Subscriptions.Add(subscription);
            await _db.SaveChangesAsync();
            return _mapper.Map<Subscription, SubscriptionDto>(subscription);
        }

        //public async Task<SubscriptionDto> Unsubscribe(DrugDispatchDto drugDispatchDto, int Id)
        //{
        //    Subscription subscription = await _db.Subscriptions.Where(x => x.Id == Id).FirstOrDefaultAsync();
        //    if(drugDispatchDto.IsPayment)
        //    {
        //        _db.Subscriptions.Remove(subscription);
        //        await _db.SaveChangesAsync();
        //    }
        //}
    }
}
