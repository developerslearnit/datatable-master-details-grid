using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryDataTableMasterDetail.Models
{
    public class ProductCategoryModel
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime loadDate { get; set; }
        public string srtDate { get { return this.loadDate.ToString("dd-MM-yyyy"); } }
    }
}
