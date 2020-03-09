using JqueryDataTableMasterDetail.Models;
using JqueryDataTableMasterDetail.Models.CoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryDataTableMasterDetail.Repository
{
    public interface IProductRepository
    {
        IQueryable<ProductCategoryModel> listProducts();

        IQueryable<SubCategoryModel> listSubCategory();
    }
}
