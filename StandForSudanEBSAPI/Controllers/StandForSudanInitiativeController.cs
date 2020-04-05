using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using StandForSudanEBSAPI.Models;
using System.Net;
using Newtonsoft.Json;

namespace StandForSudanEBSAPI.Controllers
{
    public class StandForSudanInitiativeController : Controller
    {
        HttpClient _httpClient = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowCounter()
        {
            var data = await GetStandForSudan();
            return View(data);
        }

        private async Task<StandForSudan> GetStandForSudan()
        {
            string url = "https://standforsudan.ebs-sd.com/StandForSudan/getStandForSudanStatstics";
            var content = await _httpClient.GetAsync(url);
            try
            {
                var response = await content.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StandForSudan>(response);
            }
            
           catch(WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure)
                    TempData["Failure"] = String.Format("عفوا لا يوجد اتصال بشبكة انترنت");
                else
                {
                    TempData["Failure"] = String.Format("تم جلب البيانات بنجاح");
                }
            }

            return null;
        }
    }
}