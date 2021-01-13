using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL.Entities;
using SERVICE.Base;

namespace SERVICE.Repository
{
    public class ProductService : BaseService<Product>
    {
        SubCategoryService _subCategoryService = new SubCategoryService();
        

        public List<Product> GetProductsByCategoryId(Guid id)
        {
            var subCategories = _subCategoryService.GetDefault(x => x.CategoryId == id);
            List<Product> products = new List<Product>();

            foreach (var item in subCategories)
            {
                var product = GetDefault(x => x.SubCategoryId == item.ID);

                foreach (var p in product)
                {
                    products.Add(p);
                }
            }

            return products;
        }
        public List<Product> GetProductByCriterionNote(decimal rating)//todo:Kontrol edilecek
        {
            ProductService _productService = new ProductService();
            var result = _productService.GetDefault(x => x.CriterionNote == rating);
            List<Product> products = new List<Product>();
            foreach (var item in result)
            {
                var productname = GetDefault(x => x.ProductName == item.ProductName);
                foreach (var p in productname)
                {
                    products.Add(p);
                }

            }
            return products;

        }
    }
}
