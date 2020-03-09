using JqueryDataTableMasterDetail.Models;
using JqueryDataTableMasterDetail.Models.CoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryDataTableMasterDetail.Repository
{
   
    public class ProductRepository : IProductRepository
    {
        private readonly ContosoRetailDWContext _context;
        public ProductRepository(ContosoRetailDWContext context)
        {
            _context = context;
        }

        public IQueryable<ProductCategoryModel> listProducts()
        {
            return _context.DimProductCategory.Select(x => new ProductCategoryModel
            {
                categoryId = x.ProductCategoryKey,
                name =x.ProductCategoryName,
                description = x.ProductCategoryDescription,
                loadDate = x.LoadDate.HasValue ? x.LoadDate.Value : DateTime.Now
            });
        }

        public IQueryable<SubCategoryModel> listSubCategory()
        {
            return _context.DimProductSubcategory.Select(x => new SubCategoryModel
            {
                categoryId = x.ProductCategoryKey.Value,
                description =x.ProductSubcategoryDescription,
                label =x.ProductSubcategoryLabel,
                name =x.ProductSubcategoryName
            });
        }
    }
}
