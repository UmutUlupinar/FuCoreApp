﻿using FuCoreApp.Mvc.DTOs;
using Newtonsoft.Json;

namespace FuCoreApp.Mvc.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> productDtos;
            var response = await _httpClient.GetAsync("product");
            if (response.IsSuccessStatusCode)
            {

                productDtos =
                    JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                productDtos = null;
            }

            return productDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            ProductDto productDto;
            var response = await _httpClient.GetAsync($"product/{id}");
            if (response.IsSuccessStatusCode)
            {
                productDto = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                productDto = null;
            }

            return productDto;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {

            var stringContent = new StringContent
                (JsonConvert.SerializeObject(productDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                productDto =
                    JsonConvert.DeserializeObject<ProductDto>
                    (await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                productDto = null;
            }
            return productDto;
        }


        public async Task<bool> Update(ProductDto productDto)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(productDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("product", stringContent);
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
            var response = await _httpClient.DeleteAsync($"product/{id}");
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
