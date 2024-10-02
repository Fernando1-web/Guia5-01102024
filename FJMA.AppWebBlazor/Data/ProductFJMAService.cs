using FJMA.DTOs.ProductFJMADTOs;

namespace FJMA.AppWebBlazor.Data
{
    public class ProductFJMAService
    {
        readonly HttpClient _httpClientFJMAAPI;

        public ProductFJMAService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFJMAAPI = httpClientFactory.CreateClient("FJMAAPI");
        }

        //POST: Buscar
        public async Task<SearchResultProductFJMADTO> Search(SearchQueryProductFJMADTO get)
        {
            var response = await _httpClientFJMAAPI.PostAsJsonAsync("/product/search", get);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultProductFJMADTO>();
                return result ?? new SearchResultProductFJMADTO();
            }
            return new SearchResultProductFJMADTO();
        }

        //POST: Buscar por ID
        public async Task<GetIdResultProductFJMADTO> GetById(int id)
        {
            var response = await _httpClientFJMAAPI.GetAsync("/product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultProductFJMADTO>();
                return result ?? new GetIdResultProductFJMADTO();
            }
            return new GetIdResultProductFJMADTO();
        }

        //POST: Crear
        public async Task<int> Create(CreateProductFJMADTO create)
        {
            int result = 0;
            var response = await _httpClientFJMAAPI.PostAsJsonAsync("/product", create);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        //PUT: Modificar
        public async Task<int> Edit(EditProductFJMADTO edit)
        {
            int result = 0;
            var response = await _httpClientFJMAAPI.PutAsJsonAsync("/product", edit);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        //DELETE: Eliminar
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientFJMAAPI.DeleteAsync("/product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
    }
}
