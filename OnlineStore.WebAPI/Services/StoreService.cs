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

        public async Task<RemoteCallResult<List<tblBrands>>> GetAllBrands() => RemoteCallResult.Success(await _repository.GetAllBrands());
        public async Task<RemoteCallResult<List<tblCategory>>> GetAllCategories() => RemoteCallResult.Success(await _repository.GetAllCategories());
        public async Task<RemoteCallResult<List<tblSupplier>>> GetAllSuppliers() => RemoteCallResult.Success(await _repository.GetAllSuppliers());
        public async Task<RemoteCallResult<List<BrandsProducts>>> GetAllBrandsProducts() => RemoteCallResult.Success(await _repository.GetAllBrandsProducts());
        public async Task<RemoteCallResult<List<CategoryBrand>>> GetAllCategoryBrands() => RemoteCallResult.Success(await _repository.GetAllCategoryBrands());
        public async Task<RemoteCallResult<List<Product>>> GetQuickViewProduct() => RemoteCallResult.Success(await _repository.GetQuickViewProduct());
        public async Task<RemoteCallResult<List<Product>>> GetAllProducts() => RemoteCallResult.Success(await _repository.GetAllProducts());
        public void SaveProduct(tblProducts tblProducts) =>  _repository.SaveProduct(tblProducts);
        public async Task<RemoteCallResult<int>> SaveSupplier(tblSupplier tblSupplier) => RemoteCallResult.Success(await _repository.SaveSupplier(tblSupplier));

    }
}
