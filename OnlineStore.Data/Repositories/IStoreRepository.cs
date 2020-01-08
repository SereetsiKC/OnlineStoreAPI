using OnlineStore.Domain.DataObjects;
using OnlineStore.SharedClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.Repositories
{
    public interface IStoreRepository
    {
        Task<List<tblBrands>> GetAllBrands();
        Task<List<tblCategory>> GetAllCategories();
        Task<List<tblSupplier>> GetAllSuppliers();
        Task<List<BrandsProducts>> GetAllBrandsProducts();
        Task<List<CategoryBrand>> GetAllCategoryBrands();
        Task<List<Product>> GetQuickViewProduct();
        Task<List<Product>> GetAllProducts();
        void SaveProduct(tblProducts tblProducts);
        Task<int> SaveSupplier(tblSupplier tblSupplier);
    }
}
