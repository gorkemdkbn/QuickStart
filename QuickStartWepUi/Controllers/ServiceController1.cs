using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartWepUI.Dtos.Services;
using System.Net.Http;

namespace QuickStartWepUI.Controllers
{
    public class ServiceController1 : Controller
    {
        private readonly IHttpClientFactory  _httpClientFactory;

        public ServiceController1(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7185/api/Service");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServicesDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
