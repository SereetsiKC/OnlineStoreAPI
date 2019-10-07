using OnlineStore.Domain.DataObjects;
using OnlineStore.SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebAPI.Services
{
    public interface IStoreService
    {
        Task<RemoteCallResult<List<tblBrands>>> GetAllBrands();
        Task<RemoteCallResult<List<tblCategory>>> GetAllCategories();
        Task<RemoteCallResult<List<tblSupplier>>> GetAllSuppliers();
        Task<RemoteCallResult<List<BrandsProducts>>> GetAllBrandsProducts();
        Task<RemoteCallResult<List<CategoryBrand>>> GetAllCategoryBrands();
        Task<RemoteCallResult<List<Product>>> GetQuickViewProduct();
        Task<RemoteCallResult<List<Product>>> GetAllProducts();
        Task<RemoteCallResult<int>> SaveProduct(tblProducts tblProducts);
        Task<RemoteCallResult<int>> SaveSupplier(tblSupplier tblSupplier);
    }
}
