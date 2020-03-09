using System;
using System.Collections.Generic;

namespace JqueryDataTableMasterDetail.Models.CoreEF
{
    public partial class VProductForecast
    {
        public int CalendarMonth { get; set; }
        public DateTime? ReportDate { get; set; }
        public string ProductCategoryName { get; set; }
        public int? SalesQuantity { get; set; }
        public decimal? SalesAmount { get; set; }
    }
}
