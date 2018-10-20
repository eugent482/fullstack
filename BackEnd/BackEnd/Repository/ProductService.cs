using BackEnd.Entity;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Repository
{
    public class ProductService
    {
        public List<ModalViewProducts> GetSelectProducts(List<int> ids)
        {
            List<ModalViewProducts> modalViews = new List<ModalViewProducts>();
            using (ProductRepository repository = new ProductRepository())
            {
                foreach (var item in ids)
                {
                    Product product = repository.GetItemById(item);
                    modalViews.Add(
                        new ModalViewProducts
                        {
                            ID = product.ID,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            Country = product.Country
                        });
                }
            }
            return modalViews;
        }

        public List<ModalViewProducts> GetPage(int num, int page)
        {
            List<ModalViewProducts> modalViews;
            using (ProductRepository repository = new ProductRepository())
            {
                var query = repository.GetItemQuery();
                modalViews = query.Skip((page - 1) * page).Take(num).Select((x) => new ModalViewProducts { ID = x.ID, ProductName = x.ProductName, Price = x.Price, Country = x.Country }).ToList();
            }
            return modalViews;
        }
        public int GetRows()
        {
            int num;
            using (ProductRepository repository = new ProductRepository())
            {
                num = repository.GetRows();
            }
            return num;
        }

        
        public List<ModalViewProducts> GetSelectedRows(int[] ids)
        {
            List<ModalViewProducts> modalViews = new List<ModalViewProducts>();
            using (ProductRepository repository = new ProductRepository())
            {
                foreach (var id in ids)
                {
                    Product product = repository.GetItemById(id);

                    modalViews.Add(
                        new ModalViewProducts
                        {
                            ID = product.ID,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            Country = product.Country
                        });
                }
            }
            return modalViews;
        }





        public List<ModalViewProducts> GetAllRows()
        {
            List<ModalViewProducts> modalViews = new List<ModalViewProducts>();
            using (ProductRepository repository = new ProductRepository())
            {
                foreach (var product in repository.GetItemList())
                {
                    modalViews.Add(
                        new ModalViewProducts
                        {
                            ID = product.ID,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            Country = product.Country
                        });
                }
            }
            return modalViews;
        }
        public List<ModalViewProducts> GetRowsBySearch(string search, int count, int page)
        {
            List<ModalViewProducts> modalViews = new List<ModalViewProducts>();
            using (ProductRepository repository = new ProductRepository())
            {
                modalViews = repository.GetItemQuery().Where((x) => x.ProductName.Contains(search) || x.Country.Contains(search) || (x.Price.ToString()).Contains(search)).OrderBy(x => x.ID).Skip((page - 1) * count).Take(count).Select((x) => new ModalViewProducts { ID = x.ID, ProductName = x.ProductName, Price = x.Price, Country = x.Country }).ToList();
            }
            return modalViews;
        }

        public int GetNumOfRows(string search)
        {
            int modalViews;
            using (ProductRepository repository = new ProductRepository())
            {
                modalViews = repository.GetItemQuery().Where((x) => x.ProductName.Contains(search) || x.Country.Contains(search) || (x.Price.ToString()).Contains(search)).Count();
            }
            return modalViews;
        }


    }
}