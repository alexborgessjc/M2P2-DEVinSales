using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public void Atualizar()
        {
            _context.SaveChanges();
        }

        // obtém o produto por id 
        public Product? ObterProductPorId(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        // verifica se o nome já existe na base de dados
        public bool ProdutoExiste(string nome)
        {
            var produtos = _context.Products.Where(produto => (produto.Name.ToUpper() == nome.ToUpper())).ToList();
            return produtos.Count > 0 ? true : false;
        }
        public void Delete(int id)
        {
            var produto = ObterProductPorId(id);
            if (produto == null)
                throw new Exception("o Produto não existe");
            _context.Products.Remove(produto);
            _context.SaveChanges();
        }

        public List<Product> ObterProdutos(string? name, decimal? priceMin, decimal? priceMax)
        {

            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.ToUpper().Contains(name.ToUpper()));
            if (priceMin.HasValue)
                query = query.Where(p => p.SuggestedPrice >= priceMin);
            if (priceMax.HasValue)
                query = query.Where(p => p.SuggestedPrice <= priceMax);

            return query.ToList();
        }

        public int CreateNewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }
    }
}