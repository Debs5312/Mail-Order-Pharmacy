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
    public class RefillController : Controller
    {
        private readonly IRefillService _refillService;
        private readonly IDrugService _drugService;
        private readonly ISubscriptionService _subscriptionService;
        public RefillController(IDrugService drugService, IRefillService refillService, ISubscriptionService subscriptionService)
        {
            _drugService = drugService;
            _refillService = refillService;
            _subscriptionService = subscriptionService;
        }
        public async Task<IActionResult> RefillIndex()
        {
            List<RefillStatusDto> list = new List<RefillStatusDto>();
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _refillService.GetRefillByIdAsync<ResponseDto>(userId, accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<RefillStatusDto>>(Convert.ToString(response.Result));
                ViewBag.data = null;
                return View(list);
            }
            else
            {
                ViewBag.data = "Yes";
                return View();
            }
            
        }

        [Authorize]
        public async Task<IActionResult> AdhocRefillCreate(int id)
        {
            List<bool> roles = new List<bool>();
            roles.Add(true);
            roles.Add(false);
            ViewBag.message = roles;
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            AdhokRefillDto adhokRefillDto = new AdhokRefillDto();
            var response = await _subscriptionService.GetSubscriptionIdAsync<ResponseDto>(id, accessToken);
            SubscriptionDto model = JsonConvert.DeserializeObject<SubscriptionDto>(Convert.ToString(response.Result));
            var response1 = await _drugService.GetDrugByIdAsync<ResponseDto>(model.Drug_ID, accessToken);
            DrugDto model1 = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response1.Result));
            adhokRefillDto.Location = model1.Location;
            adhokRefillDto.Drug_ID = model1.Id;
            adhokRefillDto.UserID = userId;
            adhokRefillDto.Subscription_ID = model.Id;
            adhokRefillDto.Drug_Name = model1.Name;
            adhokRefillDto.RefillOccurance = model.Refill_Occurrence;
            //var response = await _subscriptionService.AddPrescriptionAsync<ResponseDto>(prescriptionDto, accessToken);
            if (adhokRefillDto.Drug_ID>0 && adhokRefillDto.Subscription_ID>0)
            {
                return View(adhokRefillDto);
            }
            return NotFound();
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdhocRefillCreate(AdhokRefillDto adhokRefillDto)
        {
            if (ModelState.IsValid)
            {
                List<bool> roles = new List<bool>();
                roles.Add(true);
                roles.Add(false);
                ViewBag.message = roles;
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _refillService.CreateAdhocAsync<ResponseDto>(adhokRefillDto, accessToken);
                RefillStatusDto model = JsonConvert.DeserializeObject<RefillStatusDto>(Convert.ToString(response.Result));
                RefillStatusDto refillStatusDto = new RefillStatusDto();
                refillStatusDto.AdhocRefillId = model.Id;
                refillStatusDto.Location = adhokRefillDto.Location;
                refillStatusDto.PaymentStatus = adhokRefillDto.IsPayment;
                refillStatusDto.Quantity = adhokRefillDto.Quantity;
                refillStatusDto.UserId = adhokRefillDto.UserID;
                refillStatusDto.Start_Date = DateTime.Now;
                refillStatusDto.DrugName = adhokRefillDto.Drug_Name;
                refillStatusDto.Subscription_ID = adhokRefillDto.Subscription_ID;
                if(adhokRefillDto.RefillOccurance == "Weekly")
                {
                    refillStatusDto.End_Date = refillStatusDto.Start_Date.AddDays(7);
                }
                else if(adhokRefillDto.RefillOccurance == "Monthly")
                {
                    refillStatusDto.End_Date = refillStatusDto.Start_Date.AddMonths(1);
                }
                else if (adhokRefillDto.RefillOccurance == "Quaterly")
                {
                    refillStatusDto.End_Date = refillStatusDto.Start_Date.AddMonths(3);
                }
                else if (adhokRefillDto.RefillOccurance == "HalfYearly")
                {
                    refillStatusDto.End_Date = refillStatusDto.Start_Date.AddMonths(6);
                }
                else
                {
                    refillStatusDto.End_Date = refillStatusDto.Start_Date.AddYears(1);
                }
                var response1 = await _refillService.CreateRefillAsync<ResponseDto>(refillStatusDto, accessToken);
                if (response != null && response.IsSuccess && response1 != null && response1.IsSuccess)
                {
                    return RedirectToAction(nameof(RefillIndex));
                }
            }
            return RedirectToAction(nameof(Index),"Subscription");
        }


        [Authorize]
        public async Task<IActionResult> EditRefillStatus(int Id)
        {
            List<bool> roles = new List<bool>();
            roles.Add(true);
            roles.Add(false);
            ViewBag.message = roles;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _refillService.GetRefillIdAsync<ResponseDto>(Id, accessToken);
            if (response != null && response.IsSuccess)
            {
                RefillStatusDto model = JsonConvert.DeserializeObject<RefillStatusDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRefillStatus(RefillStatusDto model)
        {
            if (ModelState.IsValid)
            {
                List<bool> roles = new List<bool>();
                roles.Add(true);
                roles.Add(false);
                ViewBag.message = roles;
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _refillService.UpdateRefillAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(RefillIndex));
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteRefillStatus(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response1 = await _refillService.GetRefillIdAsync<ResponseDto>(id, accessToken);
            if (response1 != null && response1.IsSuccess)
            {
                RefillStatusDto model = JsonConvert.DeserializeObject<RefillStatusDto>(Convert.ToString(response1.Result));
                return View(model);
            }
            return NotFound();
   
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRefillStatus(RefillStatusDto refillStatusDto)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                if (refillStatusDto.PaymentStatus)
                {
                    var response = await _refillService.DeleteRefillAsync<ResponseDto>(refillStatusDto.Id, accessToken);
                    if (response.IsSuccess)
                    {
                        return RedirectToAction(nameof(RefillIndex));
                    }
                }
                else
                {
                    ViewBag.data = "Your Payment is Due!";
                    return View(refillStatusDto);
                }
            }
            return RedirectToAction(nameof(RefillIndex));
        }
    }
}
