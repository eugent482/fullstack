using BackEnd.Entity;
using BackEnd.Models;
using BackEnd.Repository;
using Bogus;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd.Controllers
{
    public class HomeController : Controller
    {
       


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetExcel()
        {
            ProductService service = new ProductService();
            using (var excel = new ExcelPackage())
            {
                var wks = excel.Workbook.Worksheets.Add("Products");
                wks.Cells[1, 1].LoadFromCollection(service.GetAllRows(), PrintHeaders: true);
                return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "products.xlsx");
            };
        }


       
        public FileResult GetSelectedExcel(int[] id)
        {
            ProductService service = new ProductService();
            using (var excel = new ExcelPackage())
            {
                var wks = excel.Workbook.Worksheets.Add("Products");
                wks.Cells[1, 1].LoadFromCollection(service.GetSelectedRows(id), PrintHeaders: true);
              
                return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "products.xlsx");
            };
        }




        public ContentResult FillTable(string search="",int num=10,int page=1)
        {
            string json = "";

            ProductService service = new ProductService();

            List<ModalViewProducts> products = service.GetRowsBySearch(search, num, page);
            double nums = Math.Ceiling((double)service.GetNumOfRows(search) / num);
            json = JsonConvert.SerializeObject(
               new
               {
                   itemcount = nums,
                   productlist = products
               });
            return Content(json, "application/json");
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Factorial(int id)
        {
            int result = 1;
            for (int i = 1; i <= id; i++)
            {
                result *= i;
            }


            return Json(result,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddProduct(Product prod)
        {
            using (ProductRepository repo = new ProductRepository())
            {
                repo.Create(prod);
                repo.Save();
            }

                return new EmptyResult();
        }


        [HttpPost]
        public ActionResult EditProduct(Product prod)
        {
            using (ProductRepository repo = new ProductRepository())
            {
                Product edproduct=repo.GetItemById(prod.ID);
                edproduct.Price = prod.Price;
                edproduct.ProductName = prod.ProductName;
                edproduct.Country = prod.Country;
                repo.Save();
            }

            return new EmptyResult();
        }

    


        public ActionResult FillDB()
        {
            var faker = new Faker("ru");
            using (ProductRepository repo = new ProductRepository())
            {
                for (int i = 0; i < 100; i++)
                {
                    repo.Create(new Entity.Product { ProductName = faker.Commerce.Product(), Country = faker.Address.Country(), Price = float.Parse(faker.Commerce.Price(10, 500)) });
                }
                repo.Save();
            }
            return View();
        }
    }
}