﻿using FuCoreApp.Mvc.DTOs;
using Newtonsoft.Json;

namespace FuCoreApp.Mvc.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = 
                    JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                categoryDtos = null;

            }
            return categoryDtos;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent
                (JsonConvert.SerializeObject(categoryDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDto = 
                    JsonConvert.DeserializeObject<CategoryDto>
                    (await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                categoryDto = null;
            }
            return categoryDto;
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(categoryDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");
                if (response.IsSuccessStatusCode)
                {
                return true;
                }
                else
                     {
                return false;
                   }
                
        }


    }
}
