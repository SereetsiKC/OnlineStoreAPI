using OnlineStore.Data.Repositories;
using OnlineStore.Domain.DataObjects;
using OnlineStore.SharedClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.WebAPI.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repository;

        public StoreService(IStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoteCallResult<List<tblBrands>>> GetAllBrands()
        {
            return RemoteCallResult.Success(await _repository.GetAllBrands());
        }

        public async Task<RemoteCallResult<List<tblCategory>>> GetAllCategories()
        {
            return RemoteCallResult.Success(await _repository.GetAllCategories());
        }

        public async Task<RemoteCallResult<List<tblSupplier>>> GetAllSuppliers()
        {
            return RemoteCallResult.Success(await _repository.GetAllSuppliers());
        }

        public async Task<RemoteCallResult<List<BrandsProducts>>> GetAllBrandsProducts()
        {
            return RemoteCallResult.Success(await _repository.GetAllBrandsProducts());
        }

        public async Task<RemoteCallResult<List<CategoryBrand>>> GetAllCategoryBrands()
        {
            return RemoteCallResult.Success(await _repository.GetAllCategoryBrands());
        }

        public async Task<RemoteCallResult<List<Product>>> GetQuickViewProduct()
        {
            return RemoteCallResult.Success(await _repository.GetQuickViewProduct());
        }

        public async Task<RemoteCallResult<List<Product>>> GetAllProducts()
        {
            return RemoteCallResult.Success(await _repository.GetAllProducts());
        }

        public async Task<RemoteCallResult<int>> SaveProduct(tblProducts tblProducts)
        {
            return RemoteCallResult.Success(await _repository.SaveProduct(tblProducts));
        }

        public async Task<RemoteCallResult<int>> SaveSupplier(tblSupplier tblSupplier)
        {
            return RemoteCallResult.Success(await _repository.SaveSupplier(tblSupplier));
        }
    }
}
