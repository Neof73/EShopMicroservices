using Catalog.API.Products.CreateProduct;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products. GetProductByCategory
{
    public record  GetProductByCategoryQuery(string Category) : IQuery< GetProductByCategoryResult>;
    public record  GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class  GetProductByCategoryQueryHandler(IDocumentSession session, ILogger< GetProductByCategoryQueryHandler> logger) : IQueryHandler< GetProductByCategoryQuery,  GetProductByCategoryResult>
    {
        public async Task< GetProductByCategoryResult> Handle( GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with {@Query}", query);

            var products = await session.Query<Product>().Where(qry => qry.Category.Contains(query.Category)).ToListAsync(cancellationToken);

            return new  GetProductByCategoryResult(products);
            //throw new NotImplementedException();
        }
    }
}
