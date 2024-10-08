using GRWalks.UI.Models;
using GRWalks.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GRWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            try
            {
                // Get All Regions from Web API
                var client = _httpClientFactory.CreateClient();

                var httpResponseMsg = await client.GetAsync("https://localhost:7139/api/regions");

                httpResponseMsg.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMsg.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

                
            }
            catch (Exception ex)
            {
                // Log the exception
            }


            return View(response);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel addRegionViewModel)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7139/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(addRegionViewModel), Encoding.UTF8, "application/json")
            };

            var httpResponseMsg = await client.SendAsync(httpRequestMessage);
            httpResponseMsg.EnsureSuccessStatusCode();

            //if we had a response body to API

            //var response = await httpResponseMsg.Content.ReadFromJsonAsync<RegionDto>();

            //if(response is not null)
            //{
            //    return RedirectToAction("Index", "Regions");
            //}

            return RedirectToAction("Index", "Regions");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();

            var httpResponseMsg = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7139/api/regions/{id.ToString()}");

            if(httpResponseMsg is not null)
            {
                return View(httpResponseMsg);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto regionDto)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7139/api/regions/{regionDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json")
            };

            var httpResponseMsg = await client.SendAsync(httpRequestMessage);
            httpResponseMsg.EnsureSuccessStatusCode();

            var response = await httpResponseMsg.Content.ReadFromJsonAsync<RegionDto>();

            if (response is not null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto regionDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponseMsg = await client.DeleteAsync($"https://localhost:7139/api/regions/{regionDto.Id}");
                httpResponseMsg.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Regions");
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View("Edit");
        }
    }
}
