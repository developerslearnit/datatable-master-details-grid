using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JqueryDataTableMasterDetail.Models;
using JqueryDataTableMasterDetail.Models.CoreEF;
using JqueryDataTableMasterDetail.Repository;

namespace JqueryDataTableMasterDetail.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IProductRepository _context;
        public HomeController(IProductRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var products = 

            return View();
        }

        [HttpPost]
        public IActionResult loadCategories()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var categories = _context.listProducts();

                recordsTotal = categories.Count();

                categories = categories.OrderBy(x => x.categoryId).Skip(skip).Take(pageSize);

                return Json(new
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = categories
                });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet()]
        [Route("subCategory/{id}")]
        public IActionResult subCategory(int id)
        {
            return Json(new { data = _context.listSubCategory().Where(x => x.categoryId == id) });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
