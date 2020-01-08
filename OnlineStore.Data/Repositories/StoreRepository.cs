using OnlineStore.Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineStore.SharedClasses;

namespace OnlineStore.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDBContext _context;
        public StoreRepository(StoreDBContext context)
        {
            _context = context;
        }


        public async Task<List<tblBrands>> GetAllBrands() => await (from brand in _context.tblBrands
                                                                    select brand).ToListAsync();

        public async Task<List<tblCategory>> GetAllCategories() => await (from brand in _context.tblCategories
                                                                          select brand).ToListAsync();

        public async Task<List<tblSupplier>> GetAllSuppliers() => await (from brand in _context.tblSuppliers
                                                                         select brand).ToListAsync();

        public async Task<List<BrandsProducts>> GetAllBrandsProducts() => await (from brand in _context.tblBrands
                                                                                 join product in _context.tblProducts on brand.Id equals product.Brand_Id
                                                                                 group brand by new { brand.Id, brand.Brand_Description } into ProductCount
                                                                                 select new BrandsProducts
                                                                                 {
                                                                                     Id = ProductCount.Key.Id,
                                                                                     Brand_Description = ProductCount.Key.Brand_Description,
                                                                                     NumberOfProduct = ProductCount.Count()
                                                                                 }).ToListAsync();

        public async Task<List<CategoryBrand>> GetAllCategoryBrands()
        {
            var categories = await _context.tblCategories.ToListAsync();

            if (!categories.Any())
            {
                return null;
            }

            return (from a in categories
                    select new CategoryBrand
                    {
                        Id = a.Id,
                        CategoryDescription = a.CategoryDescription,
                        tblBrands = (from B in _context.tblBrands
                                     join P in _context.tblProducts on B.Id equals P.Brand_Id
                                     where P.Category_Id == a.Id
                                     group B by new { B.Id, B.Brand_Description } into C
                                     select new tblBrands { Id = C.Key.Id, Brand_Description = C.Key.Brand_Description }).ToList()
                    }).ToList();

        }

        public async Task<List<Product>> GetQuickViewProduct() => await (from product in _context.tblProducts
                                                                         join brand in _context.tblBrands on product.Brand_Id equals brand.Id
                                                                         join category in _context.tblCategories on product.Category_Id equals category.Id
                                                                         join supplier in _context.tblSuppliers on product.Supplier_Id equals supplier.Id
                                                                         select new Product
                                                                         {
                                                                             Id = product.Id,
                                                                             Brand = brand.Brand_Description,
                                                                             Category = category.CategoryDescription,
                                                                             Supplier = supplier.Name,
                                                                             Brand_Id = product.Brand_Id,
                                                                             Category_Id = product.Category_Id,
                                                                             Supplier_Id = product.Supplier_Id,
                                                                             Product_Code = product.Product_Code,
                                                                             Badge = product.Badge,
                                                                             Stock_Count = product.Stock_Count,
                                                                             Condition = product.Condition,
                                                                             Product_Description = product.Product_Description,
                                                                             Price = product.Price,
                                                                             Update_Date = product.Update_Date,
                                                                             User_Id = product.User_Id
                                                                         }).OrderByDescending(x => x.Update_Date).Take(3).ToListAsync();

        public async Task<List<Product>> GetAllProducts() => await (from product in _context.tblProducts
                                                                    join brand in _context.tblBrands on product.Brand_Id equals brand.Id
                                                                    join category in _context.tblCategories on product.Category_Id equals category.Id
                                                                    join supplier in _context.tblSuppliers on product.Supplier_Id equals supplier.Id
                                                                    select new Product
                                                                    {
                                                                        Id = product.Id,
                                                                        Brand = brand.Brand_Description,
                                                                        Category = category.CategoryDescription,
                                                                        Supplier = supplier.Name,
                                                                        Brand_Id = product.Brand_Id,
                                                                        Category_Id = product.Category_Id,
                                                                        Supplier_Id = product.Supplier_Id,
                                                                        Product_Code = product.Product_Code,
                                                                        Badge = product.Badge,
                                                                        Stock_Count = product.Stock_Count,
                                                                        Condition = product.Condition,
                                                                        Product_Description = product.Product_Description,
                                                                        Price = product.Price,
                                                                        Update_Date = product.Update_Date,
                                                                        User_Id = product.User_Id
                                                                    }).OrderByDescending(x => x.Update_Date).ToListAsync();

        public void SaveProduct(tblProducts tblProducts)
        {
            _context.tblProducts.Add(tblProducts);
            _context.SaveChangesAsync();
        }

        public async Task<int> SaveSupplier(tblSupplier tblSupplier)
        {
            _context.tblSuppliers.Add(tblSupplier);
            int results = await _context.SaveChangesAsync();
            return results;
        }
    }
}
