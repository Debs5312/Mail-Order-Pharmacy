using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Services.RefillAPI.Models.Dto;
using Pharmacy.Services.RefillAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.RefillAPI.Controllers
{
    [Route("api/refill")]
    public class RefillAPIController : Controller
    {
        protected ResponseDto _response;
        private IRefillRepository _refillRepository;

        public RefillAPIController(IRefillRepository refillRepository)
        {
            _refillRepository = refillRepository;
            this._response = new ResponseDto();
        }
        //[Authorize]
        [HttpGet]
        [Route("refillst/{id}")]
        public async Task<object> Get(string id)
        {
            try
            {
                IEnumerable<RefillStatusDto> subDtos = await _refillRepository.GetAllRefillStatus(id);
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

        //[Authorize]
        [HttpGet]
        [Route("refillst/single/{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                RefillStatusDto subDtos = await _refillRepository.RefillStatusById(id);
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
        //[Authorize]
        [HttpPost]
        [Route("adhocRefill")]
        public async Task<object> Post([FromBody] AdhokRefillDto adhokRefillDto)
        {
            try
            {
                AdhokRefillDto subDtos = await _refillRepository.Refill(adhokRefillDto);
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

        //[Authorize]
        [HttpPost]
        [Route("refillstatus")]
        public async Task<object> Post([FromBody] RefillStatusDto refillStatusDto)
        {
            try
            {
                RefillStatusDto subDtos = await _refillRepository.UpsertRefillStatus(refillStatusDto);
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

        [HttpPut]
        [Route("refillstatus")]
        public async Task<object> Put([FromBody] RefillStatusDto refillStatusDto)
        {
            try
            {
                RefillStatusDto subDtos = await _refillRepository.UpsertRefillStatus(refillStatusDto);
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

        //[Authorize]
        [HttpDelete]
        [Route("deleteAdhoc/{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _refillRepository.DeleteAdhocRefill(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //[Authorize]
        [HttpDelete]
        [Route("deleteRefill/{id}/{xyz?}")]
        public async Task<object> Delete(int id,string xyz)
        {
            try
            {
                bool isSuccess = await _refillRepository.DeleteRefill(id);
                _response.Result = isSuccess;
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
