using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Catalog.API.Entities;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void Seedata(IMongoCollection<Product> productCollection)
        {
            bool existproduct = productCollection.Find(p => true).Any();
            if (!existproduct)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProduct());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProduct()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "",
                    Price = 1,
                    Category = ""
                    
                },
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "",
                    Price = 1,
                    Category = ""
                },
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "asd",
                    Description = "asd",
                    ImageFile = "",
                    Price = 1,
                    Category = ""
                }
            };
        }
    }
}
