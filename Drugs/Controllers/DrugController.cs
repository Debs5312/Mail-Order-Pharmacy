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
    public class DrugController : Controller
    {
        private readonly IDrugService _drugService;
        public DrugController(IDrugService drugService)
        {
            _drugService = drugService;
        }

        public async Task<IActionResult> DrugIndex()
        {
            List<DrugDto> list = new List<DrugDto>();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetAllDrugsAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DrugDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [HttpGet]
        [Authorize]
        public async  Task<IActionResult> DrugCreate()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DrugCreate(DrugDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _drugService.CreateDrugAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(DrugIndex));
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> DrugEdit(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetDrugByIdAsync<ResponseDto>(Id, accessToken);
            if (response != null && response.IsSuccess)
            {
                DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DrugEdit(DrugDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _drugService.UpdateDrugAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(DrugIndex));
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> DrugDelete(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetDrugByIdAsync<ResponseDto>(Id, accessToken);
            if (response != null && response.IsSuccess)
            {
                DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DrugDelete(DrugDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _drugService.DeleteDrugAsync<ResponseDto>(model.Id, accessToken);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(DrugIndex));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DrugByName(string name)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetDrugByNameAsync<ResponseDto>(name, accessToken);
            if (response != null && response.IsSuccess)
            {
                DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> DrugByLoc(int id,bool choice)
        {
            List<bool> roles = new List<bool>();
            roles.Add(true);
            roles.Add(false);
            ViewBag.message = roles;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetDrugByIdAsync<ResponseDto>(id, accessToken);
            if (response != null && response.IsSuccess)
            {
                DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DrugByLoc(DrugDto drugDto,bool choice)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _drugService.GetDispatchableDrugStockAsync<ResponseDto>(drugDto.Id,drugDto.Location, drugDto.IsPayment, accessToken);
            if (response != null && response.IsSuccess)
            {
                DrugDto model = JsonConvert.DeserializeObject<DrugDto>(Convert.ToString(response.Result));
                return RedirectToAction(nameof(DrugIndex));
            }
            return NotFound();
        }
    }
}
