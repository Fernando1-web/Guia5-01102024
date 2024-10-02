using FJMA.API.Models.DAL;
using FJMA.API.Models.EN;
using FJMA.DTOs.ProductFJMADTOs;

namespace FJMA.API.Endpoints
{
    public static class ProductFJMAEndpoint
    {
        public static void AddProductFJMAEndpoints(this WebApplication app)
        {
            //Buscar
            app.MapPost("/product/search", async (SearchQueryProductFJMADTO productFJMADTO, ProductFJMADAL productFJMADAL) =>
            {
                var product = new ProductFJMA
                {
                    NombreFJMA = productFJMADTO.NombreFJMA_Like != null ? productFJMADTO.NombreFJMA_Like : string.Empty
                };

                var products = new List<ProductFJMA>();
                int countRow = 0;

                if(productFJMADTO.SendRowCount == 2)
                {
                    products = await productFJMADAL.Search(product, skip: productFJMADTO.Skip, take: productFJMADTO.Take);
                    if(products.Count > 0)
                    {
                        countRow = await productFJMADAL.CountSearch(product);
                    }
                }
                else
                {
                    products = await productFJMADAL.Search(product, skip: productFJMADTO.Skip, take: productFJMADTO.Take);
                }

                var productResult = new SearchResultProductFJMADTO
                {
                    Data = new List<SearchResultProductFJMADTO.ProductFJMA>(),
                    CountRow = countRow
                };

                products.ForEach(s =>
                {
                    productResult.Data.Add(new SearchResultProductFJMADTO.ProductFJMA
                    {
                        Id = s.Id,
                        NombreFJMA = s.NombreFJMA,
                        DescripcionFJMA = s.DescripcionFJMA,
                        PrecioFJMA = s.PrecioFJMA
                    });
                });

                return productResult;
            });

            //Obtener por ID
            app.MapGet("/product/{id}", async (int id, ProductFJMADAL productDAL) =>
            {
                var product = await productDAL.GetById(id);

                var productResult = new GetIdResultProductFJMADTO
                {
                    Id = product.Id,
                    NombreFJMA = product.NombreFJMA,
                    DescripcionFJMA = product.DescripcionFJMA,
                    PrecioFJMA = product.PrecioFJMA
                };

                if (productResult.Id > 0)
                    return Results.Ok(productResult);
                else
                    return Results.NotFound(productResult);
            });

            //Crear nuevo producto
            app.MapPost("/product", async (CreateProductFJMADTO create, ProductFJMADAL productDAL) =>
            {
                var product = new ProductFJMA
                {
                    NombreFJMA = create.NombreFJMA,
                    DescripcionFJMA = create.DescripcionFJMA,
                    PrecioFJMA = create.PrecioFJMA
                };

                int result = await productDAL.Create(product);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //Editar
            app.MapPut("/product", async (EditProductFJMADTO edit, ProductFJMADAL productDAL) =>
            {
                var product = new ProductFJMA
                {
                    Id = edit.Id,
                    NombreFJMA = edit.NombreFJMA,
                    DescripcionFJMA = edit.DescripcionFJMA,
                    PrecioFJMA = edit.PrecioFJMA
                };

                int result = await productDAL.Edit(product);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //Eliminar
            app.MapDelete("/product/{id}", async (int id, ProductFJMADAL delete) =>
            {
                int result = await delete.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}