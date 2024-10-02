using FJMA.API.Models.EN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace FJMA.API.Models.DAL
{
    public class ProductFJMADAL
    {
        readonly FJMAContext _context;

        public ProductFJMADAL(FJMAContext context)
        {
            _context = context;
        }

        //Crear
        public async Task<int> Create(ProductFJMA productFJMA)
        {
            _context.Add(productFJMA);
            return await _context.SaveChangesAsync();
        }

        //Obtener por ID
        public async Task<ProductFJMA> GetById(int id)
        {
            var products = await _context.ProductsFJMA.FirstOrDefaultAsync(s => s.Id == id);
            return products != null ? products : new ProductFJMA();
        }

        //Editar
        public async Task<int> Edit(ProductFJMA productFJMA)
        {
            int result = 0;
            var productUpdate = await GetById(productFJMA.Id);
            if (productUpdate.Id != 0)
            {
                productUpdate.NombreFJMA = productFJMA.NombreFJMA;
                productUpdate.DescripcionFJMA = productFJMA.DescripcionFJMA;
                productUpdate.PrecioFJMA = productFJMA.PrecioFJMA;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Eliminar
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var productDelete = await GetById(id);
            if (productDelete.Id != 0)
            {
                _context.ProductsFJMA.Remove(productDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Buscar productos con filtros
        private IQueryable<ProductFJMA> Query(ProductFJMA product)
        {
            var query = _context.ProductsFJMA.AsQueryable();
            if (!string.IsNullOrWhiteSpace(product.NombreFJMA))
                query = query.Where(s => s.NombreFJMA.Contains(product.NombreFJMA));
            return query;
        }

        //Conteo de resultados
        public async Task<int> CountSearch(ProductFJMA product)
        {
            return await Query(product).CountAsync();
        }

        public async Task<List<ProductFJMA>> Search(ProductFJMA product, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(product);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
