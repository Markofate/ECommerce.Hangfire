using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IProductPhotoRepository _productPhotoRepository;

        public ProductPhotoService(IProductPhotoRepository productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }

    }
}
