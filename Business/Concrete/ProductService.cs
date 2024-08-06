 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productsRepository)
        {
            _productRepository = productsRepository;
        }

        public void IncreaseStockDaily()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                product.Stock += 10;
                _productRepository.Update(product);
            }
            
        }
        public void IncreasePriceDaily()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                product.Price += 1;
                _productRepository.Update(product);
            }

        }
    }
 }
