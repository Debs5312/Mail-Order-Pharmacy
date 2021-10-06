using Drugs.Models;
using Drugs.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IDrugService _drugService;
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(IDrugService drugService, ISubscriptionService subscriptionService)
        {
            _drugService = drugService;
            _subscriptionService = subscriptionService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<SubscriptionDto> list = new List<SubscriptionDto>();
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _subscriptionService.GetSubscriptionByIdAsync<ResponseDto>(userId, accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<SubscriptionDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DrugById(int Id)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _drugService.GetDrugByIdAsync<ResponseDto>(Id, accessToken);
                if (response != null && response.IsSuccess)
                {
                    DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> PrescriptionCreate(int id)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetDrugByIdAsync<ResponseDto>(id, accessToken);
            DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
            PrescriptionDto prescriptionDto = new PrescriptionDto();
            prescriptionDto.DrugId = model.Id;
            prescriptionDto.UserId = userId;
                //var response = await _subscriptionService.AddPrescriptionAsync<ResponseDto>(prescriptionDto, accessToken);
            if (response != null && response.IsSuccess)
            {
                return View(prescriptionDto);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrescriptionCreate(PrescriptionDto prescriptionDto)
        {
            if(ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _subscriptionService.AddPrescriptionAsync<ResponseDto>(prescriptionDto, accessToken);
                if (response != null && response.IsSuccess)
                {
                    PrescriptionDto model = JsonConvert.DeserializeObject<PrescriptionDto>(Convert.ToString(response.Result));
                    return RedirectToAction("GetAllPrescriptions");
                }
            }
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> GetAllPrescriptions(int id)
        {
            List<PrescriptionDto> list = new List<PrescriptionDto>();
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _subscriptionService.GetPrescriptionsByIdAsync<ResponseDto>(userId, accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PrescriptionDto>>(Convert.ToString(response.Result));
            }
            ViewBag.id = id;
            return View(list);
        }

        //public async Task<IActionResult> GetAllSubscriptions()
        //{
        //    List<SubscriptionDto> list = new List<SubscriptionDto>();
        //    var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
        //    var response = await _subscriptionService.GetSubscriptionByIdAsync<ResponseDto>(userId, accessToken);
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<SubscriptionDto>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Subscribe(PrescriptionDto prescriptionDto)
        {
            
            List<string> roles = new List<string>();
            roles.Add("Weekly");
            roles.Add("Monthly");
            roles.Add("Quaterly");
            roles.Add("HalfYearly");
            roles.Add("Annually");
            ViewBag.message = roles;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            SubscriptionDto subscriptionDto = new SubscriptionDto();
            var response = await _drugService.GetDrugByIdAsync<ResponseDto>(prescriptionDto.DrugId, accessToken);
            DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
            subscriptionDto.UserId = prescriptionDto.UserId;
            subscriptionDto.Drug_ID = prescriptionDto.DrugId;
            subscriptionDto.Prescription_Id = prescriptionDto.Id;
            subscriptionDto.Location = model.Location;
            subscriptionDto.Subscription_Date = DateTime.Now;
            //var response = await _subscriptionService.AddPrescriptionAsync<ResponseDto>(prescriptionDto, accessToken);
            return (subscriptionDto.Drug_ID > 0 && subscriptionDto.Prescription_Id > 0) ? View(subscriptionDto) : NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(SubscriptionDto subscriptionDto)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _subscriptionService.AddSubsscriptionAsync<ResponseDto>(subscriptionDto, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction(nameof(DrugById));
        }

    }
}
