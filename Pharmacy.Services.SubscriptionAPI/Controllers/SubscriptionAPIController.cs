using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Services.SubscriptionAPI.Models.Dto;
using Pharmacy.Services.SubscriptionAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Controllers
{
    [Route("api/subscription")]
    public class SubscriptionAPIController : Controller
    {
        protected ResponseDto _response;
        private ISubscriptionRepository _subscriptionRepository;

        public SubscriptionAPIController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            this._response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        [Route("prescription/{id}")]
        public async Task<object> Get(string id)
        {
            try
            {
                IEnumerable<PrescriptionDto> subDtos = await _subscriptionRepository.GetAllPrescription(id);
                _response.Result = subDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                SubscriptionDto subDtos = await _subscriptionRepository.GetSubscriptionByID(id);
                _response.Result = subDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpGet]
        [Route("{id}/{xyz?}")]
        public async Task<object> Get(string id,string xyz)
        {
            try
            {
                IEnumerable<SubscriptionDto> subDtos = await _subscriptionRepository.GetAllSubscription(id);
                _response.Result = subDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost]
        //[Route("{id}")]
        public async Task<object> Post([FromBody] PrescriptionDto prescriptionDto)
        {
            try
            {
                PrescriptionDto prescription = await _subscriptionRepository.GetSetPrescriptionDetails(prescriptionDto);
                _response.Result = prescription;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost]
        [Route("subscribe")]
        public async Task<object> Post([FromBody] SubscriptionDto subscriptionDto)
        {
            try
            {
                SubscriptionDto subscription = await _subscriptionRepository.Subscribe(subscriptionDto);
                _response.Result = subscription;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
