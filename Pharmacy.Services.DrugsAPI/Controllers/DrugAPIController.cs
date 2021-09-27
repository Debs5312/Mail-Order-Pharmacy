using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Services.DrugsAPI.Models.Dto;
using Pharmacy.Services.DrugsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.DrugsAPI.Controllers
{
    [Route("api/drugs")]
    public class DrugAPIController : Controller
    {
        protected ResponseDto _response;
        private IDrugRepository _drugRepository;

        public DrugAPIController(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
            this._response = new ResponseDto();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DrugDto> drugDtos = await _drugRepository.GetDrugs();
                _response.Result = drugDtos;
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
                DrugDto drugDto = await _drugRepository.GetDrugById(id);
                _response.Result = drugDto;
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
        [Route("{name}/{id?}")]
        public async Task<object> Get(string name, int id)
        {
            try
            {
                DrugDto drugDto = await _drugRepository.GetDrugByName(name);
                _response.Result = drugDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<object> Post([FromBody] DrugDto drugDto)
        {
            try
            {
                DrugDto model = await _drugRepository.CreateUpdateDrug(drugDto);
                _response.Result = model;
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
        [Route(("{id}/{Location}/{choice}"))]
        public async Task<object> Post(int id, string Location, bool choice)
        {
            try
            {
                DrugDto result = await _drugRepository.GetDrugByID_Location(id, Location, choice);
                _response.Result = result;
                _response.DisplayMessage = "Succesfull";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<object> Put([FromBody] DrugDto drugDto)
        {
            try
            {
                DrugDto model = await _drugRepository.CreateUpdateDrug(drugDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _drugRepository.DeleteDrug(id);
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
