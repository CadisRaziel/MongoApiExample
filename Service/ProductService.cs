using Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api.Service
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        public ProductService(IOptions<ProductDataBaseSettings> productService)
        {
            //Para todo model que eu cria eu preciso fazer essa config (Na documentacao da Microsoft esta dessa maneira
            var mongoClient = new MongoClient(productService.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(productService.Value.DataBaseName);

            _productCollection = mongoDataBase.GetCollection<Product>(productService.Value.ProductCollectionName);
        }


        public async Task<List<Product>> GetAsync () => await _productCollection.Find(x => true).ToListAsync();
        public async Task<Product> GetByIdAsync (string id) => await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync (Product product) => await _productCollection.InsertOneAsync(product);
        public async Task UpdateAsync (string id, Product product) => await _productCollection.ReplaceOneAsync(x => x.Id == id, product);
        public async Task RemoveAsync (string id) => await _productCollection.DeleteOneAsync(x => x.Id == id);

    }
}
