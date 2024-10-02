using FJMA.DTOs.ProductFJMADTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FJMA.AppWebMVC.Controllers
{
    public class ProductFJMAController : Controller
    {
        public readonly HttpClient _httpClientFJMAAPI;

        public ProductFJMAController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFJMAAPI = httpClientFactory.CreateClient("FJMAAPI");
        }

        //Index
        public async Task<IActionResult> Index(SearchQueryProductFJMADTO searchQueryProductFJMADTO, int CountRow = 0)
        {
            if (searchQueryProductFJMADTO.SendRowCount == 0)
                searchQueryProductFJMADTO.SendRowCount = 2;
            if (searchQueryProductFJMADTO.Take == 0)
                searchQueryProductFJMADTO.Take = 10;

            var result = new SearchResultProductFJMADTO();
            var response = await _httpClientFJMAAPI.PostAsJsonAsync("/product/search", searchQueryProductFJMADTO);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultProductFJMADTO>();

            result = result != null ? result : new SearchResultProductFJMADTO();

            if (result.CountRow == 0 && searchQueryProductFJMADTO.SendRowCount == 1)
                result.CountRow = CountRow;

            ViewBag.CountRow = result.CountRow;
            searchQueryProductFJMADTO.SendRowCount = 0;
            ViewBag.SearchQuery = searchQueryProductFJMADTO;

            return View(result);
        }

        //Detalles
        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultProductFJMADTO();
            var response = await _httpClientFJMAAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductFJMADTO>();

            return View(result ?? new GetIdResultProductFJMADTO());
        }

        // GET: Crear
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductFJMADTO create)
        {
            try
            {
                var response = await _httpClientFJMAAPI.PostAsJsonAsync("/product", create);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al ingresar datos";
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Editar
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultProductFJMADTO();
            var response = await _httpClientFJMAAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductFJMADTO>();

            return View(new EditProductFJMADTO(result ?? new GetIdResultProductFJMADTO()));
        }

        // POST: Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductFJMADTO edit)
        {
            try
            {
                var response = await _httpClientFJMAAPI.PutAsJsonAsync("/product", edit);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al editar datos";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultProductFJMADTO();
            var response = await _httpClientFJMAAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductFJMADTO>();

            return View(result ?? new GetIdResultProductFJMADTO());
        }

        // POST: Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultProductFJMADTO get)
        {
            try
            {
                var response = await _httpClientFJMAAPI.DeleteAsync("/product" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al eliminar datos";
                return View(get);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(get);
            }
        }
    }
}
